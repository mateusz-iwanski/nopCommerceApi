using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Picture
{
    public class PictureCreateDto : PictureDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
