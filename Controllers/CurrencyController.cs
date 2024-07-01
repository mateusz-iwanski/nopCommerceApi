using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.Controllers
{
    [Route("api/currency")]
    public class CurrencyController : ControllerBase
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        public CurrencyController(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<CurrencyDto> GetAll()
        {
            var currency = _context.Currencies.ToList();
            var currencyDtos = _mapper.Map<List<CurrencyDto>>(currency);
            return Ok(currencyDtos);
        }
    }
}
