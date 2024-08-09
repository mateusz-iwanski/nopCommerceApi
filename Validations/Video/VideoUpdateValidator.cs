using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Video;

namespace nopCommerceApi.Validations.Video
{
    public class VideoUpdateValidator : VideoBaseValidator<VideoUpdateDto>
    {
        public VideoUpdateValidator(NopCommerceContext context) : base(context)
        {            
        }
        protected override bool ValidateVideoUrl(VideoUpdateDto instance, string videoUrl)
        {
            return !_context.Videos.Any(v => v.VideoUrl == videoUrl && v.Id != instance.Id);
        }
    }
}
