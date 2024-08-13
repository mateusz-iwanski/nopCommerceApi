using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.ProductPicture;
using nopCommerceApi.Services.Picture;

namespace nopCommerceApi.Controllers.Product
{

    /// <summary>
    /// Associate product with picture
    /// </summary>
    [Route("picture/mapping")]
    [ApiController]
    public class ProductPictureController : ControllerBase
    {
        private readonly IProductPictureMappingService _productPictureMappingService;

        public ProductPictureController(IProductPictureMappingService productPictureMappingService)
        {
            _productPictureMappingService = productPictureMappingService;
        }

        /// <summary>
        /// Get all product-picture associations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mappings = await _productPictureMappingService.GetAll();
            return Ok(mappings);
        }

        /// <summary>
        /// Create association between product and picture
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductPictureMappingCreateDto mappingDto)
        {
            var mapping = await _productPictureMappingService.Create(mappingDto);
            return Created($"picture/mapping/{mapping.Id}", mapping);
        }

        /// <summary>
        /// Delete association between product and picture
        /// </summary>
        /// <remarks>
        /// If you delete data from database, you should remove picture from nopCommerce picture/thumb directory
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productPictureMappingService.Delete(id);
            return Ok(result);
        }

        /// <summary>
        /// Get association between product and picture by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mapping = await _productPictureMappingService.GetById(id);
            return Ok(mapping);
        }

        /// <summary>
        /// Update association between product and picture
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductPictureMappingUpdateDto mappingDto)
        {
            var mapping = await _productPictureMappingService.Update(id, mappingDto);
            return Ok(mapping);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var mappings = await _productPictureMappingService.GetByProductId(productId);
            return Ok(mappings);
        }

    }
}
