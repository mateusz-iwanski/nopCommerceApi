using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Picture
{
    public class PictureBinaryCreateDto : PictureBinaryDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
