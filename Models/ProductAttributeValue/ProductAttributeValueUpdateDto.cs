using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductAttributeValue
{
    public class ProductAttributeValueUpdateDto : ProductAttributeValueDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
