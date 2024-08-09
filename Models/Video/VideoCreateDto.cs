using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Video
{
    public class VideoCreateDto : VideoDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
