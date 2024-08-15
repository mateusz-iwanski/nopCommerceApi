using FluentValidation;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductPicture;

namespace nopCommerceApi.Validations.ProductPicture
{
    public class ProductPictureMappingUpdateDtoValidator : ProductPictureMappingBaseDtoValidator<ProductPictureMappingUpdateDto>
    {
        public ProductPictureMappingUpdateDtoValidator(NopCommerceContext context)
            : base(context)
        {
            // check if picture and product exists, exclude updated entity
            RuleFor(x => new { x.ProductId, x.PictureId, x.Id })
            .Must(x =>
            {
                    return !_context.ProductPictureMappings.Any(pp => pp.ProductId == x.ProductId && pp.PictureId == x.PictureId && x.Id != pp.Id);
                })
                .WithMessage("The product id with picture id already exists.");
        }
    }
}
