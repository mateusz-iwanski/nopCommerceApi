using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttributeValue;

namespace nopCommerceApi.Validations.ProductAttribute
{
    public class CreateProductAttributeValueDtoValidator : ProductAttributeValueDtoBaseValidator<ProductAttributeValueDtoCreate>
    {
        public CreateProductAttributeValueDtoValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
        }
    }
}
