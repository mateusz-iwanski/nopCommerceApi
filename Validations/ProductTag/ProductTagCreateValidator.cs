using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductTag;

namespace nopCommerceApi.Validations.ProductTag
{
    public class ProductTagCreateValidator : ProductTagBaseValidator<ProductTagCreateDto>
    {
        public ProductTagCreateValidator(NopCommerceContext context) : base(context)
        {
        }
    }
}
