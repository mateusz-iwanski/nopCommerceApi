using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductPicture
{
    public class ProductPictureMappingCreateDto : ProductPictureMappingDto
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
