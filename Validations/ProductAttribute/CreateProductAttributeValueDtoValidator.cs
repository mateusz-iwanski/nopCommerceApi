using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttribute;

namespace nopCommerceApi.Validations.ProductAttribute
{
    public class CreateProductAttributeValueDtoValidator : ProductAttributeValueDtoBaseValidator<ProductAttributeValueDtoCreate>
    {
        public CreateProductAttributeValueDtoValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
        }
    }
}
