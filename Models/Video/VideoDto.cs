using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Video
{
    public class VideoDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## VideoUrl
        /// ### Gets or sets the video URL
        /// </summary>
        [Required]
        public virtual string VideoUrl { get; set; }
    }
}
