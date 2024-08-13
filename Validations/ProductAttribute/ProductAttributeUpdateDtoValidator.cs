using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttribute;

namespace nopCommerceApi.Validations.ProductAttribute
{
    public class ProductAttributeUpdateDtoValidator : ProductAttributeDtoBaseValidator<ProductAttributeUpdateDto>
    {
        public ProductAttributeUpdateDtoValidator(NopCommerceContext context) : base(context)
        {
            // check it the product attribute exists
            RuleFor(x => x.Id)
            .Must(id =>
            {
                var productAttribute = _context.ProductAttributes.Find(id);
                return productAttribute != null;

            }).WithMessage("Product attribute not found");
        }
    }
}
