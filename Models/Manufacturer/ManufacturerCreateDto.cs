using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Manufacturer
{
    public class ManufacturerCreateDto : ManufacturerDto
    {
        [JsonIgnore]
        public override int Id { get; set; }

        [JsonIgnore]
        public override DateTime CreatedOnUtc { get; set; } = DateTime.Now;

        [JsonIgnore]
        public override DateTime UpdatedOnUtc { get; set; } = DateTime.Now;
    }
}
