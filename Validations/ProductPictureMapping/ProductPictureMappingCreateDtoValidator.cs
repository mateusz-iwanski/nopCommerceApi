using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductPicture;

namespace nopCommerceApi.Validations.ProductPicture
{
    public class ProductPictureMappingCreateDtoValidator : ProductPictureMappingBaseDtoValidator<ProductPictureMappingCreateDto>
    {
        public ProductPictureMappingCreateDtoValidator(NopCommerceContext context) : base(context)
        {
            // check if picture and product exists
            RuleFor(x => new { x.ProductId, x.PictureId })
                .Must(x =>
                {
                    return !_context.ProductPictureMappings.Any(pp => pp.ProductId == x.ProductId && pp.PictureId == x.PictureId);
                })
                .WithMessage("The product id with picture id already exists.");
        }
    }
}
