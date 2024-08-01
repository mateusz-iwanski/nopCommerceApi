using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductAttribute
{
    public class ProductProductAttributeMappingCreateDto : ProductProductAttributeMappingDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
