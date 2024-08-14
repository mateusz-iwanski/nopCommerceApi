using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductPicture
{
    public class ProductPictureMappingUpdateDto : ProductPictureMappingDto
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
