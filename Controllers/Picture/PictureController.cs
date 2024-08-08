using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Config;
using nopCommerceApi.Models.Picture;
using nopCommerceApi.Services.Picture;

namespace nopCommerceApi.Controllers.Picture
{
    /// <summary>
    /// ## PictureService Data Transfer Object
    /// #### Path to uploadded pictures - nopCommerce\src\Presentation\Nop.Web\wwwroot\images\thumbs\
    /// #### Doc: https://docs.nopcommerce.com/en/getting-started/design-your-store/media-settings.html
    /// #### Settings: Configuration → Settings → Media settings.
    /// #### Every file name should be format like this - for example for product with id 1:
    /// #### 0000001_{product name}.jpeg - (product name with dash) = 0000001_product-name.jpeg
    /// </summary>
    [Route("picture")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IPictureService _pictureService;
        private readonly IMySettings _settings;

        public PictureController(IPictureService pictureService, IMySettings settings)
        {
            _pictureService = pictureService;
            _settings = settings;
        }

        /// <summary>
        /// Gte all pictures
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var pictures = _pictureService.GetAll();
            return Ok(pictures);
        }

        /// <summary>
        /// Get picture by id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var picture = _pictureService.GetById(id);
            return Ok(picture);
        }

        /// <summary>
        /// Create a picture
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] PictureCreateDto pictureCreateDto)
        {
            var picture = _pictureService.Create(pictureCreateDto);
            return Created("pictures", picture);
        }

        /// <summary>
        /// Update a picture
        /// </summary>
        /// <remarks>
        /// Upload file with proper name. Look on GetProperNameForPictureFile.
        /// </remarks>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PictureUpdateDto pictureUpdateDto)
        {
            _pictureService.Update(id, pictureUpdateDto);

            return Ok(pictureUpdateDto);
        }

        /// <summary>
        /// Delete a picture
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pictureService.Delete(id);

            return NoContent();
        }

        /// <summary>
        /// Get proper name for picture file
        /// </summary>
        /// <remarks>
        /// The name should be formatted like this - for example for product with id 1: \
        /// 0000001_{product name}.jpeg - (product name with dash) = 0000001_product-name.jpeg \
        /// Just change the picture name to the proper name. 
        /// </remarks>
        [HttpGet("proper-name/{pictureId}")]
        public IActionResult GetProperNameForPictureFile(int pictureId)
        {
            var properName = _pictureService.ProperNameForPictureFile(pictureId);
            return Ok(properName);
        }

        /// <summary>
        /// Uploads a picture file.
        /// </summary>
        /// <remarks>
        /// The name of file should properly formatted. Look on "/pictures/proper-name/"
        /// </remarks>
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), _settings.ThumbsPath);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var filePath = Path.Combine(uploadPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { filePath });
        }

    }
}
