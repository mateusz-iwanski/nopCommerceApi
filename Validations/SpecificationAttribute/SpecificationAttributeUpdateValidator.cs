using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.SpecyficationAttribute;

namespace nopCommerceApi.Validations.SpecificationAttribute
{
    public class SpecificationAttributeUpdateValidator : SpecificationAttributeBaseValidator<SpecificationAttributeUpdateDto>
    {
        public SpecificationAttributeUpdateValidator(NopCommerceContext context) : base(context)
        {
            // check that name with group id not exists, exclude updated entity
            RuleFor(x => new { x.Name, x.SpecificationAttributeGroupId, x.Id})
                .Must(obj => !_context.SpecificationAttributes.Any(sa => 
                        sa.Name == obj.Name && 
                        sa.SpecificationAttributeGroupId == obj.SpecificationAttributeGroupId && 
                        sa.Id != obj.Id
                        )
                ).WithMessage("The name with group id already exists.");
        }
    }
}
