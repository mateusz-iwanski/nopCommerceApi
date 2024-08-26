using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.Video;
using nopCommerceApi.Services;
using nopCommerceApi.Services.Video;

namespace nopCommerceApi.Controllers.Video
{
    [Route("api/video")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        /// <summary>
        /// Get all videos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var videos = await _videoService.GetAll();
            return Ok(videos);
        }

        /// <summary>
        /// Get video by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var video = await _videoService.GetById(id);
            return Ok(video);
        }

        /// <summary>
        /// Get video by url
        /// </summary>
        [HttpGet("url/{url}")]
        public async Task<IActionResult> GetByUrl(string url)
        {
            var video = await _videoService.GetByUrl(url);
            return Ok(video);
        }

        /// <summary>
        /// Update video
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(VideoUpdateDto updateVideoDto)
        {
            var video = await _videoService.Update(updateVideoDto);
            return Ok(video);
        }

        /// <summary>
        /// Create video
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(VideoCreateDto createVideoDto)
        {
            var video = await _videoService.Create(createVideoDto);
            return Ok(video);
        }

        /// <summary>
        /// Delete video
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _videoService.Delete(id);
            return Ok(result);
        }
    }
}
