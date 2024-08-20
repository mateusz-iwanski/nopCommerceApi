using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Category
{
    public class CategoryCreateDto : CategoryDto
    {
        private DateTime _createdOnUtc { get; set; }
        private DateTime _uptadeOnUtc { get; set; }

        [JsonIgnore]
        public override int Id { get; set; }

        [JsonIgnore]
        public override DateTime CreatedOnUtc 
        { 
            get => _createdOnUtc;
            set => _createdOnUtc = DateTime.Now;
        } 

        [JsonIgnore]
        public override DateTime UpdatedOnUtc
        {
            get => _uptadeOnUtc;
            set => _uptadeOnUtc = DateTime.Now;
        }

        // if we create a new category, it should be deleted = false
        [JsonIgnore]
        public override bool Deleted { get; set; } = false;
    }
}
