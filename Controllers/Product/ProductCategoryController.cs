using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models.ProductCategory;
using nopCommerceApi.Services.Category;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Controllers.Product
{
    [Route("api/category/mapping")]
    public class ProductCategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;
        public readonly IProductCategoryMappingService _productCategoryMappingService;

        public ProductCategoryController(IProductCategoryMappingService productCategoryMappingService)
        {
            _productCategoryMappingService = productCategoryMappingService;
        }

        /// <summary>
        /// Get all cateogry with associated products
        /// </summary>
        [HttpGet]
        public IEnumerable<ProductCategoryMappingDto> GetAll()
        {
            var productCategoryMappingDtos = _productCategoryMappingService.GetAll();
            return productCategoryMappingDtos;
        }

        /// <summary>
        /// Associate a product with a category
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] ProductCategoryMappingCreateDto productCategoryMappingCreateDto)
        {
            var productCategoryMapping = _productCategoryMappingService.Create(productCategoryMappingCreateDto);
            return Created($"api/category/mapping/{productCategoryMapping.Id}", productCategoryMapping);
        }

        /// <summary>
        /// Delete association between a product and a category
        /// </summary>
        [HttpDelete("{productId}/{categoryId}")]
        public IActionResult Delete(int productId, int categoryId)
        {
            var result = _productCategoryMappingService.Delete(productId, categoryId);
            return Ok(result);
        }

        /// <summary>
        /// Get all product categories mappings associated with a product
        /// </summary>
        [HttpGet("product/{productId}")]
        public IEnumerable<ProductCategoryMapping> GetAllAssociateWithProduct(int productId)
        {
            var productCategoryMappings = _productCategoryMappingService.GetAllAssociateWithProduct(productId);
            return productCategoryMappings;
        }

        /// <summary>
        /// Get all product categories mappings associated with a category
        /// </summary>
        [HttpGet("category/{categoryId}")]
        public IEnumerable<ProductCategoryMapping> GetAllAssociateWithCategory(int categoryId)
        {
            var productCategoryMappings = _productCategoryMappingService.GetAllAssociateWithCategory(categoryId);
            return productCategoryMappings;
        }
    }
}
