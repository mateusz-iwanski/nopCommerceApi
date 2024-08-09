using nopCommerceApi.Models.SpecyficationAttribute;
using nopCommerceApi.Models.SpecyficationAttributeGroup;

namespace nopCommerceApi.Models.SpecificationAttribute
{
    public class SpecificationAttributeDetailsDto : SpecificationAttributeDto
    {
        public virtual SpecificationAttributeGroupDto? SpecificationAttributeGroup { get; set; }
        public virtual List<SpecificationAttributeOptionDto>? SpecificationAttributeOption { get; set; }
    }
}
