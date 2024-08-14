using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.ProductAvailabilityRange;

namespace nopCommerceApi.Services.Product
{
    public interface IProductAvailabilityRangeService
    {
        Task<ProductAvailabilityRange> CreateAsync(ProductAvailabilityRangeCreateDto productAvailabilityRangeDto);
        Task<IEnumerable<ProductAvailabilityRangeDto>> GetAllAsync();
        Task<ProductAvailabilityRangeDto> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }

    public class ProductAvailabilityRangeService : BaseService, IProductAvailabilityRangeService
    {
        public ProductAvailabilityRangeService(NopCommerceContext context, IMapper mapper, ILogger<ProductAvailabilityRangeService> logger)
            : base(context, mapper, logger)
        {
        }

        public async Task<IEnumerable<ProductAvailabilityRangeDto>> GetAllAsync()
        {
            var productAvailabilityRanges = await _context.ProductAvailabilityRanges
                .AsNoTracking()
                .ToListAsync();
            var productAvailabilityRangeDtos = _mapper.Map<List<ProductAvailabilityRangeDto>>(productAvailabilityRanges);

            return productAvailabilityRangeDtos;
        }

        public async Task<ProductAvailabilityRangeDto> GetByIdAsync(int id)
        {
            var productAvailabilityRanges = await _context.ProductAvailabilityRanges
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            var productAvailabilityRangeDto = productAvailabilityRanges != null ? 
                _mapper.Map<ProductAvailabilityRangeDto>(productAvailabilityRanges) : 
                throw new NotFoundExceptions($"ProductAvailabilityRange with id {id} not found");

            return productAvailabilityRangeDto;
        }

        public async Task<ProductAvailabilityRange> CreateAsync(ProductAvailabilityRangeCreateDto productAvailabilityRangeDto)
        {
            var productAvailabilityRange = _mapper.Map<ProductAvailabilityRange>(productAvailabilityRangeDto);

            productAvailabilityRange.DisplayOrder = await GetLastDisplayOrderAsync() + 1;

            _context.ProductAvailabilityRanges.Add(productAvailabilityRange);
            await _context.SaveChangesAsync();

            return productAvailabilityRange;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var productAvailabilityRange = await _context.ProductAvailabilityRanges.FirstOrDefaultAsync(p => p.Id == id);

            if (productAvailabilityRange == null)
            {
                throw new NotFoundExceptions($"ProductAvailabilityRange with id {id} not found");
            }

            _context.ProductAvailabilityRanges.Remove(productAvailabilityRange);
            await _context.SaveChangesAsync();

            return true;
        }

        private async Task<int> GetLastDisplayOrderAsync()
        {
            var lastDisplayOrder = await _context.ProductAvailabilityRanges
                .AsNoTracking()
                .MaxAsync(x => x.DisplayOrder);

            if (lastDisplayOrder != null)
            {
                return lastDisplayOrder;
            }
            else return 0;
        }
    }
}
