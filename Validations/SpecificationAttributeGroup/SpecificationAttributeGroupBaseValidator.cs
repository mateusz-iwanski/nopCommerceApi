using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.SpecyficationAttribute;
using nopCommerceApi.Models.SpecyficationAttributeGroup;

namespace nopCommerceApi.Validations.SpecificationAttributeGroup
{
    public class SpecificationAttributeGroupBaseValidator<T> : BaseValidator<T> where T : SpecificationAttributeGroupDto
    {
        protected readonly NopCommerceContext _context;

        public SpecificationAttributeGroupBaseValidator(NopCommerceContext context)
        {
            _context = context;

            // display order must be greater or equal 0
            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The display order must be greater or equal 0.");
        }
    }
}
