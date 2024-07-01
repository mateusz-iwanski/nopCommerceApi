using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.Controllers
{
    [Route("api/country")]
    public class CountryController : ControllerBase
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        public CountryController(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<CountryDto> GetAll()
        {
            var country = _context.Countries.ToList();
            var countryDtos = _mapper.Map<List<CountryDto>>(country);
            return Ok(countryDtos);
        }
    }
}
