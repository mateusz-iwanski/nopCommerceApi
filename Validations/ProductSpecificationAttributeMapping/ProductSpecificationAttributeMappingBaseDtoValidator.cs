using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductSpecificationAttributeMapping;

namespace nopCommerceApi.Validations.ProductSpecificationAttributeMapping
{
    public class ProductSpecificationAttributeMappingBaseDtoValidator<T> : BaseValidator<T> where T : ProductSpecificationAttributeMappingDto
    {
        protected readonly NopCommerceContext _context;

        public ProductSpecificationAttributeMappingBaseDtoValidator(NopCommerceContext context) : base()
        {
            _context = context;

            // check product id exists
            RuleFor(x => x.ProductId)
                .Must(x => _context.Products.Find(x) != null)
                .WithMessage("Product id does not exist");

            // check specification attribute option id exists
            RuleFor(x => x.SpecificationAttributeOptionId)
                .Must(x => _context.SpecificationAttributes.Find(x) != null)
                .WithMessage("Specification attribute id does not exist");

            // check display order is greater or equal to 0
            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The display order must be greater or equal to 0.");
        }
    }
}
