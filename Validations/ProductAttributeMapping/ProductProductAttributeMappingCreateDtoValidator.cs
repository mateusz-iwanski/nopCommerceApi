using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttributeMapping;

namespace nopCommerceApi.Validations.ProductAttributeMapping
{
    public class ProductProductAttributeMappingCreateDtoValidator : ProductProductAttributeMappingDtoBaseValidator<ProductProductAttributeMappingCreateDto>
    {
        public ProductProductAttributeMappingCreateDtoValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
        }
    }
}
