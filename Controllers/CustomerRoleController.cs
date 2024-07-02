using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;


namespace nopCommerceApi.Controllers
{
    [Route("api/customerrole")]
    public class CustomerRoleController : ControllerBase
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        public CustomerRoleController(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<CustomerRole> GetAll()
        {
            var customerRoles = _context.CustomerRoles.ToList();
            var customerRoleDtos = _mapper.Map<List<CustomerRoleDto>>(customerRoles);
            return Ok(customerRoleDtos);
        }
    }
}
