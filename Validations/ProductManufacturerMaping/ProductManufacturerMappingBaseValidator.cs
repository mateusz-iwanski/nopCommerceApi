using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models.ProductCategory;
using nopCommerceApi.Models.ProductManufacturer;

namespace nopCommerceApi.Validations.ProductManufacturer
{
    public class ProductManufacturerMappingBaseValidator<T> : BaseValidator<T> where T : ProductManufacturerMappingDto
    {
        protected readonly NopCommerceContext _context;

        public ProductManufacturerMappingBaseValidator(NopCommerceContext context)
        {
            _context = context;

            // check manufacturer id exists
            RuleFor(x => x.ManufacturerId)
                .Must(manufacturerId => _context.Manufacturers.Any(c => c.Id == manufacturerId))
                .WithMessage("The manufacturer does not exist.");

            // check product id exists
            RuleFor(x => x.ProductId)
                .Must(productId => _context.Products.Any(c => c.Id == productId))
                .WithMessage("The product does not exist.");
        }
    }
}
