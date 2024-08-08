using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.SpecyficationAttribute;

namespace nopCommerceApi.Validations.SpecificationAttribute
{
    public class SpecificationAttributeCreateValidator : SpecificationAttributeBaseValidator<SpecificationAttributeCreateDto>
    {
        public SpecificationAttributeCreateValidator(NopCommerceContext context) : base(context)
        {
            // check that name with group id not exists
            RuleFor(x => new { x.Name, x.SpecificationAttributeGroupId })
                .Must(obj => !_context.SpecificationAttributes.Any(sa => sa.Name == obj.Name && sa.SpecificationAttributeGroupId == obj.SpecificationAttributeGroupId))
                .WithMessage("The name with group id already exists.");
        }
    }
}
