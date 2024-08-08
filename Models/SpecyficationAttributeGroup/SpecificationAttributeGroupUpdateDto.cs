using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.SpecyficationAttributeGroup
{
    public class SpecificationAttributeGroupUpdateDto : SpecificationAttributeGroupDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
