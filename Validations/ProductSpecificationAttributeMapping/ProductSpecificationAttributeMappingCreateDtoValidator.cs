using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductSpecificationAttributeMapping;

namespace nopCommerceApi.Validations.ProductSpecificationAttributeMapping
{
    public class ProductSpecificationAttributeMappingCreateDtoValidator : ProductSpecificationAttributeMappingBaseDtoValidator<ProductSpecificationAttributeMappingCreateDto>
    {
        public ProductSpecificationAttributeMappingCreateDtoValidator(NopCommerceContext context) : base(context)
        { 
        }
    }
}
