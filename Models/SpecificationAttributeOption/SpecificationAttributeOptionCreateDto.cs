using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.SpecificationAttribute
{
    public class SpecificationAttributeOptionCreateDto : SpecificationAttributeOptionDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
