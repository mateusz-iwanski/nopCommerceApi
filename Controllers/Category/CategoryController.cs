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
    }
}
