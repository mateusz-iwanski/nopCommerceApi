using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Validations
{
    public class ProductCreateMinimalValidator : BaseValidator<ProductCreateMinimalDto>
    {
        private readonly NopCommerceContext _context;

        public ProductCreateMinimalValidator(NopCommerceContext context) : base()
        {
            _context = context;

            // Price can't be 0
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.Weight)
                .GreaterThanOrEqualTo(0).WithMessage("Weight must be greater or equal 0.");

            RuleFor(x => x.Length)
                .GreaterThanOrEqualTo(0).WithMessage("Length must be greater or equal 0.");

            RuleFor(x => x.Width)
                .GreaterThanOrEqualTo(0).WithMessage("Width must be greater or equal 0.");

            RuleFor(x => x.Height)
                .GreaterThanOrEqualTo(0).WithMessage("Height must be greater or equal 0.");

            // TaxCategory has to exist
            RuleFor(x => x.TaxCategoryId)
                .Must((taxCategoryId) =>
                {
                    return _context.TaxCategories.Any(c => c.Id == taxCategoryId);
                })
                .WithMessage("The tax category does not exist.");
            _context = context;
        }
    }
}
