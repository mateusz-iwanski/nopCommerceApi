using nopCommerceApi.Models.SpecificationAttribute;
using nopCommerceApi.Models.SpecyficationAttribute;

namespace nopCommerceApi.Models.SpecificationAttributeOption
{
    public class SpecificationAttributeOptionDetailsDto : SpecificationAttributeOptionDto
    {
        public virtual SpecificationAttributeDto? SpecificationAttribute { get; set;  }
    }
}
