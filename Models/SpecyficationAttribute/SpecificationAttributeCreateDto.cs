using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.SpecyficationAttribute
{
    public class SpecificationAttributeCreateDto : SpecificationAttributeDto
    {
        [JsonIgnore]
        public override int Id { get; set; }

    }
}
