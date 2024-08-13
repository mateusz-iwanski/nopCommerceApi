using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttributeMapping;

namespace nopCommerceApi.Validations.ProductAttributeMapping
{
    public class ProductProductAttributeMappingUpdateDtoValidator : ProductProductAttributeMappingDtoBaseValidator<ProductProductAttributeMappingUpdateDto>
    {
        public ProductProductAttributeMappingUpdateDtoValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
        }
    }
}
