using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.ProductVideo;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Controllers.Product
{
    /// <summary>
    /// Associate product videos with products
    /// </summary>
    [Route("api/product/videos")]
    [ApiController]
    public class ProductVideoController : ControllerBase
    {
        private readonly IProductVideoService _productVideoService;

        public ProductVideoController(IProductVideoService productVideoService)
        {
            _productVideoService = productVideoService;
        }

        /// <summary>
        /// Get all product videos association
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productVideos = await _productVideoService.GetAll();

            return Ok(productVideos);
        }

        /// <summary>
        /// Get product video association by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productVideo = await _productVideoService.GetById(id);

            return Ok(productVideo);
        }

        /// <summary>
        /// Get product video association by video id
        /// </summary>
        [HttpGet("video/{videoId}")]
        public async Task<IActionResult> GetByVideoId(int videoId)
        {
            var productVideo = await _productVideoService.GetByVideoId(videoId);

            return Ok(productVideo);
        }

        /// <summary>
        /// Get product video association by product id
        /// </summary>
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var productVideo = await _productVideoService.GetByProductId(productId);

            return Ok(productVideo);
        }

        /// <summary>
        /// Create product video association
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductVideoCreateDto productVideoCreateDto)
        {
            var productVideo = await _productVideoService.Create(productVideoCreateDto);

            return Created($"api/product/videos/{productVideo.Id}", productVideo);
        }

        /// <summary>
        /// Update product video association
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductVideoUpdateDto productVideoUpdateDto)
        {
            var result = await _productVideoService.Update(productVideoUpdateDto);

            return Ok(result);
        }

        /// <summary>
        /// Delete product video association
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productVideoService.Delete(id);

            return Ok(result);
        }

    }
}
