using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Models.ProductPicture;
using nopCommerceApi.Models.Video;

namespace nopCommerceApi.Validations.Video
{
    public class VideoBaseValidator<T> : BaseValidator<T> where T : VideoDto
    {
        protected readonly NopCommerceContext _context;

        public VideoBaseValidator(NopCommerceContext context)
        {
            _context = context;

            // check video url is unique
            RuleFor(x => x.VideoUrl)
                .Must(ValidateVideoUrl)
                .WithMessage("The video url already exists.");

            // check video url
            RuleFor(x => x.VideoUrl)
                .Matches(@"^(https?\:\/\/)?(www\.)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,}(\/\S*)?$")
                .WithMessage("The video url is not valid.");
        }

        protected virtual bool ValidateVideoUrl(T instance, string videoUrl)
        {
            return !_context.Videos.Any(v => v.VideoUrl == videoUrl);
        }
    }
}
