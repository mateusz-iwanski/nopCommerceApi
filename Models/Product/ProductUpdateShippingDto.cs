using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Product
{
    public class ProductUpdateShippingDto : BaseDto
    {
        /// <summary>
        /// ## IsShipEnabled
        /// ### Set a value indicating whether the entity is ship enabled.
        /// #### Check if the product can be shipped. You can manage shipping settings by selecting Configuration > Shipping.
        /// *Default = true*
        /// </remaks>
        public virtual bool IsShipEnabled { get; set; }

        /// <summary>
        /// ## IsFreeShipping
        /// ### Set a value indicating whether the entity is free shipping.
        /// #### Check if this product comes with FREE shipping.
        /// *Default = false*
        /// </summary>
        public virtual bool IsFreeShipping { get; set; }

        /// <summary>
        /// ## ShipSeparately
        /// ### Set a value this product should be shipped separately (each item).
        /// #### Check if the product should be shipped separately from other products (in single box). 
        /// #### But notice that if the order includes several items of this product, 
        /// #### all of them will be shipped in single box.
        /// *Default = false*
        /// </summary>
        public virtual bool ShipSeparately { get; set; }

        /// <summary>
        /// ## AdditionalShippingCharge
        /// ### Set the additional shipping charge.
        /// *Default = 10m.*
        /// </summary>
        public virtual decimal AdditionalShippingCharge { get; set; }

        /// <summary>
        /// ## DeliveryDateId
        /// ### Set a delivery date identifier
        /// #### Choose a delivery date which will be displayed in the public store. 
        /// #### You can manage delivery dates by selecting Configuration > Shipping > Dates and ranges.
        /// *Default = 0*
        /// </summary>
        public virtual int DeliveryDateId { get; set; }

        /// <summary>
        /// ## Weight
        /// ### Set the weight
        /// #### To set mesasures go to Configuration → Shipping → Measures 
        /// </summary>
        [Required]
        public decimal Weight { get; set; }

        /// <summary>
        /// ## Length
        /// ### Set the length
        /// #### To set mesasures go to Configuration → Shipping → Measures 
        /// </summary>
        [Required]
        public decimal Length { get; set; }

        /// <summary>
        /// ## Width
        /// ### Set the width
        /// #### To set mesasures go to Configuration → Shipping → Measures 
        /// </summary>
        [Required]
        public decimal Width { get; set; }

        /// <summary>
        /// ## Height
        /// ### Set the height
        /// #### To set mesasures go to Configuration → Shipping → Measures 
        /// </summary>
        [Required]
        public decimal Height { get; set; }
    }
}
