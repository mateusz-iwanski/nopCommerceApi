using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Category
{
    public class CategoryUpdateDto : CategoryDto
    {
        [JsonIgnore]
        public override DateTime UpdatedOnUtc { get; set; } = DateTime.Now;
    }
}
