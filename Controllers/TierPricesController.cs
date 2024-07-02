using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace nopCommerceApi.Controllers
{
    [Route("api/tierprices")]
    public class TierPricesController : ControllerBase
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;
        
        public TierPricesController(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<TierPrice> GetAll()
        {
            var tierPrices = _context
                .TierPrices
                .ToList();

            var tierPriceDtos = _mapper.Map<List<TierPriceDto>>(tierPrices);

            // if you want to add connection to table CustomerRole uncomment  
            // var options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.IgnoreCycles };
            // string jsonString = JsonSerializer.Serialize(tierPriceDtos, options);            
            // return Ok(jsonString);

            return Ok(tierPriceDtos);
        }
    }
}
