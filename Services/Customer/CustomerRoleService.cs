using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Customer;

namespace nopCommerceApi.Services.Customer
{
    public interface ICustomerRoleService
    {
        Task<IEnumerable<CustomerRoleDto>> GetAllAsync();
    }

    public class CustomerRoleService : ICustomerRoleService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        public CustomerRoleService(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerRoleDto>> GetAllAsync()
        {
            var customerRoles = await _context.CustomerRoles
                .AsNoTracking()
                .ToListAsync();
            var customerRoleDtos = _mapper.Map<List<CustomerRoleDto>>(customerRoles);

            return customerRoleDtos;
        }
    }
}
