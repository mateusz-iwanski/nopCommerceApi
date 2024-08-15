using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.TierPrice
{
    public class TierPriceUpdateDto : TierPriceDto
    {
        [Required]
        public override int Id { get; set; }
    }
}
