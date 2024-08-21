using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Customer
{
    public class CustomerPLUpdateDto : CustomerPLCreateBaseDto
    {
        [Required]
        public int Id { get; set; }        

        public override DateTime CreatedOnUtc { get; set; }

        [JsonIgnore]
        public override string? Password { get; set; }
    }
}
