using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.NotUsable;

namespace nopCommerceApi.Entities.Usable;

public partial class Product
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the meta keywords
    /// </summary>

    public string? MetaKeywords { get; set; }

    /// <summary>
    /// Gets or sets the meta description
    /// </summary>
    public string? MetaTitle { get; set; }

    /// <summary>
    /// Gets or sets the SKU
    /// </summary>
    public string? Sku { get; set; }

    /// <summary>
    /// Gets or sets the manufacturer part number
    /// </summary>
    public string? ManufacturerPartNumber { get; set; }

    /// <summary>
    /// Gets or sets the Global Trade Item Number (GTIN). These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books).
    /// </summary>
    public string? Gtin { get; set; }

    /// <summary>
    /// Get or set the comma separated list of allowed quantities. null or empty if any quantity is allowed.
    /// Instead of a quantity textbox that allows them to enter any quantity, they will receive a dropdown list of the values you enter here.
    /// </summary>
    public string? AllowedQuantities { get; set; }

    /// <summary>
    /// Get or Set the product type identifier
    /// Product type can be simple or grouped. In most cases your product will have the Simple product type. 
    /// You need to use Grouped product type when a new product consists of one or more existing products that will be displayed on one single product details page.
    /// enum ProductType Ids (compatible with 4.70.3). 
    /// SimpleProduct (5): A simple product. 
    /// GroupedProduct (10): A grouped product (product with variants).
    /// </summary>
    public int ProductTypeId { get; set; }

    /// <summary>
    /// Gets or sets the parent product identifier. It's used to identify associated products (only with "grouped" products)
    /// Products in nopCommerce have two different types, simple products and grouped products. 
    /// Grouped products let you stablish a hierarchical relation between them. As an easy example, 
    /// you can imagine a perfume (parent product) that has associated two simple products (small size and big size).
    /// </summary>
    public int ParentGroupedProductId { get; set; }

    /// <summary>
    /// Gets or sets the values indicating whether this product is visible in catalog or search results.
    /// It's used when this product is associated to some "grouped" one
    /// This way associated products could be accessed/added/etc only from a grouped product details page
    /// </summary>
    public bool VisibleIndividually { get; set; }

    /// <summary>
    /// Short description is the text that is displayed in product list i.e. category / manufacturer pages.
    /// </summary>
    public string? ShortDescription { get; set; }

    /// <summary>
    /// Full description is the text that is displayed in product page.
    /// </summary>
    public string? FullDescription { get; set; }

    /// <summary>
    /// This comment is for internal use only, not visible for customers.
    /// </summary>
    public string? AdminComment { get; set; }

    /// <summary>
    /// Choose a product template. This template defines how this product will be displayed in public store.
    /// Look on ProductTemplate for more details.
    /// </summary>
    public int ProductTemplateId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to show the product on home page
    /// Choose a vendor associated with this product. This can be useful when running a multi-vendor store to keep track of goods associated with vendor.
    /// If is not multi-vendor store, then this field should be set to 0.   
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// Gets or sets to true to display this product on your store's home page. Recommended for your most popular products.
    /// </summary>
    public bool ShowOnHomepage { get; set; }

    /// <summary>
    /// Meta description to be added to product page header.
    /// </summary>
    public string? MetaDescription { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product allows customer reviews
    /// By default, the reviews must be approved by the store owner before they appear in the public store. 
    /// However, in case a store owner decides that reviews do not have to be approved, this default behavior can be changed. 
    /// To opt out of the obligatory product reviews' approval, go to Configuration → Settings → Catalog settings and clear the Product reviews must be approved option.
    /// </summary>
    public bool AllowCustomerReviews { get; set; }

    /// <summary>
    /// Gets or sets the rating sum (approved reviews)
    /// Look on Configuration → Settings → Catalog settings for more details.
    /// When required is set in new review type, customers have to choose an appropriate rating value before they can continue.
    /// </summary>
    public int ApprovedRatingSum { get; set; }

    /// <summary>
    /// Gets or sets the rating sum (not approved reviews)
    /// Look on Configuration → Settings → Catalog settings for more details.
    /// </summary>
    public int NotApprovedRatingSum { get; set; }

    /// <summary>
    /// Gets or sets the total rating votes (approved reviews)
    /// Look on Configuration → Settings → Catalog settings for more details.
    /// </summary>
    public int ApprovedTotalReviews { get; set; }

    /// <summary>
    /// Gets or sets the total rating votes (not approved reviews)
    /// Look on Configuration → Settings → Catalog settings for more details.
    /// </summary>
    public int NotApprovedTotalReviews { get; set; }

    /// <summary>
    /// ACL - Access Control List (ACL) restricts or grants users access to certain areas of the site. This list is managed by administrators.
    /// Get or sets a value indicating whether the entity is subject to ACL.
    /// </summary>
    public bool SubjectToAcl { get; set; }

    /// <summary>
    /// Get or sets a value indicating whether the entity is limited/restricted to certain stores
    /// Option to limit this product to a certain store. If you have multiple stores, choose one or several from the list. 
    /// If you don't use this option just leave this field empty. In order to use this functionality, you have to disable the 
    /// following setting: Catalog settings > Ignore ACL rules.
    /// </summary>
    public bool LimitedToStores { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is gift card
    /// Check if it is a gift card. After adding gift card products to the shopping cart and completing the purchases, 
    /// you can then search and view the list of all the purchased gift cards by selecting Gift Cards from the Sales menu.
    /// </summary>
    public bool IsGiftCard { get; set; }

    /// <summary>
    /// Gets or sets the gift card type identifier
    /// Defines the type of gift card.
    /// Virtual (0): A virtual gift card.
    /// Physical (1): A physical gift card.
    /// Default is 0.
    /// </summary>
    public int GiftCardTypeId { get; set; }

    /// <summary>
    /// Gets or sets gift card amount that can be used after purchase. If not specified, then product price will be used.
    /// </summary>
    public decimal? OverriddenGiftCardAmount { get; set; }

    /// <summary>
    /// Set a value indicating whether the product requires that other products are added to the cart (Product X requires Product Y).
    /// If you set to true you have use RequiredProductIds
    /// </summary>
    public bool RequireOtherProducts { get; set; }

    /// <summary>
    /// Set a required product identifiers (comma separated)
    /// Specify comma separated list of required product IDs. NOTE: Ensure that there are no circular references (for example, A requires B, and B requires A).
    /// It's only work when RequireOtherProducts = true;
    /// </summary>
    public virtual string? RequiredProductIds { get; set; }


    /// <summary>
    /// Gets or sets a value indicating whether required products (RequiredProductIds) are automatically added to the cart
    /// </summary>
    public bool AutomaticallyAddRequiredProducts { get; set; }

    #region Product to download

    /// <summary>
    /// Gets or sets a value indicating whether the product is download
    /// </summary>
    public bool IsDownload { get; set; }

    /// <summary>
    /// Gets or sets the download identifier from Entity Download
    /// </summary>
    public int DownloadId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this downloadable product can be downloaded unlimited number of times
    /// </summary>
    public bool UnlimitedDownloads { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of downloads.
    /// UnlimitedDownloads has to be false if you want to use this function.
    /// </summary>
    public int MaxNumberOfDownloads { get; set; }

    /// <summary>
    /// Gets or sets the number of days during customers keeps access to the file.
    /// </summary>
    public int? DownloadExpirationDays { get; set; }

    /// <summary>
    /// Gets or sets the download activation type
    /// Defines the download activation type (compatible with 4.70.3).
    /// WhenOrderIsPaid (0): Activation occurs when the order is paid.
    /// Manually (10): Activation occurs manually.
    /// </summary>
    public int DownloadActivationTypeId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product has a sample download file.
    /// You can download file using URL or uploading from the computer. 
    /// If you want to download file using URL check the box Use download URL.
    /// </summary>
    public bool HasSampleDownload { get; set; }

    /// <summary>
    /// Gets or sets the sample download identifier
    /// </summary>
    public int SampleDownloadId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product has user agreement
    /// </summary>
    public bool HasUserAgreement { get; set; }

    /// <summary>
    /// Gets or sets the text of license agreement
    /// </summary>
    public string? UserAgreementText { get; set; }

    #endregion

    #region Recuring
    /// <summary>
    /// Gets or sets a value indicating whether the product is recurring
    /// Check if it is a recurring product. For any product, you can define a recurring cycle to enable the system 
    /// to automatically create orders that repeat when a customer purchases such products.
    /// Default is false;
    /// </summary>
    public bool IsRecurring { get; set; }

    /// <summary>
    /// Gets or sets the cycle length
    /// Specify the cycle length. It is a time period recurring order can be repeated.
    /// </summary>
    public int RecurringCycleLength { get; set; }

    /// <summary>
    /// Gets or sets the cycle period
    /// Specify the cycle period. It defines units time period can be measured in.
    /// Defines the cycle period for a recurring product.
    /// Days (0): The cycle is in days.
    /// Weeks (10): The cycle is in weeks.
    /// Months (20): The cycle is in months.
    /// Years (30): The cycle is in years.
    /// </summary>
    public int RecurringCyclePeriodId { get; set; }

    /// <summary>
    /// Gets or sets the total cycles
    /// Total cycles are number of times customer will receive the recurring product.
    /// </summary>
    public int RecurringTotalCycles { get; set; }

    #endregion

    #region Rental

    /// <summary>
    /// Gets or sets a value indicating whether the product is rental
    /// Check if this is a rental product (price is set for some period). Please note that inventory management is not fully 
    /// supported for rental products yet. It's recommended to set 'Manage inventory method' to 'Don't track inventory' now.
    /// </summary>
    public bool IsRental { get; set; }


    /// <summary>
    /// Gets or sets the rental length for some period (price for this period)
    /// </summary>
    public int RentalPriceLength { get; set; }

    /// <summary>
    /// Gets or sets the rental period (price for this period)
    /// Defines the cycle period for a rental period.
    /// Days (0): The cycle is in days.
    /// Weeks (10): The cycle is in weeks.
    /// Months (20): The cycle is in months.
    /// Years (30): The cycle is in years.
    /// </summary>
    public int RentalPricePeriodId { get; set; }

    #endregion

    #region Shipping

    /// <summary>
    /// Gets or sets a value indicating whether the entity is ship enabled
    /// You can manage shipping settings by selecting Configuration > Shipping.
    /// </summary>
    public bool IsShipEnabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is free shipping
    /// Check if this product comes with FREE shipping.
    /// </summary>
    public bool IsFreeShipping { get; set; }

    /// <summary>
    /// Gets or sets a value this product should be shipped separately (each item)
    /// Check if the product should be shipped separately from other products (in single box). 
    /// But notice that if the order includes several items of this product, 
    /// all of them will be shipped in single box.
    /// </summary>
    public bool ShipSeparately { get; set; }

    /// <summary>
    /// Gets or sets the additional shipping charge
    /// </summary>
    public decimal AdditionalShippingCharge { get; set; }

    /// <summary>
    /// Gets or sets a delivery date identifier
    /// </summary>
    public int DeliveryDateId { get; set; }

    #endregion

    /// <summary>
    /// Gets or sets a value indicating whether the product is marked as tax exempt
    /// </summary>
    public bool IsTaxExempt { get; set; }

    /// <summary>
    /// Gets or sets the tax category identifier
    /// </summary>
    public int TaxCategoryId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating how to manage inventory
    /// ManageInventoryMethod: Enumerates methods of inventory management.
    /// - DontManageStock (0): Do not track inventory for the product.
    /// - ManageStock (1): Track inventory for the product.
    /// - ManageStockByAttributes (2): Track inventory for the product by product attributes.
    /// </summary>
    public int ManageInventoryMethodId { get; set; }

    /// <summary>
    /// Gets or sets a product availability range identifier
    /// </summary>
    public int ProductAvailabilityRangeId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether multiple warehouses are used for this product
    /// </summary>
    public bool UseMultipleWarehouses { get; set; }

    /// <summary>
    /// Gets or sets a warehouse identifier
    /// </summary>
    public int WarehouseId { get; set; }

    /// <summary>
    /// Gets or sets the stock quantity
    /// </summary>
    public int StockQuantity { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display stock availability
    /// </summary>
    public bool DisplayStockAvailability { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display stock quantity
    /// </summary>
    public bool DisplayStockQuantity { get; set; }

    /// <summary>
    /// Gets or sets the minimum stock quantity
    /// </summary>
    public int MinStockQuantity { get; set; }
    
    /// <summary>
    /// Gets or sets the low stock activity identifier
    /// </summary>
    public int LowStockActivityId { get; set; }

    /// <summary>
    /// Gets or sets the quantity when admin should be notified
    /// </summary>
    public int NotifyAdminForQuantityBelow { get; set; }

    /// <summary>
    /// Gets or sets a value backorder mode identifier
    /// </summary>
    public int BackorderModeId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to back in stock subscriptions are allowed
    /// </summary>
    public bool AllowBackInStockSubscriptions { get; set; }

    /// <summary>
    /// Gets or sets the order minimum quantity
    /// </summary>
    public int OrderMinimumQuantity { get; set; }

    /// <summary>
    /// Gets or sets the order maximum quantity
    /// </summary>
    public int OrderMaximumQuantity { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether we allow adding to the cart/wishlist only attribute combinations that exist and have stock greater than zero.
    /// This option is used only when we have "manage inventory" set to "track inventory by product attributes"
    /// </summary>
    public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display attribute combination images only
    /// </summary>
    public bool DisplayAttributeCombinationImagesOnly { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this product is returnable (a customer is allowed to submit return request with this product)
    /// </summary>
    public bool NotReturnable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to disable buy (Add to cart) button
    /// </summary>
    public bool DisableBuyButton { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to disable "Add to wishlist" button
    /// </summary>
    public bool DisableWishlistButton { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this item is available for Pre-Order
    /// </summary>
    public bool AvailableForPreOrder { get; set; }

    /// <summary>
    /// Gets or sets the start date and time of the product availability (for pre-order products)
    /// </summary>
    public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to show "Call for Pricing" or "Call for quote" instead of price
    /// </summary>
    public bool CallForPrice { get; set; }

    /// <summary>
    /// Gets or sets the price
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the old price
    /// </summary>
    public decimal OldPrice { get; set; }

    /// <summary>
    /// Gets or sets the product cost
    /// </summary>
    public decimal ProductCost { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a customer enters price
    /// </summary>
    public bool CustomerEntersPrice { get; set; }

    /// <summary>
    /// Gets or sets the minimum price entered by a customer
    /// </summary>
    public decimal MinimumCustomerEnteredPrice { get; set; }

    /// <summary>
    /// Gets or sets the maximum price entered by a customer
    /// </summary>
    public decimal MaximumCustomerEnteredPrice { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether base price (PAngV) is enabled. Used by German users.
    /// </summary>
    public bool BasepriceEnabled { get; set; }

    /// <summary>
    /// Gets or sets an amount in product for PAngV
    /// </summary>
    public decimal BasepriceAmount { get; set; }

    /// <summary>
    /// Gets or sets a unit of product for PAngV (MeasureWeight entity)
    /// </summary>
    public int BasepriceUnitId { get; set; }

    /// <summary>
    /// Gets or sets a reference amount for PAngV
    /// </summary>
    public decimal BasepriceBaseAmount { get; set; }

    /// <summary>
    /// Gets or sets a reference unit for PAngV (MeasureWeight entity)
    /// </summary>
    public int BasepriceBaseUnitId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this product is marked as new
    /// </summary>
    public bool MarkAsNew { get; set; }

    /// <summary>
    /// Gets or sets the start date and time of the new product (set product as "New" from date). Leave empty to ignore this property
    /// </summary>
    public DateTime? MarkAsNewStartDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the end date and time of the new product (set product as "New" to date). Leave empty to ignore this property
    /// </summary>
    public DateTime? MarkAsNewEndDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this product has tier prices configured
    /// <remarks>The same as if we run TierPrices.Count > 0
    /// We use this property for performance optimization:
    /// if this property is set to false, then we do not need to load tier prices navigation property
    /// </remarks>
    /// </summary>
    // public bool HasTierPrices { get; set; }  Thies fields is not available in nopCommerce 4.8

    /// <summary>
    /// Gets or sets a value indicating whether this product has discounts applied
    /// <remarks>The same as if we run AppliedDiscounts.Count > 0
    /// We use this property for performance optimization:
    /// if this property is set to false, then we do not need to load Applied Discounts navigation property
    /// </remarks>
    /// </summary>
    // public bool HasDiscountsApplied { get; set; }  Thies fields is not available in nopCommerce 4.8

    /// <summary>
    /// Gets or sets the weight
    /// </summary>
    public decimal Weight { get; set; }

    /// <summary>
    /// Gets or sets the length
    /// </summary>
    public decimal Length { get; set; }

    /// <summary>
    /// Gets or sets the width
    /// </summary>
    public decimal Width { get; set; }

    /// <summary>
    /// Gets or sets the height
    /// </summary>
    public decimal Height { get; set; }

    /// <summary>
    /// Gets or sets the available start date and time
    /// </summary>
    public DateTime? AvailableStartDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the available end date and time
    /// </summary>
    public DateTime? AvailableEndDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets a display order.
    /// This value is used when sorting associated products (used with "grouped" products)
    /// This value is used when sorting home page products
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is published
    /// </summary>
    public bool Published { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity has been deleted
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// Gets or sets the date and time of product creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the date and time of product update
    /// </summary>
    public DateTime UpdatedOnUtc { get; set; }

    public virtual ICollection<BackInStockSubscription> BackInStockSubscriptions { get; set; } = new List<BackInStockSubscription>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductAttributeCombination> ProductAttributeCombinations { get; set; } = new List<ProductAttributeCombination>();

    public virtual ICollection<ProductCategoryMapping> ProductCategoryMappings { get; set; } = new List<ProductCategoryMapping>();

    public virtual ICollection<ProductManufacturerMapping> ProductManufacturerMappings { get; set; } = new List<ProductManufacturerMapping>();

    public virtual ICollection<ProductPictureMapping> ProductPictureMappings { get; set; } = new List<ProductPictureMapping>();

    public virtual ICollection<ProductProductAttributeMapping> ProductProductAttributeMappings { get; set; } = new List<ProductProductAttributeMapping>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<ProductSpecificationAttributeMapping> ProductSpecificationAttributeMappings { get; set; } = new List<ProductSpecificationAttributeMapping>();

    public virtual ICollection<ProductVideo> ProductVideos { get; set; } = new List<ProductVideo>();

    public virtual ICollection<ProductWarehouseInventory> ProductWarehouseInventories { get; set; } = new List<ProductWarehouseInventory>();

    public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

    public virtual ICollection<StockQuantityHistory> StockQuantityHistories { get; set; } = new List<StockQuantityHistory>();

    public virtual ICollection<TierPrice> TierPrices { get; set; } = new List<TierPrice>();

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
}
