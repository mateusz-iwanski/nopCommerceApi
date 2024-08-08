using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.SpecyficationAttributeGroup;

namespace nopCommerceApi.Validations.SpecificationAttributeGroup
{
    public class SpecificationAttributeGroupUpdateValidator : SpecificationAttributeGroupBaseValidator<SpecificationAttributeGroupUpdateDto>
    {
        public SpecificationAttributeGroupUpdateValidator(NopCommerceContext context) : base(context)
        {
            // name must be unique, exclude updated entity
            RuleFor(x => x.Name)
                .Must((dto, name) => !_context.SpecificationAttributeGroups.Any(sag => sag.Name == name && sag.Id != dto.Id))
                .WithMessage("The name already exists.");
        }
    }
}
