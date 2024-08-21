using AutoMapper;
using Azure.Core;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using nopCommerceApi.Config;
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
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<string> CreateBasePLAsync(CustomerPLCreateBaseDto createCustomerDto);
        Task<bool> ConnectToAddressAsync(Guid customerGuid, int addressId);
        Task<CustomerDto> UpdatePLAsync(CustomerPLUpdateDto updateCustomerDto);
        Task<bool> UpdatePasswordAsync(Guid customerGuid, string newPassword);
    }

    public class CustomerService : ICustomerService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;
        private readonly TaxCategoryService _taxCategoryService;
        private readonly IMySettings _settings;

        public CustomerService(NopCommerceContext context, IMapper mapper, IMySettings settings)
        {
            _context = context;
            _mapper = mapper;
            _settings = settings;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _context.Customers
                .Include(c => c.Language)
                .Include(c => c.Country)
                .Include(c => c.StateProvince)
                .Include(c => c.Currency)
                .AsNoTracking()
                .Where(c => c.Active == true && c.IsSystemAccount == false)
                .ToListAsync();
            

            var customerDtos = _mapper.Map<List<CustomerDto>>(customers);

            return customerDtos;
        }

        /// <summary>
        /// Create with base customer data for Polish customers.
        /// Default customer role is Registered.
        /// </summary>
        /// <param name="createCustomerDto"></param>
        /// <returns></returns>
        public async Task<string> CreateBasePLAsync(CustomerPLCreateBaseDto createCustomerDto)
        {
            var customer = _mapper.Map<Entities.Usable.Customer>(createCustomerDto);

            var languageId = _context.Languages.FirstOrDefault(l => l.UniqueSeoCode == "pl").Id;
            var currenyId = _context.Currencies.FirstOrDefault(c => c.CurrencyCode == "PLN").Id;
            var countryId = _context.Countries.FirstOrDefault(c => c.TwoLetterIsoCode == "PL").Id;
            

            var customerRole = _context.CustomerRoles.FirstOrDefault(cr => cr.SystemName == "Registered");
            customer.CustomerRoles.Add(customerRole);

            customer.LanguageId = languageId;
            customer.CurrencyId = currenyId;
            customer.CountryId = countryId;

            customer.CustomerGuid = Guid.NewGuid();
            customer.CreatedOnUtc = DateTime.Now;

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            _context.CustomerPasswords.AddAsync(CustomerPasswordManager.CreatePassword(customer, createCustomerDto.Password, _settings));

            await _context.SaveChangesAsync();

            string jsonString = createCustomerDto.JsonSerializeReferenceLoopHandlingIgnore();

            return jsonString;
        }

        public async Task<bool> ConnectToAddressAsync(Guid customerGuid, int addressId)
        {

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerGuid == customerGuid && c.Active == true && c.IsSystemAccount == false);
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == addressId);

            if (customer != null && address != null)
            {
                var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Addresses.Any(a => a.Id == addressId && c.Id != customer.Id));
                if (existingCustomer != null)
                {
                    throw new BadRequestException("This address is already associated with another customer.");
                }

                customer.Addresses.Add(address);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundExceptions("This address or customer does not exist. Active customers and customers who do not have a system account are taken into account");
            }

            return true;
        }

        public async Task<CustomerDto> UpdatePLAsync(CustomerPLUpdateDto updateCustomerDto)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == updateCustomerDto.Id && c.Active == true && c.IsSystemAccount == false);

            if (customer != null)
            {
                customer.Username = updateCustomerDto.Username;
                customer.Email = updateCustomerDto.Email;
                customer.FirstName = updateCustomerDto.FirstName;
                customer.LastName = updateCustomerDto.LastName;
                customer.Company = updateCustomerDto.Company;
                customer.StreetAddress = updateCustomerDto.StreetAddress;
                customer.StreetAddress2 = updateCustomerDto.StreetAddress2;
                customer.ZipPostalCode = updateCustomerDto.ZipPostalCode;
                customer.City = updateCustomerDto.City;
                customer.County = updateCustomerDto.County;
                customer.Phone = updateCustomerDto.Phone;
                customer.IsTaxExempt = updateCustomerDto.IsTaxExempt;
                customer.VendorId = updateCustomerDto.VendorId;
                customer.Active = updateCustomerDto.Active;
                customer.Deleted = updateCustomerDto.Deleted;
                customer.IsSystemAccount = updateCustomerDto.IsSystemAccount;
            }
            else throw new NotFoundExceptions("Customer not found. Active customers and customers who do not have a system account are taken into account");

            _context.Customers.Update(customer);

            await _context.SaveChangesAsync();

            var customerDto = _mapper.Map<CustomerDto>(customer);

            return customerDto;
        }

        // TODO updating password not working
        // make password change
        public async Task<bool> UpdatePasswordAsync(Guid customerGuid, string newPassword)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerGuid == customerGuid && c.Active == true && c.IsSystemAccount == false);

            if (customer == null) throw new NotFoundExceptions($"Customer with guid {customerGuid} not found. Active customers and customers who do not have a system account are taken into account");

            var customerPassword = await _context.CustomerPasswords.FirstOrDefaultAsync(cp => cp.CustomerId == customer.Id);

            if (customerPassword == null) throw new NotFoundExceptions($"Customer password with id {customerGuid} not found");

            if (string.IsNullOrEmpty(newPassword)) throw new BadRequestException("Password can't be empty");

            // TODO: make password length configurable from settings.ini
            if (newPassword.Length < 6) throw new BadRequestException("Password must be at least 6 characters long");

            var cusomtomerPasswordManager = CustomerPasswordManager.CreatePassword(customer, newPassword, _settings);

            var addPassword = new Entities.Usable.CustomerPassword
            {
                CustomerId = customer.Id,
                Password = cusomtomerPasswordManager.Password,
                PasswordFormatId = cusomtomerPasswordManager.PasswordFormatId,
                PasswordSalt = cusomtomerPasswordManager.PasswordSalt,
                CreatedOnUtc = cusomtomerPasswordManager.CreatedOnUtc
            };

            await _context.CustomerPasswords.AddAsync(addPassword);

            await _context.SaveChangesAsync();

            return true;

        }
    }
}
