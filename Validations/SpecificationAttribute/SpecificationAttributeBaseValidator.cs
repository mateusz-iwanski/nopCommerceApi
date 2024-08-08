using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.SpecyficationAttribute;
using nopCommerceApi.Models.UrlRecord;

namespace nopCommerceApi.Validations.SpecificationAttribute
{
    public class SpecificationAttributeBaseValidator<T> : BaseValidator<T> where T : SpecificationAttributeDto
    {
        protected readonly NopCommerceContext _context;

        public SpecificationAttributeBaseValidator(NopCommerceContext context)
        {
            _context = context;            

            // diaply order must be greater or equal 0
            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The display order must be greater or equal 0.");
        }
    }
}
