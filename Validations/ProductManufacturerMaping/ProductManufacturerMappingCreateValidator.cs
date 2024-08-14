using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductManufacturer;

namespace nopCommerceApi.Validations.ProductManufacturer
{
    public class ProductManufacturerMappingCreateValidator : ProductManufacturerMappingBaseValidator<ProductManufacturerMappingCreateDto>
    {
        public ProductManufacturerMappingCreateValidator(NopCommerceContext context) : base(context)
        {
            // manufacturer id and product id should be just one
            RuleFor(x => new { x.ManufacturerId, x.ProductId })
                .Must(x => !_context.ProductManufacturerMappings
                .Any(pm => pm.ProductId == x.ProductId && pm.ManufacturerId == x.ManufacturerId))
                .WithMessage("ProductManufacturerMapping exists with product id and manufacturer id");
        }
    }
}
