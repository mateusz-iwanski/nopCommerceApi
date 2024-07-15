using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Customer;

namespace nopCommerceApi.Services.Customer
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAll();
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
            var customers = _context.Customers.ToList();
            var customerDto = _mapper.Map<List<CustomerDto>>(customers);
            return customerDto;
        }
    }
}
