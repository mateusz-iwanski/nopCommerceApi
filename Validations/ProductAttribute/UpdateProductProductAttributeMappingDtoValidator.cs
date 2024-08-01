using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttribute;

namespace nopCommerceApi.Validations.ProductAttribute
{
    public class UpdateProductProductAttributeMappingDtoValidator : ProductProductAttributeMappingDtoBaseValidator<ProductProductAttributeMappingUpdateDto>
    {
        public UpdateProductProductAttributeMappingDtoValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
        }
    }
}
