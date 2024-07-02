using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.Services
{
    public interface ITierPriceService
    {
        IEnumerable<TierPriceDto> GetAll();
    }

    public class TierPriceService : ITierPriceService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        public TierPriceService(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<TierPriceDto> GetAll()
        {
            var tierPrices = _context.TierPrices.ToList();
            var tierPriceDtos = _mapper.Map<List<TierPriceDto>>(tierPrices);

            // if you want to add connection to table CustomerRole uncomment  
            // var options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.IgnoreCycles };
            // string jsonString = JsonSerializer.Serialize(tierPriceDtos, options);            
            // return Ok(jsonString);

            return tierPriceDtos;
        }
    }
}
