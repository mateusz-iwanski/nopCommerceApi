using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductAttributeMapping
{
    public class ProductProductAttributeMappingCreateDto : ProductProductAttributeMappingDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
