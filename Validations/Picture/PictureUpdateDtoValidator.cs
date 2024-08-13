using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Manufacturer;
using nopCommerceApi.Models.Picture;

namespace nopCommerceApi.Validations.Picture
{
    public class PictureUpdateDtoValidator : PictureBaseDtoValidator<PictureUpdateDto>
    {
        public PictureUpdateDtoValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
            // check picture exists
            RuleFor(x => x.Id)
                .Must(id => context.Pictures.Find(id) != null)
                .WithMessage("Picture does not exist");

            // check picture name is unique, exclude updated picture
            RuleFor(x => x.SeoFilename)
                .Must((dto, name) => context.Pictures.Any(p => p.SeoFilename == name && p.Id != dto.Id) == false)
                .WithMessage("Picture SEO file name already exists in the database. Must be unique.");
        }
    }
}
