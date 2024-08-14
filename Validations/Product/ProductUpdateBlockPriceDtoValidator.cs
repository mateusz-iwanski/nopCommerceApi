using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Validations
{
    public class ProductUpdateBlockPriceDtoValidator : BaseValidator<ProductUpdateBlockPriceDto>
    {
        private readonly NopCommerceContext _context;

        public ProductUpdateBlockPriceDtoValidator(NopCommerceContext context) : base()
        {
            _context = context;

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.OldPrice)
                .GreaterThanOrEqualTo(0).WithMessage("OldPrice must be greater or equal 0.");

            RuleFor(x => x.ProductCost)
                .GreaterThanOrEqualTo(0).WithMessage("ProductCost must be greater or equal 0.");

            
            // TaxCategory has to exist
            RuleFor(x => x.TaxCategoryId)
                .Must((taxCategoryId) =>
                {
                    return _context.TaxCategories.Any(c => c.Id == taxCategoryId);
                })
                .WithMessage("The tax category does not exist.");


            
            
        }
    }
}
