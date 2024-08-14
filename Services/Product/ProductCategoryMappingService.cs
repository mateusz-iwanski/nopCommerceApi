using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.ProductCategory;
using nopCommerceApi.Services.Category;

namespace nopCommerceApi.Services.Product
{
    public interface IProductCategoryMappingService
    {
        Task<ProductCategoryMapping> CreateAsync(ProductCategoryMappingCreateDto productCategoryMappingCreateDto);
        Task<bool> DeleteAsync(int productId, int categoryId);
        Task<IEnumerable<ProductCategoryMappingDto>> GetAllAsync();
        Task<IEnumerable<ProductCategoryMapping>> GetAllAssociateWithProductAsync(int productId);
        Task<IEnumerable<ProductCategoryMapping>> GetAllAssociateWithCategoryAsync(int categoryId);
    }

    public class ProductCategoryMappingService : BaseService, IProductCategoryMappingService
    {
        public ProductCategoryMappingService(NopCommerceContext context, IMapper mapper, ILogger<CategoryService> logger) : base(context, mapper, logger) { }

        public async Task<IEnumerable<ProductCategoryMappingDto>> GetAllAsync()
        {
            var productCategoryMappings = await _context.ProductCategoryMappings
                .AsNoTracking()
                .ToListAsync();
            var productCategoryMappingDtos = _mapper.Map<List<ProductCategoryMappingDto>>(productCategoryMappings);

            return productCategoryMappingDtos;
        }

        public async Task<IEnumerable<ProductCategoryMapping>> GetAllAssociateWithProductAsync(int productId)
        {
            var productCategoryMappings = await _context.ProductCategoryMappings
                .AsNoTracking()
                .Where(c => c.ProductId == productId).ToListAsync();

            return productCategoryMappings;
        }

        public async Task<IEnumerable<ProductCategoryMapping>> GetAllAssociateWithCategoryAsync(int categoryId)
        {
            var productCategoryMappings = await _context.ProductCategoryMappings.Where(c => c.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync();

            return productCategoryMappings;
        }

        public async Task<ProductCategoryMapping> CreateAsync(ProductCategoryMappingCreateDto productCategoryMappingCreateDto)
        {
            var productCategoryMappingExist = await _context.ProductCategoryMappings
                .FirstOrDefaultAsync(
                    c => c.ProductId == productCategoryMappingCreateDto.ProductId && c.CategoryId == productCategoryMappingCreateDto.CategoryId
                );

            if (productCategoryMappingExist != null) 
                throw new NotFoundExceptions($"ProductCategoryMapping with category id {productCategoryMappingCreateDto.CategoryId} and product id {productCategoryMappingCreateDto.ProductId} exist.");

            var productCategoryMapping = _mapper.Map<ProductCategoryMapping>(productCategoryMappingCreateDto);

            _context.ProductCategoryMappings.Add(productCategoryMapping);
            await _context.SaveChangesAsync();

            return productCategoryMapping;
        }

        public async Task<bool> DeleteAsync(int productId, int categoryId)
        {
            var productCategoryMapping = await _context.ProductCategoryMappings
                .FirstOrDefaultAsync(c => c.ProductId == productId && c.CategoryId == categoryId);

            if (productCategoryMapping == null) 
                throw new NotFoundExceptions($"ProductCategoryMapping with category id {categoryId} and product id {productId} not found");

            _context.ProductCategoryMappings.Remove(productCategoryMapping);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
