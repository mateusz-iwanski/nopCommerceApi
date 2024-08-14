using FluentValidation;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttributeValue;

namespace nopCommerceApi.Validations.ProductAttributeValue
{
    public class ProductAttributeValueUpdateDtoValidator : ProductAttributeValueDtoBaseValidator<ProductAttributeValueUpdateDto>
    {
        public ProductAttributeValueUpdateDtoValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
            // check if product attribute value exists by id
            RuleFor(x => x.Id)
                .Must((id) => context.ProductAttributeValues.Any(p => p.Id == id))
                .WithMessage("Product attribute value does not exist.");            
        }
    }
}
