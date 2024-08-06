using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductManufacturer;

namespace nopCommerceApi.Validations.ProductManufacturer
{
    public class ProductManufacturerMappingCreateValidator : ProductManufacturerMappingBaseValidator<ProductManufacturerMappingCreateDto>
    {
        public ProductManufacturerMappingCreateValidator(NopCommerceContext context) : base(context)
        {
        }
    }
}
