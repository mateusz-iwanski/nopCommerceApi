namespace nopCommerceApi.Models.Product
{
    public class ProductCreateDto : BaseDto
    {
        #region Product information
        
        /// <summary>
        /// Set the name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Set the SKU
        /// </summary>
        public virtual string Sku { get; set; }

        /// <summary>
        /// Short description is the text that is displayed in product list i.e. category / manufacturer pages.
        /// </summary>
        public virtual string? ShortDescription { get; set; }

        /// <summary>
        /// Full description is the text that is displayed in product page.
        /// </summary>
        public virtual string? FullDescription { get; set; }


        /// <summary>
        /// Set the manufacturer part number.
        /// </summary>
        public virtual string? ManufacturerPartNumber { get; set; }

        /// <summary>
        /// Set a value indicating whether the entity is published.
        /// </summary>
        /// <remark>
        /// Default is false
        /// </remark>
        public virtual bool Published { get; set; } = false;

        /// <summary>
        /// Set a value indicating whether the entity has been deleted.
        /// </summary>
        /// <remarks>
        /// Default = false
        /// </remarks>
        public virtual bool Deleted { get; set; } = false;


        /// <summary>
        /// Set the Global Trade Item Number (GTIN). These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books).
        /// </summary>
        /// <remarks>
        /// Default is null.
        /// </remarks>
        public virtual string? Gtin { get; set; } = null;

        /// <summary>
        /// Set the product type identifier.
        /// </summary>
        /// <remarks>
        /// Product type can be simple or grouped. In most cases your product will have the Simple product type. 
        /// You need to use Grouped product type when a new product consists of one or more existing products that will be displayed on one single product details page.
        /// enum ProductType Ids (compatible with 4.70.3). 
        /// SimpleProduct (5): A simple product. 
        /// GroupedProduct (10): A grouped product (product with variants).
        /// Default is 5
        /// </remarks>
        public virtual int ProductTypeId { get; set; } = 5;

        /// <summary>
        /// Choose a product template. This template defines how this product will be displayed in public store.
        /// </summary>
        /// <remarks>
        /// Look on ProductTemplate for more details.
        /// Default is 1 - Simple Product
        /// </remarks>
        public virtual int ProductTemplateId { get; set; } = 1;

        /// <summary>
        /// Set a value indicating whether to show the product on home page.
        /// </summary>
        /// <remarks>
        /// Choose a vendor associated with this product. This can be useful when running a multi-vendor store to keep track of goods associated with vendor.
        /// If is not multi-vendor store, then this field should be set to 0.   
        /// Default it's set to 0.
        /// </remarks>
        public virtual int VendorId { get; set; } = 0;

        /// <summary>
        /// Set a value indicating whether the product requires that other products are added to the cart (Product X requires Product Y).
        /// </summary>
        /// <remarks>
        /// If you set to true you have use RequiredProductIds.
        /// Default is false.
        /// </remarks>
        public virtual bool RequireOtherProducts { get; set; } = false;

        /// <summary>
        /// Set a required product identifiers (comma separated).
        /// </summary>
        /// <remarks>
        /// Specify comma separated list of required product IDs. NOTE: Ensure that there are no circular references (for example, A requires B, and B requires A).
        /// It's only work when RequireOtherProducts = true.
        /// Default is null.
        /// </remarks>
        public virtual string? RequiredProductIds { get; set; } = null;


        /// <summary>
        /// Set a value indicating whether required products (RequiredProductIds) are automatically added to the cart.
        /// </summary>
        /// <remarks>
        /// Default is false.
        /// </remarks>
        public virtual bool AutomaticallyAddRequiredProducts { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether to display this product on your store's home page. Recommended for your most popular products.
        /// </summary>
        /// <remarks>
        /// Default it's set to false.
        /// </remarks>
        public virtual bool ShowOnHomepage { get; set; } = false;

        /// <summary>
        /// Set a display order.
        /// </summary>
        /// <remarks>
        /// This value is used when sorting associated products (used with "grouped" products).
        /// This value is used when sorting home page products.
        /// Default is 0.
        /// </remarks>
        public virtual int DisplayOrder { get; set; } = 0;

        /// <summary>
        /// Set the parent product identifier. It's used to identify associated products (only with "grouped" products).
        /// </summary>
        /// <remarks>
        /// Products in nopCommerce have two different types, simple products and grouped products. 
        /// Grouped products let you stablish a hierarchical relation between them. As an easy example, 
        /// you can imagine a perfume (parent product) that has associated two simple products (small size and big size).
        /// Default it's set to 0.
        /// </remarks>
        public virtual int ParentGroupedProductId { get; set; } = 0;

        /// <summary>
        /// Set the values indicating whether this product is visible in catalog or search results.
        /// </summary>
        /// <remarks>
        /// It's used when this product is associated to some "grouped" one.
        /// This way associated products could be accessed/added/etc only from a grouped product details page.
        /// </remarks>
        public virtual bool VisibleIndividually { get; set; }

        /// <summary>
        /// ACL - Access Control List (ACL) restricts or grants users access to certain areas of the site. This list is managed by administrators.
        /// </summary>
        /// <remarks>
        /// Set a value indicating whether the entity is subject to ACL.
        /// Default is true.
        /// </remarks>
        public virtual bool SubjectToAcl { get; set; } = true;

        /// <summary>
        /// Set a value indicating whether the entity is limited/restricted to certain stores.
        /// </summary>
        /// <remarks>
        /// Option to limit this product to a certain store. If you have multiple stores, choose one or several from the list. 
        /// If you don't use this option just leave this field empty. In order to use this functionality, you have to disable the 
        /// following setting: Catalog settings > Ignore ACL rules.
        /// Default is false.
        /// </remarks>
        public virtual bool LimitedToStores { get; set; } = false;

        /// <summary>
        /// Set the available start date and time.
        /// </summary>
        /// <remarks>
        /// Default is null.
        /// </remarks>
        public virtual DateTime? AvailableStartDateTimeUtc { get; set; } = null;

        /// <summary>
        /// Set the available end date and time.
        /// </summary>
        /// <remarks>
        /// Default is null.
        /// </remarks>
        public virtual DateTime? AvailableEndDateTimeUtc { get; set; } = null;

        /// <summary>
        /// Set a value indicating whether this product is marked as new.
        /// </summary>
        /// <remarks>
        /// Check to mark the product as new. Use this option for promoting new products.
        /// Default is true.
        /// </remarks>
        public virtual bool MarkAsNew { get; set; } = true;

        /// <summary>
        /// Set the start date and time of the new product (set product as "New" from date). Leave empty to ignore this property.
        /// </summary>
        /// <remarks>
        /// Only enabled if MarkAsNew is false.
        /// Set Product as New from Date in Coordinated Universal Time (UTC).
        /// Default is null.
        /// </remarks>
        public virtual DateTime? MarkAsNewStartDateTimeUtc { get; set; } = null;

        /// <summary>
        /// Set the end date and time of the new product (set product as "New" to date). Leave empty to ignore this property.
        /// </summary>
        /// <remarks>
        /// Only enabled if MarkAsNew is false.
        /// Set Product as New to Date in Coordinated Universal Time (UTC).
        /// Default is null.
        /// </remarks>
        public virtual DateTime? MarkAsNewEndDateTimeUtc { get; set; } = null;

        /// <summary>
        /// This comment is for internal use only, not visible for customers.
        /// </summary>
        /// <remarks>
        /// Defaul is null.
        /// </remarks>
        public virtual string? AdminComment { get; set; } = null;

        /// <summary>
        /// Set the date and time of product creation.
        /// </summary>
        public virtual DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// </summary>
        /// <remarks>
        /// Set the date and time of product update.
        /// Default DateTime.Now.
        /// </remarks>
        public virtual DateTime UpdatedOnUtc { get; set; } = DateTime.Now;

        #endregion

        #region SEO

        /// <summary>
        /// Set the meta keywords.
        /// </summary>
        public virtual string? MetaKeywords { get; set; }

        /// <summary>
        /// Set the meta description.
        /// </summary>
        public virtual string? MetaTitle { get; set; }

        /// <summary>
        /// Meta description to be added to product page header.
        /// </summary>
        public virtual string? MetaDescription { get; set; }

        #endregion

        #region Rating

        /// <summary>
        /// Set the rating sum (approved reviews).
        /// </summary>
        /// <remarks>
        /// Look on Configuration → Settings → Catalog settings for more details.
        /// When required is set in new review type, customers have to choose an appropriate rating value before they can continue.
        /// Default is 0 - not approved.
        /// </remarks>
        public virtual int ApprovedRatingSum { get; set; } = 0;

        /// <summary>
        /// Set the rating sum (not approved reviews).
        /// </summary>
        /// <remarks>
        /// Look on Configuration → Settings → Catalog settings for more details.
        /// Default is 0 - not approved.
        /// </remarks>
        public virtual int NotApprovedRatingSum { get; set; } = 0;

        #endregion

        #region Reviews

        /// <summary>
        /// Set a value indicating whether the product allows customer reviews.
        /// </summary>
        /// <remarks>
        /// By default, the reviews must be approved by the store owner before they appear in the public store. 
        /// However, in case a store owner decides that reviews do not have to be approved, this default behavior can be changed. 
        /// To opt out of the obligatory product reviews' approval, go to Configuration → Settings → Catalog settings and clear the Product reviews must be approved option.
        /// Default is false.
        /// </remarks>

        public virtual bool AllowCustomerReviews { get; set; } = false;

        /// <summary>
        /// Set the total rating votes (approved reviews).
        /// </summary>
        /// <remarks>
        /// Look on Configuration → Settings → Catalog settings for more details.
        /// Default is 0 - not approved.
        /// </remarks>
        public virtual int ApprovedTotalReviews { get; set; } = 0;

        /// <summary>
        /// Set the total rating votes (not approved reviews).
        /// </summary>
        /// <remarks>
        /// Look on Configuration → Settings → Catalog settings for more details.
        /// Default is 0 - not approved.
        /// </remarks>
        public virtual int NotApprovedTotalReviews { get; set; } = 0;

        #endregion

        #region Gift Card

        /// <summary>
        /// Set a value indicating whether the product is gift card.
        /// </summary>
        /// <remarks>
        /// Check if it is a gift card. After adding gift card products to the shopping cart and completing the purchases, 
        /// you can then search and view the list of all the purchased gift cards by selecting Gift Cards from the Sales menu.
        /// Default is false.
        /// </remarks>
        public virtual bool IsGiftCard { get; set; } = false;

        /// <summary>
        /// Set the gift card type identifier.
        /// </summary>
        /// <remarks>
        /// Defines the type of gift card.
        /// Virtual (0): A virtual gift card.
        /// Physical (1): A physical gift card.
        /// Default is 0.
        /// </remarks>
        public virtual int GiftCardTypeId { get; set; } = 0;

        /// <summary>
        /// Set gift card amount that can be used after purchase. If not specified, then product price will be used.
        /// </summary>
        /// <remarks>
        /// Default is null.
        /// </remarks>
        public virtual decimal? OverriddenGiftCardAmount { get; set; } = null;

        #endregion

        #region Product to download

        /// <summary>
        /// Set a value indicating whether the product is download.
        /// </summary>
        /// <remarks>
        /// Check if the product is downloadable. When customers purchase a downloadable product, they can download it directly from your store. 
        /// The link will be visible after checkout. Please note that it's recommended to use the 'Use download URL' feature for large files (instead of uploading them to the database).
        /// Default is False.
        /// </remarks>
        public virtual bool IsDownload { get; set; } = false;

        /// <summary>
        /// Set the download identifier from Entity Download.
        /// </summary>
        /// <remarks>
        /// Default is 0.
        /// </remarks>
        public virtual int DownloadId { get; set; } = 0;

        /// <summary>
        /// Set a value indicating whether this downloadable product can be downloaded unlimited number of times.
        /// </summary>
        /// <remarks>
        /// Default is false.
        /// </remarks>
        public virtual bool UnlimitedDownloads { get; set; } = false;

        /// <summary>
        /// Set the maximum number of downloads. 
        /// </summary>
        /// <remarks>
        /// UnlimitedDownloads has to be false if you want to use this function.
        /// Default is 10.
        /// </remarks>
        public virtual int MaxNumberOfDownloads { get; set; } = 10;

        /// <summary>
        /// Set the number of days during customers keeps access to the file.
        /// </summary>
        /// <remarks>
        /// The number of days during customers keeps access to the file (e.g. 14). 
        /// Leave this field null to allow continuous downloads.        
        /// Default is null.
        /// </remarks>
        public virtual int? DownloadExpirationDays { get; set; } = null;

        /// <summary>
        /// Set the download activation type.
        /// </summary>
        /// <remarks>
        /// Defines the download activation type (compatible with 4.70.3).
        /// WhenOrderIsPaid (0): Activation occurs when the order is paid.
        /// Manually (10): Activation occurs manually.
        /// Default is 0.
        /// </remarks>
        public virtual int DownloadActivationTypeId { get; set; } = 0;

        /// <summary>
        /// Set a value indicating whether the product has a sample download file.
        /// </summary>
        /// <remarks>
        /// You can download file using URL or uploading from the computer. 
        /// If you want to download file using URL check the box Use download URL.
        /// Defaul is false.
        /// </remarks>
        public virtual bool HasSampleDownload { get; set; } = false;

        /// <summary>
        /// Set the sample download identifier.
        /// </summary>
        /// <remarks>
        /// Default is 0.
        /// </remarks>
        public virtual int SampleDownloadId { get; set; } = 0;

        /// <summary>
        /// Set a value indicating whether the product has user agreement.
        /// </summary>
        /// <remarks>
        /// Default is false.
        /// </remarks>
        public virtual bool HasUserAgreement { get; set; } = false;

        /// <summary>
        /// Set the text of license agreement.
        /// </summary>
        /// <remarks>
        /// Default is null.
        /// </remarks>
        public virtual string? UserAgreementText { get; set; } = null;

        #endregion

        #region Recurring

        /// <summary>
        /// Set a value indicating whether the product is recurring.
        /// </summary>
        /// <remarks>
        /// Check if it is a recurring product. For any product, you can define a recurring cycle to enable the system .
        /// to automatically create orders that repeat when a customer purchases such products.
        /// Default is false.
        /// </remarks>
        public virtual bool IsRecurring { get; set; } = false;

        /// <summary>
        /// Set the cycle length.
        /// </summary>
        /// <remarks>
        /// Specify the cycle length. It is a time period recurring order can be repeated.
        /// Default is 100.
        /// </remarks>
        public virtual int RecurringCycleLength { get; set; } = 100;

        /// <summary>
        /// Set the cycle period.
        /// </summary>
        /// <remarks>
        /// Specify the cycle period. It defines units time period can be measured in.
        /// Defines the cycle period for a recurring product.
        /// Days (0): The cycle is in days.
        /// Weeks (10): The cycle is in weeks.
        /// Months (20): The cycle is in months.
        /// Years (30): The cycle is in years.
        /// Default is 0.
        /// </remarks>
        public virtual int RecurringCyclePeriodId { get; set; } = 0;

        /// <summary>
        /// Set the total cycles.
        /// </summary>
        /// <remarks>
        /// Total cycles are number of times customer will receive the recurring product.
        /// Default is 10.
        /// </remarks>
        public virtual int RecurringTotalCycles { get; set; } = 10;

        #endregion

        #region Rental

        /// <summary>
        /// Set a value indicating whether the product is rental
        /// </summary>
        /// <remarks>
        /// Check if this is a rental product (price is set for some period). Please note that inventory management is not fully 
        /// supported for rental products yet. It's recommended to set 'Manage inventory method' to 'Don't track inventory' now.
        /// Default is false
        /// </remarks>
        public virtual bool IsRental { get; set; } = false;

        /// <summary>
        /// Set the rental length for some period (price for this period)
        /// </summary>
        /// <remarks>
        /// Price is specified for this period.
        /// Default is 1.
        /// </remarks>
        public virtual int RentalPriceLength { get; set; } = 1;

        /// <summary>
        /// Set the rental period (price for this period)
        /// </summary>
        /// <remarks>
        /// Defines the cycle period for a rental period.
        /// Days (0): The cycle is in days.
        /// Weeks (10): The cycle is in weeks.
        /// Months (20): The cycle is in months.
        /// Years (30): The cycle is in years.
        /// Default is 0.
        /// </remarks>
        public virtual int RentalPricePeriodId { get; set; } = 0;

        #endregion

        #region Shipping

        /// <summary>
        /// Set a value indicating whether the entity is ship enabled.
        /// </summary>
        /// <remaks>
        /// Check if the product can be shipped. You can manage shipping settings by selecting Configuration > Shipping.
        /// Default = true.
        /// </remaks>
        public virtual bool IsShipEnabled { get; set; } = true;

        /// <summary>
        /// Set a value indicating whether the entity is free shipping.
        /// </summary>
        /// <remarks>
        /// Check if this product comes with FREE shipping.
        /// Default is false.
        /// </remarks>
        public virtual bool IsFreeShipping { get; set; } = false;

        /// <summary>
        /// Set a value this product should be shipped separately (each item).
        /// </summary>
        /// <remarks>
        /// Check if the product should be shipped separately from other products (in single box). 
        /// But notice that if the order includes several items of this product, 
        /// all of them will be shipped in single box.
        /// Default is false.
        /// </remarks>
        public virtual bool ShipSeparately { get; set; } = false;

        /// <summary>
        /// Set the additional shipping charge.
        /// </summary>
        /// <remarks>
        /// Default is 10m.
        /// </remarks>
        public virtual decimal AdditionalShippingCharge { get; set; } = 10m;

        /// <summary>
        /// Set a delivery date identifier
        /// </summary>
        /// <remarks>
        /// Choose a delivery date which will be displayed in the public store. 
        /// You can manage delivery dates by selecting Configuration > Shipping > Dates and ranges.
        /// Default is 0.
        /// </remarks>
        public virtual int DeliveryDateId { get; set; } = 0;

        #endregion

        #region Inventory

        /// <summary>
        /// Set a value indicating how to manage inventory
        /// </summary>
        /// <remarks>
        /// ManageInventoryMethod: Enumerates methods of inventory management.
        /// - DontManageStock (0): Do not track inventory for the product.
        /// - ManageStock (1): Track inventory for the product.
        /// - ManageStockByAttributes (2): Track inventory for the product by product attributes.
        /// Default is 0.
        /// </remarks>
        public virtual int ManageInventoryMethodId { get; set; } = 0;

        /// <summary>
        /// Set the stock quantity
        /// </summary>
        /// <remarks>
        /// The current stock quantity of this product.
        /// Enabled only if ManageInventoryMethodId is set to ManageStock (1)
        /// Default is 1000.
        /// </remarks>
        public virtual int StockQuantity { get; set; } = 1000;


        // TODO - find ProductAvailabilityRange
        /// <summary>
        /// Set a product availability range identifier.
        /// </summary>
        /// <remarks>
        /// Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// Choose the product availability range that indicates when the product is expected to be 
        /// available when out of stock (e.g. Available in 10-14 days). 
        /// You can manage availability ranges by selecting Configuration > Shipping > Dates and ranges.
        /// Check ProductAvailabilityRange for more details.
        /// Default is o.
        /// </remarks>
        public virtual int ProductAvailabilityRangeId { get; set; } = 0;

        /// <summary>
        /// Set a value indicating whether multiple warehouses are used for this product
        /// </summary>
        /// <remarks>
        /// Enabled only if ManageInventoryMethodId is set to ManageStock (1) 
        /// Check if you want to support shipping and inventory management from multiple warehouses.
        /// Default is false.
        /// </remarks>
        public virtual bool UseMultipleWarehouses { get; set; } = false;

        /// <summary>
        /// Set a warehouse identifier
        /// </summary>
        /// <remarks>
        /// Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// Default is 0.
        /// </remarks>
        public virtual int WarehouseId { get; set; } = 0;

        /// <summary>
        /// Set a value indicating whether to display stock availability
        /// </summary>
        /// <remarks>
        /// Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// Check to display stock availability. When enabled, customers will see stock availability.
        /// Default is false.
        /// </remarks>
        public virtual bool DisplayStockAvailability { get; set; } = false;

        /// <summary>
        /// Set a value indicating whether to display stock quantity
        /// </summary>
        /// <remarks>
        /// Enabled if DisplayStockAvailability is true.
        /// Check to display stock quantity. When enabled, customers will see stock quantity.
        /// Default is False
        /// </remarks>
        public virtual bool DisplayStockQuantity { get; set; } = false;

        /// <summary>
        /// Set the minimum stock quantity
        /// </summary>
        /// <remarks>
        /// Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)        
        /// If you track inventory, you can perform a number of different actions when the current stock 
        /// quantity falls below (reaches) your minimum stock quantity.
        /// Default is 0.
        /// </remarks>
        public virtual int MinStockQuantity { get; set; } = 0;

        /// <summary>
        /// Set the low stock activity identifier
        /// </summary>
        /// <remarks>
        /// Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// Action to be taken when your current stock quantity falls below (reaches) the 'Minimum stock quantity'. 
        /// Activation of the action will occur only after an order is placed. If the value is 'Nothing', 
        /// the product detail page will display a low-stock message in public store.
        /// LowStockActivity: Enumerates actions to be taken when product stock is low.
        /// - Nothing (0): Do not take any action.
        /// - DisableBuyButton (1): Disable the buy button for the product.
        /// - Unpublish (2): Unpublish the product, making it unavailable for purchase.
        /// Default is 0.
        /// </remarks>
        public virtual int LowStockActivityId { get; set; } = 0;

        /// <summary>
        /// Set the quantity when admin should be notified
        /// </summary>
        /// <remarks>
        /// Enabled only if ManageInventoryMethodId is set to ManageStock (1) 
        /// When the current stock quantity falls below (reaches) this quantity, a store owner will receive a notification.
        /// Default is 1.
        /// </remarks>
        public virtual int NotifyAdminForQuantityBelow { get; set; } = 1;

        /// <summary>
        /// Set a value backorder mode identifier
        /// </summary>
        /// <remarks>
        /// BackorderModeId: Identifies the backorder mode for the product.
        /// - NoBackorders (0): No backorders are allowed.
        /// - AllowQtyBelow0 (1): Allow quantity below 0.
        /// - AllowQtyBelow0AndNotifyCustomer (2): Allow quantity below 0 and notify customer.
        /// Default is 0;
        /// </remarks>
        public virtual int BackorderModeId { get; set; } = 0;

        /// <summary>
        /// Set a value indicating whether to back in stock subscriptions are allowed
        /// </summary>
        /// <remarks>
        /// Enabled only if ManageInventoryMethodId is set to ManageStock (1)
        /// Allow customers to subscribe to a notification list for a product that has gone out of stock.
        /// Default is false.
        /// </remarks>
        public virtual bool AllowBackInStockSubscriptions { get; set; } = false;

        /// <summary>
        /// Set the order minimum quantity
        /// </summary>
        /// <remarks>
        /// Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// Set the minimum quantity allowed in a customer's shopping cart e.g. set to 3 to only allow customers to purchase 3 or more of this product.
        /// Default is 1.
        /// </remarks>

        public virtual int OrderMinimumQuantity { get; set; } = 1;

        /// <summary>
        /// Set the order maximum quantity
        /// </summary>
        /// <remarks>
        /// Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// Set the maximum quantity allowed in a customer's shopping cart e.g. set to 5 to only allow customers to purchase 5 of this product.
        /// Default is 1000.
        /// </remarks>
        public virtual int OrderMaximumQuantity { get; set; } = 1000;

        /// <summary>
        /// Set a value indicating whether this product is returnable (a customer is allowed to submit return request with this product)
        /// </summary>
        /// <remarks>
        /// Check if this product is not returnable. In this case a customer won't be allowed to submit return request.
        /// </remarks>
        public virtual bool NotReturnable { get; set; }

        /// <summary>
        /// Set the comma separated list of allowed quantities. null or empty if any quantity is allowed.
        /// </summary>
        /// <remarks>
        /// Instead of a quantity textbox that allows them to enter any quantity, they will receive a dropdown list of the values you enter here.        
        /// For example - if you type "10,20,30" then the customer will only be able to select one of those quantities.
        /// Default it's set to null.
        /// </remarks>
        public virtual string? AllowedQuantities { get; set; } = null;

        #endregion

        #region Attribute

        /// <summary>
        /// Set a value indicating whether we allow adding to the cart/wishlist only attribute combinations that exist and have stock greater than zero.
        /// </summary>
        /// <remarks>
        /// This option is used only when we have "manage inventory" set to "track inventory by product attributes"
        /// Default is false.
        /// </remarks>
        public virtual bool AllowAddingOnlyExistingAttributeCombinations { get; set; } = false;

        /// <summary>
        /// Set a value indicating whether to display attribute combination images only
        /// </summary>
        /// <remarks>
        /// Default is false.
        /// </remarks>
        public virtual bool DisplayAttributeCombinationImagesOnly { get; set; } = false;
        #endregion

        #region Price

        /// <summary>
        /// Set a value indicating whether to disable buy (Add to cart) button
        /// </summary>
        /// <remarks>
        /// Check to disable the buy button for this product. This may be necessary for products that are 'available upon request'.
        /// Default is false.
        /// </remarks>
        public virtual bool DisableBuyButton { get; set; } = false;

        /// <summary>
        /// Set a value indicating whether to disable "Add to wishlist" button
        /// </summary>
        /// <remarks>
        /// Default is false.
        /// </remarks>
        public virtual bool DisableWishlistButton { get; set; } = false;

        /// <summary>
        /// Set a value indicating whether this item is available for Pre-Order
        /// </summary>
        /// <remarks>
        /// Check if this item is available for Pre-Order. It also displays "Pre-order" button instead of "Add to cart".
        /// Disable is false.
        /// </remarks>
        public virtual bool AvailableForPreOrder { get; set; } = false;

        /// <summary>
        /// Set the start date and time of the product availability (for pre-order products)
        /// </summary>
        /// <remarks>
        /// Only active with AvailableForPreOrder = true
        /// The availability start date of the product configured for pre-order in Coordinated Universal Time (UTC). 
        /// 'Pre-order' button will automatically be changed to 'Add to cart' at this moment.
        /// Default is null.
        /// </remarks>
        public virtual DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; } = null;

        /// <summary>
        /// Set the price
        /// </summary>
        /// <remarks>
        /// The price of the product. You can manage currency by selecting Configuration > Currencies.
        /// </remarks>
        public virtual decimal Price { get; set; }

        /// <summary>
        /// Set the old price
        /// </summary>
        /// <remarks>
        /// The old price of the product. If you set an old price, this will display alongside the 
        /// current price on the product page to show the difference in price.
        /// If is 0, old price will not show on product site
        /// Defaul is 0.
        /// </remarks>
        public virtual decimal OldPrice { get; set; } = 0;

        /// <summary>
        /// Set the product cost
        /// </summary>
        /// <remarks>
        /// Product cost is a prime product cost. This field is only for internal use, not visible for customers.
        /// </remarks>
        public virtual decimal ProductCost { get; set; }

        /// <summary>
        /// Set a value indicating whether to show "Call for Pricing" or "Call for quote" instead of price
        /// </summary>
        /// <remarks>
        /// Check to show "Call for Pricing" or "Call for quote" instead of price.
        /// Default is false
        /// </remarks>
        public virtual bool CallForPrice { get; set; } = false;

        /// <summary>
        /// Set a value indicating whether a customer enters price
        /// </summary>
        /// <remarks>
        /// An option indicating whether customer should enter price.
        /// Default is false
        /// </remarks>
        public virtual bool CustomerEntersPrice { get; set; } = false;

        /// <summary>
        /// Set the minimum price entered by a customer.
        /// </summary>
        /// <remarks>
        /// Only if CallForPrice is enabled.
        /// Defaul is 0.
        /// </remarks>
        public virtual decimal MinimumCustomerEnteredPrice { get; set; } = 0;

        /// <summary>
        /// Set the maximum price entered by a customer
        /// </summary>
        /// <remarks>
        /// Only if CallForPrice is enabled.
        /// Defaul is 0.
        /// </remarks>
        public virtual decimal MaximumCustomerEnteredPrice { get; set; } = 0;

        /// <summary>
        /// Set a value indicating whether base price (PAngV) is enabled. Used by German users.
        /// </summary>
        /// <remarks>
        /// Check to display baseprice of a product. This is required according to the German law (PAngV). 
        /// If you sell 500ml of beer for 1,50 euro, then you have to display baseprice: 3.00 euro per 1L.
        /// Default is false.
        /// </remarks>
        public virtual bool BasepriceEnabled { get; set; } = false;

        /// <summary>
        /// Set an amount in product for PAngV
        /// </summary>
        /// <remarks>
        /// Only id BasepriceEnabled is enabled
        /// default is 0m.
        /// </remarks>
        public virtual decimal BasepriceAmount { get; set; } = 0;

        /// <summary>
        /// Set a unit of product for PAngV (MeasureWeight entity)
        /// </summary>
        /// <remarks>
        /// Only if BasepriceEnabled is enabled
        /// default is 3.
        /// </remarks>
        public virtual int BasepriceUnitId { get; set; } = 3;

        /// <summary>
        /// Set a reference amount for PAngV
        /// </summary>
        /// <remarks>
        /// Only id BasepriceEnabled is enabled
        /// default is 0m.
        /// </remarks>
        public virtual decimal BasepriceBaseAmount { get; set; } = 0;

        /// <summary>
        /// Set a reference unit for PAngV (MeasureWeight entity)
        /// </summary>
        /// <remarks>
        /// Only id BasepriceEnabled is enabled
        /// default is 3.
        /// </remarks>
        public virtual int BasepriceBaseUnitId { get; set; } = 3;

        /// <summary>
        /// Set a value indicating whether the product is marked as tax exempt
        /// </summary>
        /// <remarks>
        /// Determines whether this product is tax exempt (tax will not be applied to this product at checkout).
        /// Default is false.
        /// </remarks>
        public virtual bool IsTaxExempt { get; set; } = false;

        /// <summary>
        /// Set the tax category identifier
        /// </summary>
        /// <remarks>
        /// Look on TaxCategory schema for more details.
        /// </remarks>
        public virtual int TaxCategoryId { get; set; }

        /// <summary>
        /// Set a value indicating whether this product has discounts applied
        /// </summary>
        /// <remarks>
        /// The same as if we run AppliedDiscounts.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load Applied Discounts navigation property
        /// Default is false.
        /// </remarks>
        public virtual bool HasDiscountsApplied { get; set; } = false;

        /// <summary>
        /// Set a value indicating whether this product has tier prices configured
        /// </summary>
        /// <remarks>
        /// The same as if we run TierPrices.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load tier prices navigation property
        /// Default is true.
        /// </remarks>
        public virtual bool HasTierPrices { get; set; } = true;

        #endregion

        #region Shipping

        /// <summary>
        /// Set the weight
        /// </summary>
        /// <remarks>
        /// To set mesasures go to Configuration → Shipping → Measures 
        /// </remarks>
        public virtual decimal Weight { get; set; }

        /// <summary>
        /// Set the length
        /// </summary>
        /// <remarks>
        /// To set mesasures go to Configuration → Shipping → Measures 
        /// </remarks>
        public virtual decimal Length { get; set; }

        /// <summary>
        /// Set the width
        /// </summary>
        /// <remarks>
        /// To set mesasures go to Configuration → Shipping → Measures 
        /// </remarks>
        public virtual decimal Width { get; set; }

        /// <summary>
        /// Set the height
        /// </summary>
        /// <remarks>
        /// To set mesasures go to Configuration → Shipping → Measures 
        /// </remarks>
        public virtual decimal Height { get; set; }

        #endregion
    }
}
