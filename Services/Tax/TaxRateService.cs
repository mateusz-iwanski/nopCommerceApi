using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Tax;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Services.Tax
{
    public interface ITaxRateService
    {
        Task<IEnumerable<TaxRateDto>> GetAllAsync();
        Task<TaxRateDto> GetByIdAsync(int id);
        Task<IEnumerable<TaxRateDto>> GetByPercentageAsync(decimal percentage);
        Task<IEnumerable<TaxRateDto>> GetByTaxCategoryIdAsync(int taxCategoryId);
    }

    public class TaxRateService : BaseService, ITaxRateService
    {
        public TaxRateService(NopCommerceContext context, IMapper mapper, ILogger<ProductService> logger)
            : base(context, mapper, logger)
        {
        }

        public async Task<IEnumerable<TaxRateDto>> GetAllAsync()
        {
            var taxRates = await _context.TaxRates
                .AsNoTracking()
                .ToListAsync();

            var taxRateDtos = _mapper.Map<List<TaxRateDto>>(taxRates);

            return taxRateDtos;
        }

        public async Task<TaxRateDto> GetByIdAsync(int id)
        {
            var taxRate = await _context.TaxRates
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

            if (taxRate == null) throw new NotFoundExceptions($"TaxRate with id {id} not found.");

            var taxRateDto = _mapper.Map<TaxRateDto>(taxRate);

            return taxRateDto;
        }

        public async Task<IEnumerable<TaxRateDto>> GetByPercentageAsync(decimal percentage)
        {
            var taxRate = await _context.TaxRates
                .AsNoTracking()
                .Where(t => t.Percentage == percentage)
                .ToListAsync(); 

            if (taxRate == null) throw new NotFoundExceptions($"TaxRate with percentage {percentage} not found.");

            var taxRateDto = _mapper.Map<List<TaxRateDto>>(taxRate);

            return taxRateDto;
        }

        public async Task<IEnumerable<TaxRateDto>> GetByTaxCategoryIdAsync(int taxCategoryId)
        {
            var taxRate = await _context.TaxRates
                .AsNoTracking()
                .Where(t => t.TaxCategoryId == taxCategoryId)
                .ToListAsync();

            if (taxRate == null) throw new NotFoundExceptions($"TaxRate with TaxCategoryId {taxCategoryId} not found.");

            var taxRateDto = _mapper.Map<List<TaxRateDto>>(taxRate);

            return taxRateDto;
        }


    }
}
