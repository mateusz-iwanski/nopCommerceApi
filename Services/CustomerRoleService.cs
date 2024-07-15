using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.User;

namespace nopCommerceApi.Services
{
    public interface ICustomerRoleService
    {
        IEnumerable<CustomerRoleDto> GetAll();
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

        public IEnumerable<CustomerRoleDto> GetAll()
        {
            var customerRoles = _context.CustomerRoles.ToList();
            var customerRoleDtos = _mapper.Map<List<CustomerRoleDto>>(customerRoles);

            return customerRoleDtos;
        }
    }
}
