using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models.Manufacturer;
using nopCommerceApi.Models.Picture;

namespace nopCommerceApi.Validations.Picture
{
    public class PictureBaseDtoValidator<T> : BaseValidator<T> where T : PictureDto
    {
        protected readonly IMySettings _settings;
        protected readonly NopCommerceContext _context;

        public PictureBaseDtoValidator(NopCommerceContext context, IMySettings settings)
        {
            _context = context;
            _settings = settings;

            // check mime type format
            RuleFor(picture => picture.MimeType)
                .NotEmpty().WithMessage("MimeType is required.")
                .Matches(@"^image/[a-zA-Z0-9\-.+]+$").WithMessage("MimeType must start with 'image/' and be valid.");

            // check that SeoFilename has not have whitespaces
            RuleFor(picture => picture.SeoFilename)
                .Matches(@"^[a-zA-Z0-9-_]+$").WithMessage("The SeoFilename is not in proper format. It can't have blank spaces");
        }
    }
}
