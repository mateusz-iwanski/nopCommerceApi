using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Services.Product
{
    public interface ITierPriceService
    {
        TierPrice Create(TierPriceCreateDto tierPriceDto);
        bool? Delete(int id);
        IEnumerable<TierPriceDto> GetAll();
        IEnumerable<TierPriceDetailsDto> GetAllDetails();
        TierPriceDto GetById(int id);
        bool? Update(int id, TierPriceUpdateDto tierPriceDto);
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

            return tierPriceDtos;
        }

        public IEnumerable<TierPriceDetailsDto> GetAllDetails()
        {
            var tierPrices = _context.TierPrices.ToList();
            var tierPriceDtos = _mapper.Map<List<TierPriceDetailsDto>>(tierPrices);

            return tierPriceDtos;
        }

        public TierPriceDto GetById(int id)
        {
            var tierPrice = _context.TierPrices.FirstOrDefault(p => p.Id == id);

            var tierPriceDto = tierPrice != null ? _mapper.Map<TierPriceDto>(tierPrice) : throw new NotFoundExceptions($"Tier price with id {id} not found");

            return tierPriceDto;
        }

        public TierPrice Create(TierPriceCreateDto tierPriceDto)
        {
            var tierPrice = _mapper.Map<TierPrice>(tierPriceDto);

            _context.TierPrices.Add(tierPrice);
            _context.SaveChanges();

            return tierPrice;
        }

        public bool? Update(int id, TierPriceUpdateDto tierPriceDto)
        {
            var tierPrice = _context.TierPrices.FirstOrDefault(p => p.Id == id);

            if (tierPrice == null) return null;

            _mapper.Map(tierPriceDto, tierPrice);
            _context.SaveChanges();

            return true;
        }

        public bool? Delete(int id)
        {
            var tierPrice = _context.TierPrices.FirstOrDefault(p => p.Id == id);

            if (tierPrice == null) return null;

            _context.TierPrices.Remove(tierPrice);
            _context.SaveChanges();

            return true;
        }
    }
}
