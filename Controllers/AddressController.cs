using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.Controllers
{
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        public AddressController(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<AddressDto> GetAll()
        {
            var addresses = _context.Addresses
                .Include(a => a.Country)
                .Include(a => a.StateProvince).ThenInclude(c => c.Country)
                .ToList();
            var addressDtos = _mapper.Map<List<AddressDto>>(addresses);
         
            return Ok(addressDtos);
        }
    }
}
