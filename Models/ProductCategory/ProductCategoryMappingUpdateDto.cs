using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductCategory
{
    public class ProductCategoryMappingUpdateDto : ProductCategoryMappingDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
