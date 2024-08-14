using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models.ProductCategory;
using nopCommerceApi.Services.Category;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Controllers.Product
{
    [Route("api/category/mapping")]
    [ApiController]
    public class ProductCategoryMappingController : ControllerBase
    {
        public readonly ICategoryService _categoryService;
        public readonly IProductCategoryMappingService _productCategoryMappingService;

        public ProductCategoryMappingController(IProductCategoryMappingService productCategoryMappingService)
        {
            _productCategoryMappingService = productCategoryMappingService;
        }

        /// <summary>
        /// Get all cateogry with associated products
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<ProductCategoryMappingDto>> GetAll()
        {
            var productCategoryMappingDtos = await _productCategoryMappingService.GetAllAsync();
            return productCategoryMappingDtos;
        }

        /// <summary>
        /// Associate a product with a category
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCategoryMappingCreateDto productCategoryMappingCreateDto)
        {
            var productCategoryMapping = await _productCategoryMappingService.CreateAsync(productCategoryMappingCreateDto);
            return Created($"api/category/mapping/{productCategoryMapping.Id}", productCategoryMapping);
        }

        /// <summary>
        /// Delete association between a product and a category
        /// </summary>
        [HttpDelete("{productId}/{categoryId}")]
        public async Task<IActionResult> Delete(int productId, int categoryId)
        {
            _productCategoryMappingService.DeleteAsync(productId, categoryId);
            return Ok();
        }

        /// <summary>
        /// Get all product categories mappings associated with a product
        /// </summary>
        [HttpGet("product/{productId}")]
        public async Task<IEnumerable<ProductCategoryMapping>> GetAllAssociateWithProduct(int productId)
        {
            var productCategoryMappings = await _productCategoryMappingService.GetAllAssociateWithProductAsync(productId);
            return productCategoryMappings;
        }

        /// <summary>
        /// Get all product categories mappings associated with a category
        /// </summary>
        [HttpGet("category/{categoryId}")]
        public async Task<IEnumerable<ProductCategoryMapping>> GetAllAssociateWithCategory(int categoryId)
        {
            var productCategoryMappings = await _productCategoryMappingService.GetAllAssociateWithCategoryAsync(categoryId);
            return productCategoryMappings;
        }
    }
}
