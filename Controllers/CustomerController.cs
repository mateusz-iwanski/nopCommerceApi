using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.Controllers
{
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        public CustomerController(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<CustomerDto> GetAll()
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

            return Ok(customerDtos);
        }
    }
}
