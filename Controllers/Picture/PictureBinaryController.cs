using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.Picture;
using nopCommerceApi.Services.Picture;

namespace nopCommerceApi.Controllers.Picture
{
    /// <summary>
    /// ## PictureBinaryService Data Transfer Object
    /// </summary>
    [Route("api/picture-binary")]
    [ApiController]
    public class PictureBinaryController : ControllerBase
    {
        private readonly IPictureBinaryService _pictureBinaryService;

        public PictureBinaryController(IPictureBinaryService pictureBinaryService)
        {
            _pictureBinaryService = pictureBinaryService;
        }

        /// <summary>
        /// Get all picture binaries
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var pictureBinaries = await _pictureBinaryService.GetAllAsync();
            return Ok(pictureBinaries);
        }

        /// <summary>
        /// Get picture binary by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var pictureBinary = await _pictureBinaryService.GetByIdAsync(id);
            return Ok(pictureBinary);
        }

        /// <summary>
        /// Create a picture binary
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PictureBinaryCreateDto pictureBinaryCreateDto)
        {
            var pictureBinary = await _pictureBinaryService.CreateAsync(pictureBinaryCreateDto);
            return Created($"api/picture-binary/{pictureBinary.Id}", pictureBinary);
        }

        /// <summary>
        /// Update a picture binary
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PictureBinaryUpdateDto pictureBinaryUpdateDto)
        {
            await _pictureBinaryService.UpdateAsync(pictureBinaryUpdateDto);
            return Ok();
        }

        /// <summary>
        /// Delete a picture binary
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _pictureBinaryService.DeleteAsync(id);
            return Ok();
        }
    }
}

