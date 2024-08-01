using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttribute;

namespace nopCommerceApi.Validations.ProductAttribute
{
    public class CreateProductProductAttributeMappingDtoValidator : ProductProductAttributeMappingDtoBaseValidator<ProductProductAttributeMappingCreateDto>
    {
        public CreateProductProductAttributeMappingDtoValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
        }
    }
}
