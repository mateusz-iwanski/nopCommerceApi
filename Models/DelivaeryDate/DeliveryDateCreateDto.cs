using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.DelivaeryDate
{
    public class DeliveryDateCreateDto : DeliveryDateDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
