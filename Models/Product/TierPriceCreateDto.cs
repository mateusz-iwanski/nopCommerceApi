
namespace nopCommerceApi.Models.Product
{
    public class TierPriceCreateDto : BaseDto
    {
        /// <summary>
        /// If null, applies to all customer roles.
        /// </summary>
        public int? CustomerRoleId { get; set; } = null;

        public int ProductId { get; set; }

        /// <summary>
        /// Leave empty if not multi-store. Default storeId is 0.
        /// </summary>
        public int? StoreId { get; set; } = 0;

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        /// <summary>
        /// Can be null. Represents the start date and time in UTC.
        /// </summary>
        public DateTime? StartDateTimeUtc { get; set; }

        /// <summary>
        /// Can be null. Represents the end date and time in UTC.
        /// </summary>
        public DateTime? EndDateTimeUtc { get; set; }
    }
}
