using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Product
{
    /// <summary>
    /// ProductCreateDefault is used for creating a new product with default values
    /// </summary>
    /// <remarks>
    /// This class is used for inheritance for dto to create a product.
    /// </remarks>
    public class ProductCreateDefault : BaseDto
    {
        #region Product information

        /// <summary>
        /// ## ShortDescription
        /// ### Short description is the text that is displayed in product list i.e. category / manufacturer pages.
        /// </summary>
        [JsonIgnore] public virtual string? ShortDescription { get; set; }

        /// <summary>
        /// ## FullDescription
        /// ### Full description is the text that is displayed in product page.
        /// </summary>
        [JsonIgnore] public virtual string? FullDescription { get; set; }


        /// <summary>
        /// ## ManufacturerPartNumber
        /// ### Set the manufacturer part number.
        /// </summary>
        [JsonIgnore] public virtual string? ManufacturerPartNumber { get; set; }

        /// <summary>        
        /// ## Published
        /// ### Set a value indicating whether the entity is published.
        /// *Default = false*
        /// </summary>        
        [JsonIgnore] public virtual bool Published { get; set; } = false;

        /// <summary>
        /// ## Deleted
        /// ### Set a value indicating whether the entity has been deleted.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool Deleted { get; set; } = false;

        /// <summary>
        /// ## Gtin
        /// ### Set the Global Trade Item Number (GTIN). 
        /// #### These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books).
        /// *Default = null*
        /// </summary>
        [JsonIgnore] public virtual string? Gtin { get; set; }

        /// <summary>
        /// ## ProductTypeId 
        /// ### Set the product type identifier.
        /// #### Product type can be simple or grouped. In most cases your product will have the Simple product type. 
        /// #### You need to use Grouped product type when a new product consists of one or more existing products that will be displayed on one single product details page.
        /// ** Note: enum ProductType Ids (compatible with 4.70.3) **
        /// * SimpleProduct (5): A simple product. (*Default setting*)
        /// * GroupedProduct (10): A grouped product (product with variants).
        /// </summary>
        [JsonIgnore] public virtual int ProductTypeId { get; set; } = 5;

        /// <summary>
        /// ## ProductTemplateId
        /// ### Choose a product template. This template defines how this product will be displayed in [JsonIgnore] public store.
        /// #### Look on ProductTemplate for more details.
        /// #### In nopCommerce, you can specify an alternate layout template for a category, manufacturer, product, and topic. You can see a list of the existing templates on the System → Templates page.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/system-administration/templates.html
        /// *Default = 1 (Simple Product)*
        /// </summary>
        [JsonIgnore] public virtual int ProductTemplateId { get; set; } = 1;

        /// <summary>
        /// ## VendorId
        /// ### Gets or sets the vendor identifier with which this customer is associated (manager)
        /// #### Choose a vendor associated with this product. This can be useful when running a multi-vendor store to keep track of goods associated with vendor.
        /// #### If is not multi-vendor store, then this field should be set to 0.   
        /// *Default = 0*
        /// </summary>
        [JsonIgnore] public virtual int VendorId { get; set; } = 0;

        /// <summary>
        /// ## RequireOtherProducts
        /// ### Set a value indicating whether the product requires that other products are added to the cart (Product X requires Product Y).
        /// #### If you set to true you have use RequiredProductIds.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool RequireOtherProducts { get; set; } = false;

        /// <summary>
        /// ## RequiredProductIds
        /// ### Set a required product identifiers (comma separated).
        /// #### Specify comma separated list of required product IDs. NOTE: Ensure that there are no circular references (for example, A requires B, and B requires A).
        /// #### It's only work when RequireOtherProducts = true.
        /// *Default = null*
        /// </summary>
        [JsonIgnore] public virtual string? RequiredProductIds { get; set; }

        /// <summary>
        /// ## AutomaticallyAddRequiredProducts
        /// ### Set a value indicating whether required products (RequiredProductIds) are automatically added to the cart.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool AutomaticallyAddRequiredProducts { get; set; } = false;

        /// <summary>
        /// ## ShowOnHomepage
        /// ### Gets or sets a value indicating whether to display this product on your store's home page. Recommended for your most popular products.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool ShowOnHomepage { get; set; } = false;

        /// <summary>
        /// ## ShowOnHomepage
        /// ### Set a display order.
        /// #### This value is used when sorting associated products (used with "grouped" products).
        /// #### This value is used when sorting home page products.
        /// *Default = 0*
        /// </summary>
        [JsonIgnore] public virtual int DisplayOrder { get; set; } = 0;

        /// <summary>
        /// ## ParentGroupedProductId
        /// ### Set the parent product identifier. It's used to identify associated products (only with "grouped" products).
        /// #### Products in nopCommerce have two different types, simple products and grouped products. 
        /// #### Grouped products let you stablish a hierarchical relation between them. As an easy example, 
        /// #### you can imagine a perfume (parent product) that has associated two simple products (small size and big size).
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/grouped-products-variants.html
        /// *Default = 0*
        /// </summary>
        [JsonIgnore] public virtual int ParentGroupedProductId { get; set; } = 0;

        /// <summary>
        /// ## VisibleIndividually
        /// ### Set the values indicating whether this product is visible in catalog or search results.
        /// #### It's used when this product is associated to some "grouped" one.
        /// #### This way associated products could be accessed/added/etc only from a grouped product details page.
        /// *Default = true*
        /// </summary>
        [JsonIgnore] public virtual bool VisibleIndividually { get; set; } = true;

        /// <summary>
        /// ## SubjectToAcl
        /// ### ACL - Access Control List (ACL) restricts or grants users access to certain areas of the site. This list is managed by administrators.
        /// #### Set a value indicating whether the entity is subject to ACL.
        /// *Default = true*
        /// </summary>
        [JsonIgnore] public virtual bool SubjectToAcl { get; set; } = true;

        /// <summary>
        /// ## LimitedToStores
        /// ### Set a value indicating whether the entity is limited/restricted to certain stores.
        /// #### Option to limit this product to a certain store. If you have multiple stores, choose one or several from the list. 
        /// #### If you don't use this option just leave this field empty. In order to use this functionality, you have to disable the 
        /// #### following setting: Catalog settings > Ignore ACL rules.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool LimitedToStores { get; set; } = false;

        /// <summary>
        /// ## AvailableStartDateTimeUtc
        /// ### Set the start product available to customers at start date
        /// *Default = null*
        /// </summary>
        [JsonIgnore] public virtual DateTime? AvailableStartDateTimeUtc { get; set; }

        /// <summary>
        /// ## AvailableEndDateTimeUtc
        /// ### Set the available end date and time.
        /// #### Set the end of the product available to customers on the end date
        /// *Default = null*
        /// </summary>
        [JsonIgnore] public virtual DateTime? AvailableEndDateTimeUtc { get; set; }

        /// <summary>
        /// ## MarkAsNew
        /// ### Set a value indicating whether this product is marked as new.
        /// #### Check to mark the product as new. Use this option for promoting new products.
        /// *Default = true*
        /// </summary>
        [JsonIgnore] public virtual bool MarkAsNew { get; set; } = true;

        /// <summary>
        /// ## MarkAsNewStartDateTimeUtc
        /// ### Set the start date and time of the new product (set product as "New" from date). Leave empty to ignore this property.
        /// #### Only enabled if MarkAsNew is false.
        /// #### Set Product as New from Date in Coordinated Universal Time (UTC).
        /// *Default = null*
        /// </summary>
        [JsonIgnore] public virtual DateTime? MarkAsNewStartDateTimeUtc { get; set; }

        /// <summary>
        /// ## MarkAsNewEndDateTimeUtc
        /// ### Set the end date and time of the new product (set product as "New" to date). Leave empty to ignore this property.
        /// #### Only enabled if MarkAsNew is false.
        /// #### Set Product as New to Date in Coordinated Universal Time (UTC).
        /// *Default = null*
        /// </summary>
        [JsonIgnore] public virtual DateTime? MarkAsNewEndDateTimeUtc { get; set; }

        /// <summary>
        /// ## AdminComment
        /// ### This comment is for internal use only, not visible for customers.
        /// *Defaul = null*
        /// </summary>
        [JsonIgnore] public virtual string? AdminComment { get; set; }

        /// <summary>
        /// ## CreatedOnUtc
        /// ### Set the date and time of product creation.
        /// *Default = DateTime.Now*
        /// </summary>
        [JsonIgnore] public virtual DateTime CreatedOnUtc { get; set; } = DateTime.Now;

        /// <summary>
        /// ## UpdatedOnUtc
        /// ### Set the date and time of product update.
        /// *Default = DateTime.Now*
        /// </summary>
        [JsonIgnore] public virtual DateTime UpdatedOnUtc { get; set; } = DateTime.Now;

        #endregion

        #region SEO

        /// <summary>
        /// ## MetaKeywords 
        /// ### Set the meta keywords.
        /// </summary>
        [JsonIgnore] public virtual string? MetaKeywords { get; set; }

        /// <summary>
        /// ## MetaTitle
        /// ### Set the meta description.
        /// </summary>
        [JsonIgnore] public virtual string? MetaTitle { get; set; }

        /// <summary>
        /// ## MetaDescription
        /// ### Meta description to be added to product page header.
        /// </summary>
        [JsonIgnore] public virtual string? MetaDescription { get; set; }

        #endregion

        #region Rating

        /// <summary>
        /// ## ApprovedRatingSum
        /// ### Set the rating sum (approved reviews).
        /// #### Look on Configuration → Settings → Catalog settings for more details.
        /// #### When required is set in new review type, customers have to choose an appropriate rating value before they can continue.
        /// *Default = 0 (not approved)*
        /// </summary>
        [JsonIgnore] public virtual int ApprovedRatingSum { get; set; } = 0;

        /// <summary>
        /// ## NotApprovedRatingSum
        /// ### Set the rating sum (not approved reviews).
        /// #### Look on Configuration → Settings → Catalog settings for more details.
        /// *Default = 0 (not approved)*
        /// </summary>
        [JsonIgnore] public virtual int NotApprovedRatingSum { get; set; } = 0;

        #endregion

        #region Reviews

        /// <summary>
        /// ## AllowCustomerReviews
        /// ### Set a value indicating whether the product allows customer reviews.
        /// #### By default, the reviews must be approved by the store owner before they appear in the [JsonIgnore] public store. 
        /// #### However, in case a store owner decides that reviews do not have to be approved, this default behavior can be changed. 
        /// #### To opt out of the obligatory product reviews' approval, go to Configuration → Settings → Catalog settings and clear the Product reviews must be approved option.
        /// *Default = false*
        /// </summary>

        [JsonIgnore] public virtual bool AllowCustomerReviews { get; set; } = false;

        /// <summary>
        /// ## ApprovedTotalReviews
        /// ### Set the total rating votes (approved reviews).
        /// #### Look on Configuration → Settings → Catalog settings for more details.
        /// *Default = 0 (not approved)*
        /// </summary>
        [JsonIgnore] public virtual int ApprovedTotalReviews { get; set; } = 0;

        /// <summary>
        /// ## NotApprovedTotalReviews
        /// ### Set the total rating votes (not approved reviews).
        /// #### Look on Configuration → Settings → Catalog settings for more details.
        /// *Default = 0 (not approved)*
        /// </summary>
        [JsonIgnore] public virtual int NotApprovedTotalReviews { get; set; } = 0;

        #endregion

        #region Gift Card

        /// <summary>
        /// ## IsGiftCard
        /// ### Set a value indicating whether the product is gift card.
        /// #### Check if it is a gift card. After adding gift card products to the shopping cart and completing the purchases, 
        /// #### you can then search and view the list of all the purchased gift cards by selecting Gift Cards from the Sales menu.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool IsGiftCard { get; set; } = false;

        /// <summary>
        /// ## GiftCardTypeId
        /// ### Set the gift card type identifier.
        /// ** Note: Defines the type of gift card **
        /// * virtual (0): A virtual gift card. (Default setting)
        /// * Physical (1): A physical gift card.
        /// </summary>
        [JsonIgnore] public virtual int GiftCardTypeId { get; set; } = 0;

        /// <summary>
        /// ## OverriddenGiftCardAmount
        /// ### Set gift card amount that can be used after purchase. If not specified, then product price will be used.
        /// *Default = null*
        /// </summary>
        [JsonIgnore] public virtual decimal? OverriddenGiftCardAmount { get; set; }

        #endregion

        #region Product to download

        /// <summary>
        /// ## IsDownload
        /// ### Set a value indicating whether the product is download.
        /// #### Check if the product is downloadable. When customers purchase a downloadable product, they can download it directly from your store. 
        /// #### The link will be visible after checkout. Please note that it's recommended to use the 'Use download URL' feature for large files (instead of uploading them to the database).
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Default = False*
        /// </summary>
        [JsonIgnore] public virtual bool IsDownload { get; set; } = false;

        /// <summary>
        /// ## DownloadId
        /// ### Set the download identifier from Entity Download.
        /// #### The downloadable products functionality is useful when you are going to sell e-books or audiobooks, courses, PDFs, music, software or you want to create a picture stock, for example.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Default = 0*
        /// </summary>
        [JsonIgnore] public virtual int DownloadId { get; set; } = 0;

        /// <summary>
        /// ## UnlimitedDownloads
        /// ### Set a value indicating whether this downloadable product can be downloaded unlimited number of times.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool UnlimitedDownloads { get; set; } = false;

        /// <summary>
        /// ## MaxNumberOfDownloads
        /// ### the maximum number of downloads. 
        /// #### UnlimitedDownloads has to be false if you want to use this function.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Default is 10*
        /// </summary>
        [JsonIgnore] public virtual int MaxNumberOfDownloads { get; set; } = 10;

        /// <summary>
        /// ## DownloadExpirationDays
        /// ### Set the number of days during customers keeps access to the file.
        /// #### The number of days during customers keeps access to the file (e.g. 14). 
        /// #### Leave this field null to allow continuous downloads.        
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Default = null*
        /// </summary>
        [JsonIgnore] public virtual int? DownloadExpirationDays { get; set; }

        /// <summary>
        /// ## DownloadActivationTypeId
        /// ### Set the download activation type.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// ** Defines the download activation type (compatible with 4.70.3) **
        /// * WhenOrderIsPaid (0): Activation occurs when the order is paid. (default setting)
        /// * Manually (10): Activation occurs manually.        
        /// </summary>
        [JsonIgnore] public virtual int DownloadActivationTypeId { get; set; } = 0;

        /// <summary>
        /// ## HasSampleDownload
        /// ### Set a value indicating whether the product has a sample download file.
        /// #### You can download file using URL or uploading from the computer. 
        /// #### If you want to download file using URL check the box Use download URL.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Defaul = false*
        /// </summary>
        [JsonIgnore] public virtual bool HasSampleDownload { get; set; } = false;

        /// <summary>
        /// ## SampleDownloadId
        /// ### Set the sample download identifier.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Default = 0*
        /// </summary>
        [JsonIgnore] public virtual int SampleDownloadId { get; set; } = 0;

        /// <summary>
        /// ## HasUserAgreement
        /// ### Set a value indicating whether the product has user agreement.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool HasUserAgreement { get; set; } = false;

        /// <summary>
        /// ## UserAgreementText
        /// ### Set the text of license agreement.
        /// *Default = null*
        /// </summary>
        [JsonIgnore] public virtual string? UserAgreementText { get; set; }

        #endregion

        #region Recurring

        /// <summary>
        /// ## IsRecurring
        /// ### Set a value indicating whether the product is recurring.
        /// #### Check if it is a recurring product. For any product, you can define a recurring cycle to enable the system .
        /// #### to automatically create orders that repeat when a customer purchases such products.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool IsRecurring { get; set; } = false;

        /// <summary>
        /// ## RecurringCycleLength
        /// ### Set the cycle length.
        /// #### Specify the cycle length. It is a time period recurring order can be repeated.
        /// *Default = 100*
        /// </summary>
        [JsonIgnore] public virtual int RecurringCycleLength { get; set; } = 100;

        /// <summary>
        /// ## RecurringCyclePeriodId
        /// ### Set the cycle period.
        /// #### Specify the cycle period. It defines units time period can be measured in.
        /// ** Defines the cycle period for a recurring product **
        /// * Days (0): The cycle is in days. (default setting)
        /// * Weeks (10): The cycle is in weeks.
        /// * Months (20): The cycle is in months.
        /// * Years (30): The cycle is in years.
        /// </summary>
        [JsonIgnore] public virtual int RecurringCyclePeriodId { get; set; } = 0;

        /// <summary>
        /// ## RecurringTotalCycles
        /// ### Set the total cycles.
        /// #### Total cycles are number of times customer will receive the recurring product.
        /// *Default = 10*
        /// </summary>
        [JsonIgnore] public virtual int RecurringTotalCycles { get; set; } = 10;

        #endregion

        #region Rental

        /// <summary>
        /// ## IsRental
        /// ### Set a value indicating whether the product is rental
        /// #### Check if this is a rental product (price is set for some period). Please note that inventory management is not fully 
        /// #### supported for rental products yet. It's recommended to set 'Manage inventory method' to 'Don't track inventory' now.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool IsRental { get; set; } = false;

        /// <summary>
        /// ## RentalPriceLength
        /// ### Set the rental length for some period (price for this period)
        /// #### Price is specified for this period.
        /// *Default = 1*
        /// </summary>
        [JsonIgnore] public virtual int RentalPriceLength { get; set; } = 1;

        /// <summary>
        /// ## RentalPricePeriodId
        /// ### Set the rental period (price for this period)
        /// ** Defines the cycle period for a rental period **
        /// * Days (0): The cycle is in days. (default setting)
        /// * Weeks (10): The cycle is in weeks.
        /// * Months (20): The cycle is in months.
        /// * Years (30): The cycle is in years.
        /// </summary>
        [JsonIgnore] public virtual int RentalPricePeriodId { get; set; } = 0;

        #endregion

        #region Shipping

        /// <summary>
        /// ## IsShipEnabled
        /// ### Set a value indicating whether the entity is ship enabled.
        /// #### Check if the product can be shipped. You can manage shipping settings by selecting Configuration > Shipping.
        /// *Default = true*
        /// </remaks>
        [JsonIgnore] public virtual bool IsShipEnabled { get; set; } = true;

        /// <summary>
        /// ## IsFreeShipping
        /// ### Set a value indicating whether the entity is free shipping.
        /// #### Check if this product comes with FREE shipping.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool IsFreeShipping { get; set; } = false;

        /// <summary>
        /// ## ShipSeparately
        /// ### Set a value this product should be shipped separately (each item).
        /// #### Check if the product should be shipped separately from other products (in single box). 
        /// #### But notice that if the order includes several items of this product, 
        /// #### all of them will be shipped in single box.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool ShipSeparately { get; set; } = false;

        /// <summary>
        /// ## AdditionalShippingCharge
        /// ### Set the additional shipping charge.
        /// *Default = 10m.*
        /// </summary>
        [JsonIgnore] public virtual decimal AdditionalShippingCharge { get; set; } = 10m;

        /// <summary>
        /// ## DeliveryDateId
        /// ### Set a delivery date identifier
        /// #### Choose a delivery date which will be displayed in the [JsonIgnore] public store. 
        /// #### You can manage delivery dates by selecting Configuration > Shipping > Dates and ranges.
        /// *Default = 0*
        /// </summary>
        [JsonIgnore] public virtual int DeliveryDateId { get; set; } = 0;

        #endregion

        #region Inventory

        /// <summary>
        /// ## ManageInventoryMethodId
        /// ### Set a value indicating how to manage inventory
        /// ** ManageInventoryMethod: Enumerates methods of inventory management **
        /// * DontManageStock (0): Do not track inventory for the product. (default setting)
        /// * ManageStock (1): Track inventory for the product.
        /// * ManageStockByAttributes (2): Track inventory for the product by product attributes.
        /// </summary>
        [JsonIgnore] public virtual int ManageInventoryMethodId { get; set; } = 1;

        /// <summary>
        /// ## StockQuantity
        /// ### Set the stock quantity
        /// #### The current stock quantity of this product.
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1)
        /// *Default = 1000*
        /// </summary>
        [JsonIgnore] public virtual int StockQuantity { get; set; } = 0;


        /// <summary>
        /// ## ProductAvailabilityRangeId
        /// ### Set a product availability range identifier.
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// #### Choose the product availability range that indicates when the product is expected to be 
        /// #### available when out of stock (e.g. Available in 10-14 days). 
        /// #### You can manage availability ranges by selecting Configuration > Shipping > Dates and ranges.
        /// #### Check ProductAvailabilityRange for more details.
        /// *Default = 0*
        /// </summary>
        [JsonIgnore] public virtual int ProductAvailabilityRangeId { get; set; } = 0;

        /// <summary>
        /// ## UseMultipleWarehouses
        /// ### Set a value indicating whether multiple warehouses are used for this product
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) 
        /// #### Check if you want to support shipping and inventory management from multiple warehouses.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool UseMultipleWarehouses { get; set; } = false;

        /// <summary>
        /// ## WarehouseId
        /// ### Set a warehouse identifier
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// *Default = 0*
        /// </summary>
        [JsonIgnore] public virtual int WarehouseId { get; set; } = 0;

        /// <summary>
        /// ## DisplayStockAvailability
        /// ### Set a value indicating whether to display stock availability
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// #### Check to display stock availability. When enabled, customers will see stock availability.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool DisplayStockAvailability { get; set; } = false;

        /// <summary>
        /// ## DisplayStockQuantity
        /// ### Set a value indicating whether to display stock quantity
        /// #### Enabled if DisplayStockAvailability is true.
        /// #### Check to display stock quantity. When enabled, customers will see stock quantity.
        /// *Default = False*
        /// </summary>
        [JsonIgnore] public virtual bool DisplayStockQuantity { get; set; } = false;

        /// <summary>
        /// ## MinStockQuantity
        /// ### Set the minimum stock quantity
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)        
        /// #### If you track inventory, you can perform a number of different actions when the current stock 
        /// #### quantity falls below (reaches) your minimum stock quantity.
        /// *Default = 0*
        /// </summary>
        [JsonIgnore] public virtual int MinStockQuantity { get; set; } = 0;

        /// <summary>
        /// ## LowStockActivityId
        /// ### Set the low stock activity identifier
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// #### Action to be taken when your current stock quantity falls below (reaches) the 'Minimum stock quantity'. 
        /// #### Activation of the action will occur only after an order is placed. If the value is 'Nothing', 
        /// #### the product detail page will display a low-stock message in [JsonIgnore] public store.
        /// ** LowStockActivity: Enumerates actions to be taken when product stock is low **
        /// * Nothing (0): Do not take any action. (default setting)
        /// * DisableBuyButton (1): Disable the buy button for the product.
        /// * Unpublish (2): Unpublish the product, making it unavailable for purchase.
        /// </summary>
        [JsonIgnore] public virtual int LowStockActivityId { get; set; } = 0;

        /// <summary>
        /// ## NotifyAdminForQuantityBelow
        /// ### Set the quantity when admin should be notified
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) 
        /// #### When the current stock quantity falls below (reaches) this quantity, a store owner will receive a notification.
        /// *Default = 1*
        /// </summary>
        [JsonIgnore] public virtual int NotifyAdminForQuantityBelow { get; set; } = 1;

        /// <summary>
        /// ## BackorderModeId
        /// ### Set a value backorder mode identifier
        /// ** BackorderModeId: Identifies the backorder mode for the product **
        /// * NoBackorders (0): No backorders are allowed. (default setting)
        /// * AllowQtyBelow0 (1): Allow quantity below 0.
        /// * AllowQtyBelow0AndNotifyCustomer (2): Allow quantity below 0 and notify customer.
        /// </summary>
        [JsonIgnore] public virtual int BackorderModeId { get; set; } = 0;

        /// <summary>
        /// ## AllowBackInStockSubscriptions
        /// ### Set a value indicating whether to back in stock subscriptions are allowed
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1)
        /// #### Allow customers to subscribe to a notification list for a product that has gone out of stock.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool AllowBackInStockSubscriptions { get; set; } = true;

        /// <summary>
        /// ## OrderMinimumQuantity
        /// ### Set the order minimum quantity
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// #### Set the minimum quantity allowed in a customer's shopping cart e.g. set to 3 to only allow customers to purchase 3 or more of this product.
        /// *Default = 1*
        /// </summary>

        [JsonIgnore] public virtual int OrderMinimumQuantity { get; set; } = 1;

        /// <summary>
        /// ## OrderMaximumQuantity
        /// ### Set the order maximum quantity
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// #### Set the maximum quantity allowed in a customer's shopping cart e.g. set to 5 to only allow customers to purchase 5 of this product.
        /// *Default = 1000*
        /// </summary>
        [JsonIgnore] public virtual int OrderMaximumQuantity { get; set; } = 1000;

        /// <summary>
        /// ## NotReturnable
        /// ### Set a value indicating whether this product is returnable (a customer is allowed to submit return request with this product)
        /// ####Check if this product is not returnable. In this case a customer won't be allowed to submit return request.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool NotReturnable { get; set; } = false;

        /// <summary>
        /// ## AllowedQuantities
        /// ### Set the comma separated list of allowed quantities. null or empty if any quantity is allowed.
        /// Instead of a quantity textbox that allows them to enter any quantity, they will receive a dropdown list of the values you enter here.        
        /// For example - if you type "10,20,30" then the customer will only be able to select one of those quantities.
        /// Default it's set to null.
        /// </summary>
        [JsonIgnore] public virtual string? AllowedQuantities { get; set; }

        #endregion

        #region Attribute

        /// <summary>
        /// ## AllowAddingOnlyExistingAttributeCombinations
        /// ### Set a value indicating whether we allow adding to the cart/wishlist only attribute combinations that exist and have stock greater than zero.
        /// #### This option is used only when we have "manage inventory" set to "track inventory by product attributes"
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool AllowAddingOnlyExistingAttributeCombinations { get; set; } = false;

        /// <summary>
        /// ## DisplayAttributeCombinationImagesOnly
        /// ### Set a value indicating whether to display attribute combination images only
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool DisplayAttributeCombinationImagesOnly { get; set; } = false;
        #endregion

        #region Price

        /// <summary>
        /// ## DisableBuyButton
        /// ### Set a value indicating whether to disable buy (Add to cart) button
        /// #### Check to disable the buy button for this product. This may be necessary for products that are 'available upon request'.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool DisableBuyButton { get; set; } = false;

        /// <summary>
        /// ## DisableWishlistButton
        /// ### Set a value indicating whether to disable "Add to wishlist" button
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool DisableWishlistButton { get; set; } = false;

        /// <summary>
        /// ## AvailableForPreOrder
        /// ### Set a value indicating whether this item is available for Pre-Order
        /// #### Check if this item is available for Pre-Order. It also displays "Pre-order" button instead of "Add to cart".
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool AvailableForPreOrder { get; set; } = false;

        /// <summary>
        /// ## PreOrderAvailabilityStartDateTimeUtc
        /// ### Set the start date and time of the product availability (for pre-order products)
        /// #### Only active with AvailableForPreOrder = true
        /// #### The availability start date of the product configured for pre-order in Coordinated Universal Time (UTC). 
        /// #### 'Pre-order' button will automatically be changed to 'Add to cart' at this moment.
        /// *Default = null*
        /// </summary>
        [JsonIgnore] public virtual DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; } = null;

        /// <summary>
        /// ## OldPrice
        /// ### Set the old price
        /// #### The old price of the product. If you set an old price, this will display alongside the 
        /// #### current price on the product page to show the difference in price.
        /// #### If is 0, old price will not show on product site
        /// *Defaul = 0*
        /// </summary>
        [JsonIgnore] public virtual decimal OldPrice { get; set; } = 0;

        /// <summary>
        /// ## ProductCost
        /// ### Set the product cost
        /// #### Product cost is a prime product cost. This field is only for internal use, not visible for customers.
        /// *Default = 0m*
        /// </summary>
        [JsonIgnore] public virtual decimal ProductCost { get; set; } = 0m;

        /// <summary>
        /// ## CallForPrice
        /// ### Set a value indicating whether to show "Call for Pricing" or "Call for quote" instead of price
        /// #### Check to show "Call for Pricing" or "Call for quote" instead of price.
        /// *4Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool CallForPrice { get; set; } = false;

        /// <summary>
        /// ## CustomerEntersPrice
        /// ### Set a value indicating whether a customer enters price
        /// #### An option indicating whether customer should enter price.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool CustomerEntersPrice { get; set; } = false;

        /// <summary>
        /// ## MinimumCustomerEnteredPrice
        /// ### Set the minimum price entered by a customer.
        /// #### Only if CallForPrice is enabled.
        /// *Defaul = 0*
        /// </summary>
        [JsonIgnore] public virtual decimal MinimumCustomerEnteredPrice { get; set; } = 0;

        /// <summary>
        /// ## MaximumCustomerEnteredPrice
        /// ### Set the maximum price entered by a customer
        /// #### Only if CallForPrice is enabled.
        /// *Defaul = 0*
        /// </summary>
        [JsonIgnore] public virtual decimal MaximumCustomerEnteredPrice { get; set; } = 0;

        /// <summary>
        /// ## BasepriceEnabled
        /// ### Set a value indicating whether base price (PAngV) is enabled. Used by German users.
        /// #### Check to display baseprice of a product. This is required according to the German law (PAngV). 
        /// #### If you sell 500ml of beer for 1,50 euro, then you have to display baseprice: 3.00 euro per 1L.
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool BasepriceEnabled { get; set; } = false;

        /// <summary>
        /// ## BasepriceAmount
        /// ### Set an amount in product for PAngV.
        /// #### Only id BasepriceEnabled is enabled.
        /// #### Used by German users.
        /// *default = 0m*
        /// </summary>
        [JsonIgnore] public virtual decimal BasepriceAmount { get; set; } = 0;

        /// <summary>
        /// ## Set a unit of product for PAngV (MeasureWeight entity)
        /// ### Only if BasepriceEnabled is enabled
        /// #### Used by German users.
        /// *Default = 3*
        /// </summary>
        [JsonIgnore] public virtual int BasepriceUnitId { get; set; } = 3;

        /// <summary>
        /// ## BasepriceBaseAmount
        /// ### Set a reference amount for PAngV
        /// #### Only id BasepriceEnabled is enabled
        /// #### Used by German users.
        /// default is 0m.
        /// </summary>
        [JsonIgnore] public virtual decimal BasepriceBaseAmount { get; set; } = 0;

        /// <summary>
        /// ## BasepriceBaseUnitId
        /// ### Set a reference unit for PAngV (MeasureWeight entity)
        /// #### Only id BasepriceEnabled is enabled
        /// #### Used by German users.
        /// *default = 3*
        /// </summary>
        [JsonIgnore] public virtual int BasepriceBaseUnitId { get; set; } = 3;

        /// <summary>
        /// ## IsTaxExempt
        /// ### Set a value indicating whether the product is marked as tax exempt
        /// #### Determines whether this product is tax exempt (tax will not be applied to this product at checkout).
        /// *Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool IsTaxExempt { get; set; } = false;

        /// <summary>
        /// ## HasDiscountsApplied
        /// ### Set a value indicating whether this product has discounts applied
        /// #### The same as if we run AppliedDiscounts.Count > 0
        /// #### We use this property for performance optimization:
        /// #### if this property is set to false, then we do not need to load Applied Discounts navigation property
        /// *4Default = false*
        /// </summary>
        [JsonIgnore] public virtual bool HasDiscountsApplied { get; set; } = false;

        /// <summary>
        /// ## HasTierPrices
        /// ### Set a value indicating whether this product has tier prices configured
        /// #### The same as if we run TierPrices.Count > 0
        /// #### We use this property for performance optimization:
        /// #### if this property is set to false, then we do not need to load tier prices navigation property
        /// *Default = true*
        /// </summary>
        [JsonIgnore] public virtual bool HasTierPrices { get; set; } = true;

        #endregion

        #region Shipping
        // here are only required fields
        #endregion
    }
}
