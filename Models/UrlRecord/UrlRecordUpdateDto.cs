using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.UrlRecord
{
    public class UrlRecordUpdateDto : UrlRecordDto
    {
        [Required]
        public override int Id { get; set; }
    }
}

