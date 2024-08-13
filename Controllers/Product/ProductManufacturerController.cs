using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.ProductManufacturer;
using nopCommerceApi.Services.Manufacturer;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Controllers.Product
{
    [Route("api/manufacturer/mapping")]
    [ApiController]
    public class ProductManufacturerController : ControllerBase
    {
        private readonly IProductManufaturerMappingService _productManufaturerMappingService;

        public ProductManufacturerController(IManufacturerService manufacturerService, IProductManufaturerMappingService productManufaturerMappingService)
        {
            _productManufaturerMappingService = productManufaturerMappingService;
        }

        /// <summary>
        /// Get all manufacturers associate with products
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mappings = await _productManufaturerMappingService.GetAllAsync();
            return Ok(mappings);
        }

        /// <summary>
        /// Associate product with manufacturer
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductManufacturerMappingCreateDto mappingDto)
        {
            var mapping = await _productManufaturerMappingService.CreateAsync(mappingDto);
            return Created($"api/manufacturer/mapping/{mapping.Id}", mapping);
        }

        /// <summary>
        /// Delete association between product and manufacturer
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productManufaturerMappingService.DeleteAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Get association between product and manufacturer by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mapping = await _productManufaturerMappingService.GetByIdAsync(id);
            return Ok(mapping);
        }

        /// <summary>
        /// Get association between product and manufacturer by manufacturer id
        /// </summary>
        [HttpGet("manufacturer/{manufaturerId}")]
        public async Task<IActionResult> GetByManufacturerId(int manufacturerId)
        {
            var mappings = await _productManufaturerMappingService.GetByManufacturerId(manufacturerId);
            return Ok(mappings);
        }

        /// <summary>
        /// Get association between product and manufacturer by product id
        /// </summary>
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var mappings = await _productManufaturerMappingService.GetByProductId(productId);
            return Ok(mappings);
        }
    }
}
