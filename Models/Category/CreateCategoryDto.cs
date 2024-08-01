using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Category
{
    public class CreateCategoryDto : CategoryDto
    {
        [JsonIgnore]
        public override int Id { get; set; }

        [JsonIgnore]
        public override DateTime CreatedOnUtc { get; set; } = DateTime.Now;

    }
}
