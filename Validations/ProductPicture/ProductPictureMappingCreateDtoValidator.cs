using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductPicture;

namespace nopCommerceApi.Validations.ProductPicture
{
    public class ProductPictureMappingCreateDtoValidator : ProductPictureMappingBaseDtoValidator<ProductPictureMappingCreateDto>
    {
        public ProductPictureMappingCreateDtoValidator(NopCommerceContext context) : base(context)
        {
        }
    }
}
