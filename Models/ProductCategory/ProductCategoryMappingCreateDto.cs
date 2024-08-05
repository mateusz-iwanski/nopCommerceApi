using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductCategory
{
    public class ProductCategoryMappingCreateDto : ProductCategoryMappingDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
