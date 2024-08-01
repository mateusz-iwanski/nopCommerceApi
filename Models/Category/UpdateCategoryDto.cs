using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Category
{
    public class UpdateCategoryDto : CategoryDto
    {
        [JsonIgnore]
        public override int Id { get; set; }

        [JsonIgnore]
        public override DateTime UpdatedOnUtc { get; set; } = DateTime.Now;
    }
}
