namespace nopCommerceApi.Models.Product
{
    public class TierPriceUpdateDto : BaseDto
    {
        public int? CustomerRoleId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime? StartDateTimeUtc { get; set; }
        public DateTime? EndDateTimeUtc { get; set; }
    }
}
