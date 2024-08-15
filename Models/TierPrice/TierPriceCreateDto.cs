using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.TierPrice
{
    public class TierPriceCreateDto : TierPriceDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
