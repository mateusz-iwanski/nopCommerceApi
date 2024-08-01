using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductAttribute
{
    public class ProductAttributeUpdateDto : ProductAttributeDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
