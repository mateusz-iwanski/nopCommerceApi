using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.TaxCategory;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Services
{
    public interface ITaxCategoryService
    {
        Task<IEnumerable<TaxCategoryDto>> GetAll();
        Task<int> GetLastDisplayOrder();
        Task<TaxCategoryDto> GetByNameAsync(string name);
    }

    public class TaxCategoryService : BaseService, ITaxCategoryService
    {
        public TaxCategoryService(NopCommerceContext context, IMapper mapper, ILogger<ProductService> logger)
            : base(context, mapper, logger)
        {
        }

        public async Task<IEnumerable<TaxCategoryDto>> GetAll()
        {
            var taxCategories = await _context.TaxCategories.ToListAsync();
            var taxCategoryDtos = _mapper.Map<List<TaxCategoryDto>>(taxCategories);

            return taxCategoryDtos;
        }

        /// <summary>
        /// Get last display order number
        /// </summary>
        public async Task<int> GetLastDisplayOrder()
        {
            var lastTaxCategory = await _context.TaxCategories.OrderByDescending(d => d.DisplayOrder).FirstOrDefaultAsync();

            if (lastTaxCategory == null)
            {
                return 0;
            }

            return lastTaxCategory.DisplayOrder;
        }

        /// <summary>
        /// Get tax category by name
        /// </summary>
        public async Task<TaxCategoryDto> GetByNameAsync(string name)
        {
            var taxCategory = await _context.TaxCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Name == name);

            if (taxCategory == null) throw new NotFoundExceptions($"TaxCategory with name {name} not found.");

            var taxCategoryDto = _mapper.Map<TaxCategoryDto>(taxCategory);

            return taxCategoryDto;
        }

    }
}
