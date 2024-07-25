using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Product
{
    /// <summary>
    /// <c>ProductAvailabilityRangeCreateDto</c> uses for creating product availability range
    /// </summary>
    /// <remarks>
    /// Delivery dates are time ranges displaying approximate delivery time to a customer. 
    /// The delivery dates can be applied to products and displayed on the product details pages.
    /// Go to Configuration → Shipping → Dates and ranges.The two following panels will be displayed in the Dates and ranges window:
    /// </remarks>
    public class ProductAvailabilityRangeCreateDto : BaseDto
    {
        /// <summary>
        /// Set the name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Set the display order
        /// </summary>
        [JsonIgnore]
        public int DisplayOrder { get; set; }
    }
}
