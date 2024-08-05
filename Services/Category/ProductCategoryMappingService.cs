using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.ProductCategory;

namespace nopCommerceApi.Services.Category
{
    public interface IProductCategoryMappingService
    {
        ProductCategoryMapping Create(ProductCategoryMappingCreateDto productCategoryMappingCreateDto);
        bool Delete(int productId, int categoryId);
        IEnumerable<ProductCategoryMappingDto> GetAll();
        IEnumerable<ProductCategoryMapping> GetAllAssociateWithProduct(int productId);
        public IEnumerable<ProductCategoryMapping> GetAllAssociateWithCategory(int categoryId);
        ProductCategoryMapping Update(int id, ProductCategoryMappingUpdateDto productCategoryMappingUpdateDto);
    }

    public class ProductCategoryMappingService : BaseService, IProductCategoryMappingService
    {
        public ProductCategoryMappingService(NopCommerceContext context, IMapper mapper, ILogger<CategoryService> logger) : base(context, mapper, logger) { }


        public IEnumerable<ProductCategoryMappingDto> GetAll()
        {
            var productCategoryMappings = _context.ProductCategoryMappings.ToList();
            var productCategoryMappingDtos = _mapper.Map<List<ProductCategoryMappingDto>>(productCategoryMappings);

            return productCategoryMappingDtos;
        }

        public IEnumerable<ProductCategoryMapping> GetAllAssociateWithProduct(int productId)
        {
            var productCategoryMappings = _context.ProductCategoryMappings.Where(c => c.ProductId == productId).ToList();

            return productCategoryMappings;
        }

        public IEnumerable<ProductCategoryMapping> GetAllAssociateWithCategory(int categoryId)
        {
            var productCategoryMappings = _context.ProductCategoryMappings.Where(c => c.CategoryId == categoryId).ToList();

            return productCategoryMappings;
        }

        public ProductCategoryMapping Create(ProductCategoryMappingCreateDto productCategoryMappingCreateDto)
        {
            var productCategoryMappingExist = _context.ProductCategoryMappings.FirstOrDefault(c => c.ProductId == productCategoryMappingCreateDto.ProductId && c.CategoryId == productCategoryMappingCreateDto.CategoryId);

            if (productCategoryMappingExist != null) throw new NotFoundExceptions($"ProductCategoryMapping with category id {productCategoryMappingCreateDto.CategoryId} and product id {productCategoryMappingCreateDto.ProductId} exist.");

            var productCategoryMapping = _mapper.Map<ProductCategoryMapping>(productCategoryMappingCreateDto);

            _context.ProductCategoryMappings.Add(productCategoryMapping);
            _context.SaveChanges();

            return productCategoryMapping;
        }

        public bool Delete(int productId, int categoryId)
        {
            var productCategoryMapping = _context.ProductCategoryMappings.FirstOrDefault(c => c.ProductId == productId && c.CategoryId == categoryId);

            if (productCategoryMapping == null) throw new NotFoundExceptions($"ProductCategoryMapping with category id {categoryId} and product id {productId} not found");

            _context.ProductCategoryMappings.Remove(productCategoryMapping);
            _context.SaveChanges();

            return true;
        }

        public ProductCategoryMapping Update(int id, ProductCategoryMappingUpdateDto productCategoryMappingUpdateDto)
        {
            var productCategoryMapping = _context.ProductCategoryMappings.FirstOrDefault(c => c.Id == id);

            if (productCategoryMapping == null) throw new NotFoundExceptions($"ProductCategoryMapping with id {id} not found");

            productCategoryMappingUpdateDto.Id = id;

            _mapper.Map<ProductCategoryMapping>(productCategoryMappingUpdateDto);

            _context.SaveChanges();

            return productCategoryMapping;
        }
    }
}
