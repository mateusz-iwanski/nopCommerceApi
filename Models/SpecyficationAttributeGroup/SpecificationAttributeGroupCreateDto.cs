using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.SpecyficationAttributeGroup
{
    public class SpecificationAttributeGroupCreateDto : SpecificationAttributeGroupDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
