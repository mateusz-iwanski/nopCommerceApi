using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductSpecificationAttributeMapping;

namespace nopCommerceApi.Validations.ProductSpecificationAttributeMapping
{
    public class ProductSpecificationAttributeMappingUpdateDtoValidator : ProductSpecificationAttributeMappingBaseDtoValidator<ProductSpecificationAttributeMappingUpdateDto>
    {
        public ProductSpecificationAttributeMappingUpdateDtoValidator(NopCommerceContext context) : base(context)
        {
        }
    }
}
