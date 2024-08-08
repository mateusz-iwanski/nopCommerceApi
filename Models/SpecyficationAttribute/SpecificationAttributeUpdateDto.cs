using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.SpecyficationAttribute
{
    public class SpecificationAttributeUpdateDto : SpecificationAttributeDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
