using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models.Category;
using nopCommerceApi.Models.ProductCategory;
using nopCommerceApi.Services.Category;

namespace nopCommerceApi.Controllers.Category
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;
        public readonly IProductCategoryMappingService _productCategoryMappingService;

        public CategoryController(ICategoryService categoryService, IProductCategoryMappingService productCategoryMappingService)
        {
            _categoryService = categoryService;
            _productCategoryMappingService = productCategoryMappingService;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        [HttpGet]
        public IEnumerable<CategoryDto> GetAll()
        {
            var categoriesDto = _categoryService.GetAll();
            return categoriesDto;
        }

        /// <summary>
        /// Get category by id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categoryDto = _categoryService.GetById(id);

            return Ok(categoryDto);
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryDto categoryDto)
        {
            var category = _categoryService.Create(categoryDto);
            return Created($"api/category/{ category.Id}", category);
        }

        /// <summary>
        /// Update category 
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateCategoryDto categoryDto)
        {
            var category = _categoryService.Update(id, categoryDto);
            return Ok(category);
        }

        /// <summary>
        /// Delete category
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            return Ok(result);
        }

        /// <summary>
        /// Get all cateogry with associated products
        /// </summary>
        [HttpGet("mapping")]    
        public IEnumerable<ProductCategoryMappingDto> ProductCategoryMappingDtosGetAll()
        {
            var productCategoryMappingDtos = _productCategoryMappingService.GetAll();
            return productCategoryMappingDtos;
        }

        /// <summary>
        /// Associate a product with a category
        /// </summary>
        [HttpPost("mapping")]
        public IActionResult ProductCategoryMappingDtosCreate([FromBody] ProductCategoryMappingCreateDto productCategoryMappingCreateDto)
        {
            var productCategoryMapping = _productCategoryMappingService.Create(productCategoryMappingCreateDto);
            return Created($"api/category/mapping/{productCategoryMapping.Id}", productCategoryMapping);
        }

        /// <summary>
        /// Delete association between a product and a category
        /// </summary>
        [HttpDelete("mapping/{productId}/{categoryId}")]
        public IActionResult ProductCategoryMappingDtosDelete(int productId, int categoryId)
        {
            var result = _productCategoryMappingService.Delete(productId, categoryId);
            return Ok(result);
        }

        /// <summary>
        /// Get all product categories mappings associated with a product
        /// </summary>
        [HttpGet("mapping/product/{productId}")]
        public IEnumerable<ProductCategoryMapping> getAllAssociateWithProduct(int productId)
        {
            var productCategoryMappings = _productCategoryMappingService.GetAllAssociateWithProduct(productId);
            return productCategoryMappings;
        }

        /// <summary>
        /// Get all product categories mappings associated with a category
        /// </summary>
        [HttpGet("mapping/category/{categoryId}")]
        public IEnumerable<ProductCategoryMapping> GetProductCategoryMappings(int categoryId)
        {
            var productCategoryMappings = _productCategoryMappingService.GetAllAssociateWithCategory(categoryId);
            return productCategoryMappings;
        }   
    }
}
