using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.Controllers
{
    public class StateProvinceController : ControllerBase
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        public StateProvinceController(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<StateProvince> GetAll()
        {
            var customers = _context
                .StateProvinces
                .Include(c => c.Country)
                .ToList();

            var customerDtos = _mapper.Map<List<StateProvinceDto>>(customers);

            return Ok(customerDtos);
        }
    }
}
