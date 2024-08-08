using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductPicture;

namespace nopCommerceApi.Validations.ProductPicture
{
    public class ProductPictureMappingUpdateDtoValidator : ProductPictureMappingBaseDtoValidator<ProductPictureMappingUpdateDto>
    {
        public ProductPictureMappingUpdateDtoValidator(NopCommerceContext context)
            : base(context)
        {
        }
    }
}
