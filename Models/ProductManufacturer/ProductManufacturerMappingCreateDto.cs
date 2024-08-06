using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductManufacturer
{
    public class ProductManufacturerMappingCreateDto : ProductManufacturerMappingDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
