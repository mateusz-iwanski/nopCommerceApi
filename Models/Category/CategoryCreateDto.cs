using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Category
{
    public class CategoryCreateDto : CategoryDto
    {
        [JsonIgnore]
        public override int Id { get; set; }

        [JsonIgnore]
        public override DateTime CreatedOnUtc { get; set; } = DateTime.Now;

        [JsonIgnore]
        public override DateTime UpdatedOnUtc { get; set; } = DateTime.Now;

        // if we create a new category, it should be deleted = false
        [JsonIgnore]
        public override bool Deleted { get; set; } = false;
    }
}
