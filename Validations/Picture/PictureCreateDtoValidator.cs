using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Picture;

namespace nopCommerceApi.Validations.Picture
{
    public class PictureCreateDtoValidator : PictureBaseDtoValidator<PictureCreateDto>
    {
        public PictureCreateDtoValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
            // check picture name is unique
            //RuleFor(x => x.SeoFilename)
            //    .Must(name => context.Pictures.Any(p => p.SeoFilename == name) == false)
            //    .WithMessage("Picture SEO file name already exists in the database. Must be unique.");
        }
    }
}
