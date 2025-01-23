using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models.Category;
using nopCommerceApi.Models.ProductCategory;
using nopCommerceApi.Services.Category;
using nopCommerceApi.Services.Product;

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
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categoriesDto = await _categoryService.GetAllAsync();
            return categoriesDto;
        }

        /// <summary>
        /// Get category by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoryDto = await _categoryService.GetByIdAsync(id);

            return Ok(categoryDto);
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto categoryDto)
        {
            var category = await _categoryService.CreateAsync(categoryDto);
            return Created($"api/category/{ category.Id}", category);
        }

        /// <summary>
        /// Update category 
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateDto categoryDto)
        {
            var category = await _categoryService.UpdateAsync(categoryDto);
            return Ok(category);
        }

        /// <summary>
        /// Delete category
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return Ok();
        }        
    }
}
