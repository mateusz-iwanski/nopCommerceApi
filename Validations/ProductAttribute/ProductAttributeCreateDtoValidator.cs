using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttribute;

namespace nopCommerceApi.Validations.ProductAttribute
{
    public class ProductAttributeCreateDtoValidator : ProductAttributeDtoBaseValidator<ProductAttributeCreateDto>
    {
        public ProductAttributeCreateDtoValidator(NopCommerceContext context) : base(context)
        {
        }
    }
}
