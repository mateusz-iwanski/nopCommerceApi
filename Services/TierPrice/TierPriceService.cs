using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.TierPrice;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Services.TierPrice
{
    public interface ITierPriceService
    {
        Task<Entities.Usable.TierPrice> CreateAsync(TierPriceCreateDto tierPriceDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TierPriceDto>> GetAllAsync();
        Task<IEnumerable<TierPriceDetailsDto>> GetAllDetailsAsync();
        Task<TierPriceDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(TierPriceUpdateDto tierPriceDto);
    }

    public class TierPriceService : BaseService, ITierPriceService
    {
        public TierPriceService(NopCommerceContext context, IMapper mapper, ILogger<ProductService> logger)
            : base(context, mapper, logger)
        {
        }

        public async Task<IEnumerable<TierPriceDto>> GetAllAsync()
        {
            var tierPrices = await _context.TierPrices
                .AsNoTracking()
                .ToListAsync();
            var tierPriceDtos = _mapper.Map<List<TierPriceDto>>(tierPrices);

            return tierPriceDtos;
        }

        public async Task<IEnumerable<TierPriceDetailsDto>> GetAllDetailsAsync()
        {
            var tierPrices = await _context.TierPrices
                .Include(tp => tp.Product)
                .Include(tp => tp.CustomerRole)
                .AsNoTracking()
                .ToListAsync();
            var tierPriceDtos = _mapper.Map<List<TierPriceDetailsDto>>(tierPrices);

            return tierPriceDtos;
        }

        public async Task<TierPriceDto> GetByIdAsync(int id)
        {
            var tierPrice = await _context.TierPrices
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            var tierPriceDto = tierPrice != null ? _mapper.Map<TierPriceDto>(tierPrice) : throw new NotFoundExceptions($"Tier price with id {id} not found");

            return tierPriceDto;
        }

        public async Task<Entities.Usable.TierPrice> CreateAsync(TierPriceCreateDto tierPriceDto)
        {
            var tierPrice = _mapper.Map<Entities.Usable.TierPrice>(tierPriceDto);

            _context.TierPrices.Add(tierPrice);

            await _context.SaveChangesAsync();

            return tierPrice;
        }

        public async Task<bool> UpdateAsync(TierPriceUpdateDto tierPriceDto)
        {
            var tierPrice = await _context.TierPrices.FirstOrDefaultAsync(p => p.Id == tierPriceDto.Id);

            _mapper.Map(tierPriceDto, tierPrice);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tierPrice = await _context.TierPrices.FirstOrDefaultAsync(p => p.Id == id);

            if (tierPrice == null) throw new NotFoundExceptions($"Tier price with id {id} not found");

            _context.TierPrices.Remove(tierPrice);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
