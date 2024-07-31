using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Product
{
    public class ProductUpdatePriceDto : BaseDto
    {
        /// <summary>
        /// ## DisableBuyButton
        /// ### Set a value indicating whether to disable buy (Add to cart) button
        /// #### Check to disable the buy button for this product. This may be necessary for products that are 'available upon request'.
        /// *Default = false*
        /// </summary>
        public virtual bool DisableBuyButton { get; set; }

        /// <summary>
        /// ## DisableWishlistButton
        /// ### Set a value indicating whether to disable "Add to wishlist" button
        /// *Default = false*
        /// </summary>
        public virtual bool DisableWishlistButton { get; set; }

        /// <summary>
        /// ## AvailableForPreOrder
        /// ### Set a value indicating whether this item is available for Pre-Order
        /// #### Check if this item is available for Pre-Order. It also displays "Pre-order" button instead of "Add to cart".
        /// *Default = false*
        /// </summary>
        public virtual bool AvailableForPreOrder { get; set; }

        /// <summary>
        /// ## PreOrderAvailabilityStartDateTimeUtc
        /// ### Set the start date and time of the product availability (for pre-order products)
        /// #### Only active with AvailableForPreOrder = true
        /// #### The availability start date of the product configured for pre-order in Coordinated Universal Time (UTC). 
        /// #### 'Pre-order' button will automatically be changed to 'Add to cart' at this moment.
        /// *Default = null*
        /// </summary>
        public virtual DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }

        /// <summary>
        /// ## Price
        /// ### Set the price
        /// #### The price of the product. You can manage currency by selecting Configuration > Currencies.
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// ## OldPrice
        /// ### Set the old price
        /// #### The old price of the product. If you set an old price, this will display alongside the 
        /// #### current price on the product page to show the difference in price.
        /// #### If is 0, old price will not show on product site
        /// *Defaul = 0*
        /// </summary>
        public virtual decimal OldPrice { get; set; }

        /// <summary>
        /// ## ProductCost
        /// ### Set the product cost
        /// #### Product cost is a prime product cost. This field is only for internal use, not visible for customers.
        /// *Default = 0m*
        /// </summary>
        public virtual decimal ProductCost { get; set; }

        /// <summary>
        /// ## CallForPrice
        /// ### Set a value indicating whether to show "Call for Pricing" or "Call for quote" instead of price
        /// #### Check to show "Call for Pricing" or "Call for quote" instead of price.
        /// *4Default = false*
        /// </summary>
        public virtual bool CallForPrice { get; set; }

        /// <summary>
        /// ## CustomerEntersPrice
        /// ### Set a value indicating whether a customer enters price
        /// #### An option indicating whether customer should enter price.
        /// *Default = false*
        /// </summary>
        public virtual bool CustomerEntersPrice { get; set; }

        /// <summary>
        /// ## MinimumCustomerEnteredPrice
        /// ### Set the minimum price entered by a customer.
        /// #### Only if CallForPrice is enabled.
        /// *Defaul = 0*
        /// </summary>
        public virtual decimal MinimumCustomerEnteredPrice { get; set; }

        /// <summary>
        /// ## MaximumCustomerEnteredPrice
        /// ### Set the maximum price entered by a customer
        /// #### Only if CallForPrice is enabled.
        /// *Defaul = 0*
        /// </summary>
        public virtual decimal MaximumCustomerEnteredPrice { get; set; }

        /// <summary>
        /// ## BasepriceEnabled
        /// ### Set a value indicating whether base price (PAngV) is enabled. Used by German users.
        /// #### Check to display baseprice of a product. This is required according to the German law (PAngV). 
        /// #### If you sell 500ml of beer for 1,50 euro, then you have to display baseprice: 3.00 euro per 1L.
        /// *Default = false*
        /// </summary>
        public virtual bool BasepriceEnabled { get; set; }

        /// <summary>
        /// ## BasepriceAmount
        /// ### Set an amount in product for PAngV.
        /// #### Only id BasepriceEnabled is enabled.
        /// #### Used by German users.
        /// *default = 0m*
        /// </summary>
        public virtual decimal BasepriceAmount { get; set; }

        /// <summary>
        /// ## Set a unit of product for PAngV (MeasureWeight entity)
        /// ### Only if BasepriceEnabled is enabled
        /// #### Used by German users.
        /// *Default = 3*
        /// </summary>
        public virtual int BasepriceUnitId { get; set; }

        /// <summary>
        /// ## BasepriceBaseAmount
        /// ### Set a reference amount for PAngV
        /// #### Only id BasepriceEnabled is enabled
        /// #### Used by German users.
        /// default is 0m.
        /// </summary>
        public virtual decimal BasepriceBaseAmount { get; set; }

        /// <summary>
        /// ## BasepriceBaseUnitId
        /// ### Set a reference unit for PAngV (MeasureWeight entity)
        /// #### Only id BasepriceEnabled is enabled
        /// #### Used by German users.
        /// *default = 3*
        /// </summary>
        public virtual int BasepriceBaseUnitId { get; set; }

        /// <summary>
        /// ## IsTaxExempt
        /// ### Set a value indicating whether the product is marked as tax exempt
        /// #### Determines whether this product is tax exempt (tax will not be applied to this product at checkout).
        /// *Default = false*
        /// </summary>
        public virtual bool IsTaxExempt { get; set; }

        /// <summary>
        /// ## TaxCategoryId
        /// ### Set the tax category identifier
        /// #### Look on TaxCategory schema for more details.
        /// </summary>
        [Required]
        public int TaxCategoryId { get; set; }

        /// <summary>
        /// ## HasDiscountsApplied
        /// ### Set a value indicating whether this product has discounts applied
        /// #### The same as if we run AppliedDiscounts.Count > 0
        /// #### We use this property for performance optimization:
        /// #### if this property is set to false, then we do not need to load Applied Discounts navigation property
        /// *4Default = false*
        /// </summary>
        public virtual bool HasDiscountsApplied { get; set; }

        /// <summary>
        /// ## HasTierPrices
        /// ### Set a value indicating whether this product has tier prices configured
        /// #### The same as if we run TierPrices.Count > 0
        /// #### We use this property for performance optimization:
        /// #### if this property is set to false, then we do not need to load tier prices navigation property
        /// *Default = true*
        /// </summary>
        public virtual bool HasTierPrices { get; set; }
    }
}
