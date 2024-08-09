using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.SpecyficationAttributeGroup;

namespace nopCommerceApi.Validations.SpecificationAttributeGroup
{
    public class SpecificationAttributeGroupCreateValidator : SpecificationAttributeGroupBaseValidator<SpecificationAttributeGroupCreateDto>
    {
        public SpecificationAttributeGroupCreateValidator(NopCommerceContext context) : base(context)
        {
            // name must be unique
            RuleFor(x => x.Name)
                .Must((dto, name) => !context.SpecificationAttributeGroups.Any(x => x.Name == name))
                .WithMessage("The name must be unique.");
        }
    }
}
