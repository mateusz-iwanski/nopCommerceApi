using FluentValidation;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Validations
{
    public class ProductUpdateBlockAttributeDtoValidator : BaseValidator<ProductUpdateBlockAttributeDto>
    {
        public ProductUpdateBlockAttributeDtoValidator() : base()
        {
            // check product exists
            RuleFor(x => x.Id)
                .Must(id => id > 0)
        }
    }
}
