using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Product
{
    public class ProductUpdateBlockInformationDto : BaseDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        #region Product information

        /// <summary>
        /// ## ShortDescription
        /// ### Short description is the text that is displayed in product list i.e. category / manufacturer pages.
        /// </summary>
        public virtual string? ShortDescription { get; set; }

        /// <summary>
        /// ## FullDescription
        /// ### Full description is the text that is displayed in product page.
        /// </summary>
        public virtual string? FullDescription { get; set; }


        /// <summary>
        /// ## ManufacturerPartNumber
        /// ### Set the manufacturer part number.
        /// </summary>
        public virtual string? ManufacturerPartNumber { get; set; }

        /// <summary>        
        /// ## Published
        /// ### Set a value indicating whether the entity is published.
        /// *Default = false*
        /// </summary>        
        public virtual bool Published { get; set; }

        /// <summary>
        /// ## Deleted
        /// ### Set a value indicating whether the entity has been deleted.
        /// *Default = false*
        /// </summary>
        public virtual bool Deleted { get; set; }

        /// <summary>
        /// ## Gtin
        /// ### Set the Global Trade Item Number (GTIN). 
        /// #### These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books).
        /// *Default = null*
        /// </summary>
        public virtual string? Gtin { get; set; }

        /// <summary>
        /// ## ProductTypeId 
        /// ### Set the product type identifier.
        /// #### Product type can be simple or grouped. In most cases your product will have the Simple product type. 
        /// #### You need to use Grouped product type when a new product consists of one or more existing products that will be displayed on one single product details page.
        /// ** Note: enum ProductType Ids (compatible with 4.70.3) **
        /// * SimpleProduct (5): A simple product. (*Default setting*)
        /// * GroupedProduct (10): A grouped product (product with variants).
        /// </summary>
        public virtual int ProductTypeId { get; set; }

        /// <summary>
        /// ## ProductTemplateId
        /// ### Choose a product template. This template defines how this product will be displayed in public store.
        /// #### Look on ProductTemplate for more details.
        /// #### In nopCommerce, you can specify an alternate layout template for a category, manufacturer, product, and topic. You can see a list of the existing templates on the System → Templates page.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/system-administration/templates.html
        /// *Default = 1 (Simple Product)*
        /// </summary>
        public virtual int ProductTemplateId { get; set; }

        /// <summary>
        /// ## VendorId
        /// ### Gets or sets the vendor identifier with which this customer is associated (manager)
        /// #### Choose a vendor associated with this product. This can be useful when running a multi-vendor store to keep track of goods associated with vendor.
        /// #### If is not multi-vendor store, then this field should be set to 0.   
        /// *Default = 0*
        /// </summary>
        public virtual int VendorId { get; set; }

        /// <summary>
        /// ## RequireOtherProducts
        /// ### Set a value indicating whether the product requires that other products are added to the cart (Product X requires Product Y).
        /// #### If you set to true you have use RequiredProductIds.
        /// *Default = false*
        /// </summary>
        public virtual bool RequireOtherProducts { get; set; }

        /// <summary>
        /// ## RequiredProductIds
        /// ### Set a required product identifiers (comma separated).
        /// #### Specify comma separated list of required product IDs. NOTE: Ensure that there are no circular references (for example, A requires B, and B requires A).
        /// #### It's only work when RequireOtherProducts = true.
        /// *Default = null*
        /// </summary>
        public virtual string? RequiredProductIds { get; set; }

        /// <summary>
        /// ## AutomaticallyAddRequiredProducts
        /// ### Set a value indicating whether required products (RequiredProductIds) are automatically added to the cart.
        /// *Default = false*
        /// </summary>
        public virtual bool AutomaticallyAddRequiredProducts { get; set; }

        /// <summary>
        /// ## ShowOnHomepage
        /// ### Gets or sets a value indicating whether to display this product on your store's home page. Recommended for your most popular products.
        /// *Default = false*
        /// </summary>
        public virtual bool ShowOnHomepage { get; set; }

        /// <summary>
        /// ## ShowOnHomepage
        /// ### Set a display order.
        /// #### This value is used when sorting associated products (used with "grouped" products).
        /// #### This value is used when sorting home page products.
        /// *Default = 0*
        /// </summary>
        public virtual int DisplayOrder { get; set; }

        /// <summary>
        /// ## ParentGroupedProductId
        /// ### Set the parent product identifier. It's used to identify associated products (only with "grouped" products).
        /// #### To use it, you have to set parent product type to "Grouped product" and add id of this parent product to ParentGroupedProductId.
        /// #### Only one parent product can be set for a product.
        /// #### Products in nopCommerce have two different types, simple products and grouped products. 
        /// #### Grouped products let you stablish a hierarchical relation between them. As an easy example, 
        /// #### you can imagine a perfume (parent product) that has associated two simple products (small size and big size).
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/grouped-products-variants.html
        /// *Default = 0*
        /// </summary>
        public virtual int ParentGroupedProductId { get; set; }

        /// <summary>
        /// ## VisibleIndividually
        /// ### Set the values indicating whether this product is visible in catalog or search results.
        /// #### It's used when this product is associated to some "grouped" one.
        /// #### This way associated products could be accessed/added/etc only from a grouped product details page.
        /// *Default = true*
        /// </summary>
        public virtual bool VisibleIndividually { get; set; }

        /// <summary>
        /// ## SubjectToAcl
        /// ### ACL - Access Control List (ACL) restricts or grants users access to certain areas of the site. This list is managed by administrators.
        /// #### Set a value indicating whether the entity is subject to ACL.
        /// *Default = true*
        /// </summary>
        public virtual bool SubjectToAcl { get; set; }

        /// <summary>
        /// ## LimitedToStores
        /// ### Set a value indicating whether the entity is limited/restricted to certain stores.
        /// #### Option to limit this product to a certain store. If you have multiple stores, choose one or several from the list. 
        /// #### If you don't use this option just leave this field empty. In order to use this functionality, you have to disable the 
        /// #### following setting: Catalog settings > Ignore ACL rules.
        /// *Default = false*
        /// </summary>
        public virtual bool LimitedToStores { get; set; }

        /// <summary>
        /// ## AvailableStartDateTimeUtc
        /// ### Set the start product available to customers at start date
        /// *Default = null*
        /// </summary>
        public virtual DateTime? AvailableStartDateTimeUtc { get; set; }

        /// <summary>
        /// ## AvailableEndDateTimeUtc
        /// ### Set the available end date and time.
        /// #### Set the end of the product available to customers on the end date
        /// *Default = null*
        /// </summary>
        public virtual DateTime? AvailableEndDateTimeUtc { get; set; }

        /// <summary>
        /// ## MarkAsNew
        /// ### Set a value indicating whether this product is marked as new.
        /// #### Check to mark the product as new. Use this option for promoting new products.
        /// *Default = true*
        /// </summary>
        public virtual bool MarkAsNew { get; set; }

        /// <summary>
        /// ## MarkAsNewStartDateTimeUtc
        /// ### Set the start date and time of the new product (set product as "New" from date). Leave empty to ignore this property.
        /// #### Only enabled if MarkAsNew is false.
        /// #### Set Product as New from Date in Coordinated Universal Time (UTC).
        /// *Default = null*
        /// </summary>
        public virtual DateTime? MarkAsNewStartDateTimeUtc { get; set; }

        /// <summary>
        /// ## MarkAsNewEndDateTimeUtc
        /// ### Set the end date and time of the new product (set product as "New" to date). Leave empty to ignore this property.
        /// #### Only enabled if MarkAsNew is false.
        /// #### Set Product as New to Date in Coordinated Universal Time (UTC).
        /// *Default = null*
        /// </summary>
        public virtual DateTime? MarkAsNewEndDateTimeUtc { get; set; }

        /// <summary>
        /// ## AdminComment
        /// ### This comment is for internal use only, not visible for customers.
        /// *Defaul = null*
        /// </summary>
        public virtual string? AdminComment { get; set; }

        /// <summary>
        /// ## UpdatedOnUtc
        /// ### Set the date and time of product update.
        /// *Default = DateTime.Now*
        /// </summary>
        [JsonIgnore]
        public virtual DateTime? UpdatedOnUtc { get; set; } = DateTime.Now;

        #endregion
    }
}
