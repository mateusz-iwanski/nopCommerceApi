using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using nopCommerceApi.Entities;
using nopCommerceApi.Helpers;
using nopCommerceApi.Models.Customer;
using System.Net;
using System.Text.Json;

namespace nopCommerceApi.Services.Customer
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAll();
        string CreateBasePL(CreateBaseCustomerDto createCustomerDto);
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
            var customer = _mapper.Map<Entities.Customer>(createCustomerDto);

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

            return jsonString;
        }



    }
}
