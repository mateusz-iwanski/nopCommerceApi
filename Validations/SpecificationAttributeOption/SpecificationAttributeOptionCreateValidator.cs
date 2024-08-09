using nopCommerceApi.Entities;
using nopCommerceApi.Models.SpecificationAttribute;

namespace nopCommerceApi.Validations.SpecificationAttributeOption
{
    public class SpecificationAttributeOptionCreateValidator : SpecificationAttributeOptionBaseDtoValidator<SpecificationAttributeOptionCreateDto>
    {
        public SpecificationAttributeOptionCreateValidator(NopCommerceContext context) : base(context)
        {
        }
    }
}
