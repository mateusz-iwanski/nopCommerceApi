using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttribute;

namespace nopCommerceApi.Validations.ProductAttribute
{
    public class UpdateProductAttributeValueDtoValidator : ProductAttributeValueDtoBaseValidator<ProductAttributeValueDtoCreate>
    {
        public UpdateProductAttributeValueDtoValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
        }
    }
}
