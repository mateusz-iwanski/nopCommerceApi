using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductTag
{
    /// <summary>
    /// Product tag create Data Transfer Object
    /// </summary>
    public class ProductTagCreateDto : ProductTagDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
