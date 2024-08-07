using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.UrlRecord
{
    public class UrlRecordCreateDto : UrlRecordDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
