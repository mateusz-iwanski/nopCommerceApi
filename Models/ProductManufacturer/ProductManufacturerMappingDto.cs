
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductManufacturer
{
    public class ProductManufacturerMappingDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## ManufacturerId
        /// ### Gets or sets the manufacturer identifier
        /// </summary>
        [Required]
        public virtual int ManufacturerId { get; set; }

        /// <summary>
        /// ## ProductId
        /// ### Gets or sets the product identifier
        /// </summary>
        [Required]
        public virtual int ProductId { get; set; }

        /// <summary>
        /// ## IsFeaturedProduct
        /// ### Gets or sets a value indicating whether the product is a featured product
        /// *Default = false*
        /// </summary>
        public virtual bool IsFeaturedProduct { get; set; }

        /// <summary>
        /// ## DisplayOrder
        /// ### Gets or sets the display order
        /// *Default = 0*
        /// </summary>
        public virtual int DisplayOrder { get; set; }

        //[JsonIgnore]
        //public virtual nopCommerceApi.Entities.Usable.Manufacturer Manufacturer { get; set; }

        //[JsonIgnore]
        //public virtual nopCommerceApi.Entities.Usable.Product Product { get; set; }
    }
}
