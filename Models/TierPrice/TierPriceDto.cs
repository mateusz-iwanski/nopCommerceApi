using nopCommerceApi.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.TierPrice
{
    public class TierPriceDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## CustomerRoleId
        /// ### If null, applies to all customer roles.
        /// </summary>
        public virtual int? CustomerRoleId { get; set; }

        /// <summary>
        /// ## ProductId
        /// ### Gets or sets the product identifier.
        /// </summary>
        [Required]
        public virtual int ProductId { get; set; }

        /// <summary>
        /// ## StoreId
        /// ### Leave empty if not multi-store. Default storeId is 0.
        /// *default value: 0*
        /// </summary>
        [Required]
        public virtual int? StoreId { get; set; }

        /// <summary>
        /// ## Quantity
        /// ### Gets or sets the quantity.
        /// </summary>
        [Required]
        public virtual int Quantity { get; set; }

        /// <summary>
        /// ## Price
        /// ### Gets or sets the price.
        /// </summary>
        [Required]
        public virtual decimal Price { get; set; }

        /// <summary>
        /// ## StartDateTimeUtc 
        /// ### Gets or sets the start date and time in UTC.
        /// #### Can be null. Represents the start date and time in UTC.
        /// </summary>
        public virtual DateTime? StartDateTimeUtc { get; set; }

        /// <summary>
        /// ## EndDateTimeUtc
        /// ### Gets or sets the end date and time in UTC.
        /// #### Can be null. Represents the end date and time in UTC.
        /// </summary>
        public virtual DateTime? EndDateTimeUtc { get; set; }
    }
}
