using nopCommerceApi.Entities;
using nopCommerceApi.Models.Video;

namespace nopCommerceApi.Validations.Video
{
    public class VideoCreateValidator : VideoBaseValidator<VideoCreateDto>
    {
        public VideoCreateValidator(NopCommerceContext context) : base(context)
        {
        }
    }
}
