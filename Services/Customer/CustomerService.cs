using AutoMapper;
using Azure.Core;
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
        Task<string> CreateBasePLAsync(CustomerCreateBaseDto createCustomerDto);
        Task<bool> ConnectToAddressAsync(Guid customerGuid, int addressId);
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
        public async Task<string> CreateBasePLAsync(CustomerCreateBaseDto createCustomerDto)
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

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            _context.CustomerPasswords.Add(CustomerPasswordManager.CreatePassword(customer, createCustomerDto.Password, _settings));
            await _context.SaveChangesAsync();

            string jsonString = createCustomerDto.JsonSerializeReferenceLoopHandlingIgnore();

            return jsonString;
        }

        public async Task<bool> ConnectToAddressAsync(Guid customerGuid, int addressId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerGuid == customerGuid);
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
                throw new NotFoundExceptions("This address or customer does not exist.");
            }

            return true;
        }
    }
}
