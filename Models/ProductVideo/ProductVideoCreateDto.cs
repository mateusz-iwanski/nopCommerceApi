using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductVideo
{
    public class ProductVideoCreateDto : ProductVideoDto
    {
        [JsonIgnore]
        public override int Id { get; set;}
    }
}
