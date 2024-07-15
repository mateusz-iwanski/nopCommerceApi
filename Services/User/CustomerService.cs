using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Customer;

namespace nopCommerceApi.Services.User
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
            var customers = _context
                .Customers
                .Include(c => c.BillingAddress).ThenInclude(a => a.Country).ThenInclude(c => c.StateProvinces)
                .Include(c => c.ShippingAddress).ThenInclude(a => a.Country).ThenInclude(c => c.StateProvinces)
                .Include(c => c.Language)
                .Include(c => c.Country)
                .Include(c => c.StateProvince)
                .Include(c => c.Currency)
                .ToList();

            var customerDtos = _mapper.Map<List<CustomerDto>>(customers);

            return customerDtos;
        }
    }
}
