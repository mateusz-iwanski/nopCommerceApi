using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.UrlRecord
{
    public class UrlRecordUpdateDto : UrlRecordDto
    {
        public override int Id { get; set; }
    }
}
