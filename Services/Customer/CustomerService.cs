using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Helpers;
using nopCommerceApi.Models.Customer;
using System.Net;
using System.Security.Cryptography;
using System.Text.Json;

namespace nopCommerceApi.Services.Customer
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAll();
        string CreateBasePL(CreateBaseCustomerDto createCustomerDto);
        bool ConnectToAddress(Guid customerGuid, int addressId);
    }

    public class CustomerService : ICustomerService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;
        private readonly TaxCategoryService _taxCategoryService;

        public CustomerService(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public IEnumerable<CustomerDto> GetAll()
        {
            var customers = _context.Customers
                .Include(c => c.Language)
                .Include(c => c.Country)
                .Include(c => c.StateProvince)
                .Include(c => c.Currency)
                .ToList();

            //var customers = _context.Customers.ToList();
            var customerDtos = _mapper.Map<List<CustomerDto>>(customers);

            return customerDtos;
        }

        /// <summary>
        /// Create with base customer data for Polish customers.
        /// Default customer role is Registered.
        /// </summary>
        /// <param name="createCustomerDto"></param>
        /// <returns></returns>
        public string CreateBasePL(CreateBaseCustomerDto createCustomerDto)
        {
            var customer = _mapper.Map<Entities.Usable.Customer>(createCustomerDto);

            var languageId = _context.Languages.FirstOrDefault(l => l.UniqueSeoCode == "pl").Id;
            var currenyId = _context.Currencies.FirstOrDefault(c => c.CurrencyCode == "PLN").Id;
            var countryId = _context.Countries.FirstOrDefault(c => c.TwoLetterIsoCode == "PL").Id;
            
            // customer connect to role with customer [Customer_CustomerRole_Mapping]
            var customerRole = _context.CustomerRoles.FirstOrDefault(cr => cr.SystemName == "Registered");
            customer.CustomerRoles.Add(customerRole);

            customer.LanguageId = languageId;
            customer.CurrencyId = currenyId;
            customer.CountryId = countryId;

            _context.Customers.Add(customer);
            _context.SaveChanges();

            string jsonString = createCustomerDto.JsonSerializeReferenceLoopHandlingIgnore();



            _context.CustomerPasswords.Add(createPassword(PasswordFormat.Hashed, customer, createCustomerDto.Password));
            _context.SaveChanges();

            return jsonString;
        }

        public bool ConnectToAddress(Guid customerGuid, int addressId)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerGuid == customerGuid);
            var address = _context.Addresses.FirstOrDefault(a => a.Id == addressId);

            if (customer != null && address != null)
            {
                // Check if the address is already associated with another customer
                var existingCustomer = _context.Customers.FirstOrDefault(c => c.Addresses.Any(a => a.Id == addressId && c.Id != customer.Id));
                if (existingCustomer != null)
                {
                    throw new BadRequestException("This address is already associated with another customer.");
                }

                customer.Addresses.Add(address);
                _context.SaveChanges();
            }
            else
            {
                throw new NotFoundExceptions("This address or customer does not exists.");
            }

            return true;
        }

        #region Password

        public partial class SecureRandomNumberGenerator : RandomNumberGenerator
        {
            #region Field

            protected bool _disposed;
            protected readonly RandomNumberGenerator _rng;

            #endregion

            #region Ctor

            public SecureRandomNumberGenerator()
            {
                _rng = Create();
            }

            #endregion

            #region Methods

            public int Next()
            {
                var data = new byte[sizeof(int)];
                _rng.GetBytes(data);
                return BitConverter.ToInt32(data, 0) & (int.MaxValue - 1);
            }

            public int Next(int maxValue)
            {
                return Next(0, maxValue);
            }

            public int Next(int minValue, int maxValue)
            {
                ArgumentOutOfRangeException.ThrowIfGreaterThan(minValue, maxValue);
                return (int)Math.Floor(minValue + ((double)maxValue - minValue) * NextDouble());
            }

            public double NextDouble()
            {
                var data = new byte[sizeof(uint)];
                _rng.GetBytes(data);
                var randUint = BitConverter.ToUInt32(data, 0);
                return randUint / (uint.MaxValue + 1.0);
            }

            public override void GetBytes(byte[] data)
            {
                _rng.GetBytes(data);
            }

            public override void GetNonZeroBytes(byte[] data)
            {
                _rng.GetNonZeroBytes(data);
            }

            /// <summary>
            /// Dispose secure random
            /// </summary>
            public new void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            // Protected implementation of Dispose pattern.
            protected override void Dispose(bool disposing)
            {
                if (_disposed)
                    return;

                if (disposing)
                {
                    _rng?.Dispose();
                }

                _disposed = true;
            }

            #endregion
        }

        public static string GenerateRandomDigitCode(int length)
        {
            using var random = new SecureRandomNumberGenerator();
            var str = string.Empty;
            for (var i = 0; i < length; i++)
                str = string.Concat(str, random.Next(10).ToString());
            return str;
        }

        private CustomerPassword createPassword(PasswordFormat passwordFormat, Entities.Usable.Customer customer, string password) 
        {
            EncryptionService _encryptionService = new EncryptionService(
                new SecuritySettings
                {
                    EncryptionKey = GenerateRandomDigitCode(16),
                    AdminAreaAllowedIpAddresses = null,
                    HoneypotEnabled = false,
                    HoneypotInputName = "hpinput",
                    AllowNonAsciiCharactersInHeaders = true,
                    UseAesEncryptionAlgorithm = true,
                    AllowStoreOwnerExportImportCustomersWithHashedPassword = true
                });

            var customerPassword = new CustomerPassword
            {
                CustomerId = customer.Id,
                PasswordFormatId = (int)passwordFormat,
                CreatedOnUtc = DateTime.UtcNow
            };

            switch (passwordFormat)
            {
                case PasswordFormat.Clear:
                    customerPassword.Password = password;
                    break;
                case PasswordFormat.Encrypted:
                    customerPassword.Password = _encryptionService.EncryptText(password);
                    break;
                case PasswordFormat.Hashed:
                    // default from nopcommerce class NopCustomerServicesDefaults
                    // Gets a password salt key size
                    //public static int PasswordSaltKeySize => 5;
                    //public static string DefaultHashedPasswordFormat => "SHA512"; - Gets or sets a customer password format (SHA1, MD5) when passwords are hashed (DO NOT edit in production environment)

                    var saltKey = _encryptionService.CreateSaltKey(5);
                    customerPassword.PasswordSalt = saltKey;
                    customerPassword.Password = _encryptionService.CreatePasswordHash(password, saltKey, "SHA512");
                    break;
            }

            return customerPassword;
        }
        #endregion
    }
}
