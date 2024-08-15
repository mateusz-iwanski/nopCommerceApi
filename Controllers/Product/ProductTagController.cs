using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.ProductTag;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Controllers.Product
{
    [Route("api/product/tag")]
    [ApiController]
    public class ProductTagController : ControllerBase
    {
        private readonly IProductTagService _productTagService;

        public ProductTagController(IProductTagService productService)
        {
            _productTagService = productService;
        }

        // GET: api/product/tag
        /// <summary>
        /// Get all product tags
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<ProductTagDto>> GetAll()
        {
            var productsTagto = await _productTagService.GetAllAsync();
            return productsTagto;
        }

        // GET: api/product/tag/details
        /// <summary>
        /// Get all product tags with details
        /// </summary>
        [HttpGet("details")]
        public async Task<IEnumerable<ProductTagDto>> GetAllDetails()
        {
            var productsTagto = await _productTagService.GetAllDetailsAsync();
            return productsTagto;
        }


        // GET: api/product/tag/by-name/tag_name
        /// <summary>
        /// Get all product tags by tag name
        /// </summary>
        /// <remarks>
        /// Search name that contains the tag name
        /// </remarks>
        [HttpGet("by-name/{name}")]
        public async Task<IEnumerable<ProductTagDto>> GetByTag(string name)
        {
            var productsDto = await _productTagService.GetByTagAsync(name);
            return productsDto;
        }

        // GET: api/product/tag/5
        /// <summary>
        /// Get product tag by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productDto = await _productTagService.GetByIdAsync(id);

            return Ok(productDto);
        }

        // POST: api/product/tag
        /// <summary>
        /// Create a new product tag
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductTagCreateDto productTagDto)
        {
            var productTag = await _productTagService.CreateAsync(productTagDto);
            return Created($"api/product/{productTag.Id}", productTagDto);
        }

        // PUT: api/product/tag/5
        /// <summary>
        /// Update a product tag
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductTagUpdateDto productTagDto)
        {
            await _productTagService.UpdateAsync(productTagDto);
            return Ok();
        }

        // DELETE: api/product/tag/5
        /// <summary>
        /// Delete a product tag
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productTag = await _productTagService.DeleteAsync(id);
            return Ok(productTag);
        }

    }
}
