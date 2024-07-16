using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Customer;
using System.Net;

namespace nopCommerceApi.Services.Customer
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAll();
        Entities.Customer AddBasePL(CreateBaseCustomerPLDto createCustomerDto);
    }

    public class CustomerService : ICustomerService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

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
        /// Create with base customer data for Polish customers
        /// </summary>
        /// <param name="createCustomerDto"></param>
        /// <returns></returns>
        public Entities.Customer AddBasePL(CreateBaseCustomerPLDto createCustomerDto)
        {
            var customer = _mapper.Map<Entities.Customer>(createCustomerDto);
            
            var languageId = _context.Languages.FirstOrDefault(l => l.UniqueSeoCode == "pl").Id;
            var currenyId = _context.Currencies.FirstOrDefault(c => c.CurrencyCode == "PLN").Id;
            var countryId = _context.Countries.FirstOrDefault(c => c.TwoLetterIsoCode == "PL").Id;
            // customer connect role with customer [Customer_CustomerRole_Mapping]
            var cumerRoleId = _context.CustomerRoles.FirstOrDefault(cr => cr.SystemName == "Registered"); 

            customer.LanguageId = languageId;
            customer.CurrencyId = currenyId;
            customer.CountryId = countryId;

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

    }
}
