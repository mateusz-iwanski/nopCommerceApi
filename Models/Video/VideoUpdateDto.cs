using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Video
{
    public class VideoUpdateDto : VideoDto
    {
        [Required]
        public override int Id { get; set; }
    }
}
