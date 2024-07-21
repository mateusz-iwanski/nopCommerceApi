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
        IEnumerable<CustomerDto> GetAll();
        string CreateBasePL(CreateBaseCustomerDto createCustomerDto);
        bool ConnectToAddress(Guid customerGuid, int addressId);
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

            // password is not necessary
            if (!string.IsNullOrEmpty(createCustomerDto.Password))
            {
                // add password
                _context.CustomerPasswords.Add(CustomerPasswordManager.CreatePassword(customer, createCustomerDto.Password, _settings));
                _context.SaveChanges();
            }

            string jsonString = createCustomerDto.JsonSerializeReferenceLoopHandlingIgnore();

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
    }
}
