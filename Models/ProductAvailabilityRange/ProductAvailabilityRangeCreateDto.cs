using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductAvailabilityRange
{
    /// <summary>
    /// <c>ProductAvailabilityRangeCreateDto</c> uses for creating product availability range
    /// </summary>
    /// <remarks>
    /// Delivery dates are time ranges displaying approximate delivery time to a customer. 
    /// The delivery dates can be applied to products and displayed on the product details pages.
    /// Go to Configuration → Shipping → Dates and ranges.The two following panels will be displayed in the Dates and ranges window:
    /// </remarks>
    public class ProductAvailabilityRangeCreateDto : ProductAvailabilityRangeDto
    {
        [JsonIgnore]
        public override int Id { get; set; }

        /// <summary>
        /// Set the display order
        /// </summary>
        [JsonIgnore]
        public override int DisplayOrder { get; set; }
    }
}
