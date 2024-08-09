using nopCommerceApi.Entities;
using nopCommerceApi.Models.SpecificationAttributeOption;

namespace nopCommerceApi.Validations.SpecificationAttributeOption
{
    public class SpecificationAttributeOptionUpdateValidator : SpecificationAttributeOptionBaseDtoValidator<SpecificationAttributeOptionUpdateDto>
    {
        public SpecificationAttributeOptionUpdateValidator(NopCommerceContext context) : base(context)
        {
        }
    }
}
