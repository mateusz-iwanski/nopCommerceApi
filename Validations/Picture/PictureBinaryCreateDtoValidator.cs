using FluentValidation;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Picture;

namespace nopCommerceApi.Validations.Picture
{
    public class PictureBinaryCreateDtoValidator : BaseValidator<PictureBinaryCreateDto>
    {
        public PictureBinaryCreateDtoValidator(NopCommerceContext context, IMySettings settings)
        {

            RuleFor(x => x.PictureId)
                .Must(pictureId => context.Pictures.Find(pictureId) != null)
                .WithMessage("Picture does not exist");
        }
    }
}
