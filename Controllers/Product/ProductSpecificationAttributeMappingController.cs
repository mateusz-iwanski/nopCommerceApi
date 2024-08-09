using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.ProductSpecificationAttributeMapping;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Controllers.Product
{
    /// <summary>
    /// Association between product and specification attribute
    /// </summary>
    [Route("product/specification-attribute/mapping")]
    [ApiController]
    public class ProductSpecificationAttributeMappingController : ControllerBase
    {
        private readonly IProductSpecificationAttributeMappingService _productSpecificationAttributeMappingService;

        public ProductSpecificationAttributeMappingController(IProductSpecificationAttributeMappingService productSpecificationAttributeMappingService)
        {
            _productSpecificationAttributeMappingService = productSpecificationAttributeMappingService;
        }

        /// <summary>
        /// Get all specification attribute associate with a product
        /// </summary>
        /// <remarks>
        /// Get all asscoiation between product and specification attribute
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mappings = await _productSpecificationAttributeMappingService.GetAllAsync();
            return Ok(mappings);
        }

        /// <summary>
        /// Get by specification attribute mapping id 
        /// </summary>
        /// <remarks>
        /// Get asscoiation between product and specification attribute by mapping id
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mapping = await _productSpecificationAttributeMappingService.GetByIdAsync(id);
            return Ok(mapping);
        }

        /// <summary>
        /// Create a new specification attribute association for a product
        /// </summary>
        /// <remarks>
        /// Creating asscoiation between product and specification attribute
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductSpecificationAttributeMappingCreateDto mappingDto)
        {
            var mapping = await _productSpecificationAttributeMappingService.CreateAsync(mappingDto);
            return Created($"product/specification-attribute/mapping/{mapping.Id}", mapping);
        }


        /// <summary>
        /// Delete asscoiation between product and specification attribute
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productSpecificationAttributeMappingService.DeleteAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Update asscoiation between product and specification attribute
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductSpecificationAttributeMappingUpdateDto mappingDto)
        {
            var result = await _productSpecificationAttributeMappingService.UpdateAsync(mappingDto);
            return Ok(result);
        }

        /// <summary>
        /// Get association between product and specification attribute by product id
        /// </summary>
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var mappings = await _productSpecificationAttributeMappingService.GetByProductIdAsync(productId);
            return Ok(mappings);
        }
    }
}
