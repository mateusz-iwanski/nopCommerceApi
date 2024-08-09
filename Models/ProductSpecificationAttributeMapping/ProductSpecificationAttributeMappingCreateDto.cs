using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductSpecificationAttributeMapping
{
    public class ProductSpecificationAttributeMappingCreateDto : ProductSpecificationAttributeMappingDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
