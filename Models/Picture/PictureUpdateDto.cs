using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Picture
{
    public class PictureUpdateDto : PictureDto
    {
        [JsonIgnore]
        public override int Id { get; set; }

    }
}
