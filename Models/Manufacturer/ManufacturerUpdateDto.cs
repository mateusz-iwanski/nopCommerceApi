using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Manufacturer
{
    public class ManufacturerUpdateDto : ManufacturerDto
    {        

        [JsonIgnore]
        public override DateTime CreatedOnUtc { get; set; }

        [JsonIgnore]
        public override DateTime UpdatedOnUtc { get; set; } = DateTime.Now;
    }
}
