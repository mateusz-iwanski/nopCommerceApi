using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttributeValue;

namespace nopCommerceApi.Validations.ProductAttributeValue
{
    public class ProductAttributeValueUpdateDtoValidator : ProductAttributeValueDtoBaseValidator<ProductAttributeValueDtoCreate>
    {
        public ProductAttributeValueUpdateDtoValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
        }
    }
}
