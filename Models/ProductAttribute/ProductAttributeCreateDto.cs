using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductAttribute
{
    public class ProductAttributeCreateDto : ProductAttributeDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
