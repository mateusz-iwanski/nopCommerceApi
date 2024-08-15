using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductPicture;
using nopCommerceApi.Models.UrlRecord;

namespace nopCommerceApi.Validations.ProductPicture
{
    public class ProductPictureMappingBaseDtoValidator<T> : BaseValidator<T> where T : ProductPictureMappingDto
    {
        protected readonly NopCommerceContext _context;

        public ProductPictureMappingBaseDtoValidator(NopCommerceContext context)
        {
            _context = context;

            // check product exists
            RuleFor(x => x.ProductId)
                .Must(productId =>
                {
                    return _context.Products.Any(p => p.Id == productId);
                })
                .WithMessage("The product id is not exists.");

            // check picture exists
            RuleFor(x => x.PictureId)
                .Must(pictureId =>
                {
                    return _context.Pictures.Any(p => p.Id == pictureId);
                })
                .WithMessage("The picture id is not exists.");
            _context = context;                      

            // check display order is greater or equal to 0
            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The display order must be greater or equal to 0.");
        }
    }
}
