using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.SpecificationAttribute;

namespace nopCommerceApi.Validations.SpecificationAttributeOption
{
    public class SpecificationAttributeOptionBaseDtoValidator<T> : BaseValidator<T> where T : SpecificationAttributeOptionDto
    {
        private readonly NopCommerceContext _context;

        public SpecificationAttributeOptionBaseDtoValidator(NopCommerceContext context)
        {
            _context = context;

            // check specification attribute exists
            RuleFor(x => x.SpecificationAttributeId)
                .Must(specificationAttributeId =>
                {
                    return _context.SpecificationAttributes.Any(sa => sa.Id == specificationAttributeId);
                })
                .WithMessage("The specification attribute id is not exists.");

            // check display order is greater or equal to 0
            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The display order must be greater or equal to 0.");

            // check that ColorSquaresRgb is rgb color
            RuleFor(x => x.ColorSquaresRgb)
                .Matches("^#(?:[0-9a-fA-F]{3}){1,2}$")
                .When(x => x.ColorSquaresRgb != null)
                .WithMessage("The ColorSquaresRgb must be a valid RGB color.");
        }
    }
}
