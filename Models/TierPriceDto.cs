using nopCommerceApi.Entities;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models
{
    public class TierPriceDto
    {
        public int Id { get; set; }
        public int? CustomerRoleId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime? StartDateTimeUtc { get; set; }
        public DateTime? EndDateTimeUtc { get; set; }
    }
}
