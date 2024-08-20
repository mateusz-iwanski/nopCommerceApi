using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Category
{
    public class CategoryUpdateDto : CategoryDto
    {
        private DateTime _uptadeOnUtc { get; set; }

        [JsonIgnore]
        public override DateTime UpdatedOnUtc
        {
            get => _uptadeOnUtc;
            set => _uptadeOnUtc = DateTime.Now;
        }
    }
}
