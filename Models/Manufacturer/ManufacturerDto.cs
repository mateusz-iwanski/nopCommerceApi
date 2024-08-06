using nopCommerceApi.Entities.NotUsable;
using nopCommerceApi.Entities.Usable;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Manufacturer
{
    public class ManufacturerDto : BaseDto
    {
        public virtual int Id { get; set; }

        #region Info

        /// <summary>
        /// ## Name
        /// ### Gets or sets the name
        /// </summary>
        [Required]
        public virtual string Name { get; set; } = null!;

        /// <summary>
        /// ## Description
        /// ### Gets or sets the description
        /// </summary>
        /// *Default = null*
        public virtual string? Description { get; set; }

        /// <summary>
        /// ## PictureId
        /// ### Gets or sets the parent picture identifier
        /// *Default = 0*
        /// </summary>
        public virtual int PictureId { get; set; }

        #endregion

        #region Display

        /// <summary>
        /// ## Published
        /// ### Gets or sets a value indicating whether the entity is published
        /// *Default = true*
        /// </summary>
        public virtual bool Published { get; set; }

        /// <summary>
        /// ## AllowCustomersToSelectPageSize
        /// ### Gets or sets a value indicating whether customers can select the page size
        /// #### Whether customers are allowed to select the page size from a predefined list of options.
        /// *Default = true*
        /// </summary>
        public virtual bool AllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// ## PageSize
        /// ### Gets or sets the page size
        /// #### Only work if AllowCustomersToSelectPageSize is false
        /// #### Set the page size for products in this manufacturer e.g. '4' products per page.
        /// *Default = 6*
        /// </summary>
        public virtual int PageSize { get; set; }

        /// <summary>
        /// ## PageSizeOptions
        /// ### Gets or sets the available customer selectable page size options.
        /// #### Only work if AllowCustomersToSelectPageSize is true
        /// #### Comma separated list of page size options (e.g. 10, 5, 15, 20). First option is the default page size if none are selected.
        /// *Default = 3,6,9*
        /// </summary>
        public virtual string? PageSizeOptions { get; set; }

        /// <summary>
        /// ## PriceRangeFiltering
        /// ### Gets or sets a value indicating whether the price range filtering is enabled
        /// #### Check to enter price range manually, otherwise the automatic calculation of 
        /// #### price range is enabled (based on prices of available products). 
        /// #### Set price range manually if you have complex discount rules.
        /// *Default = 1*
        /// </summary>
        public virtual bool PriceRangeFiltering { get; set; }

        /// <summary>
        /// ## PriceFrom
        /// ### Gets or sets the "from" price
        /// *Default = 0m*
        /// </summary>
        public virtual decimal PriceFrom { get; set; }

        /// <summary>
        /// ## PriceTo
        /// ### Gets or sets the "to" price
        /// *Default = 0m*
        /// </summary>
        public virtual decimal PriceTo { get; set; }

        /// <summary>
        /// ## ManuallyPriceRange
        /// ### Gets or sets a value indicating whether the price range should be entered manually
        /// *Default = false*
        /// </summary>
        public virtual bool ManuallyPriceRange { get; set; }

        /// <summary>
        /// ## DisplayOrder
        /// ### Gets or sets the display order
        /// #### Set the manufacturer's display order. 1 represents the top of the list.
        /// *Default = 0*
        /// </summary>
        public virtual int DisplayOrder { get; set; }

        #endregion

        #region SEO

        /// <summary>
        /// ## MetaKeywords
        /// ### Gets or sets the meta keywords
        /// #### Meta keywords to be added to manufacturer page header.
        /// *Default = null*
        /// </summary>
        public virtual string? MetaKeywords { get; set; }

        /// <summary>
        /// ## MetaTitle
        /// ### Gets or sets the meta title
        /// #### Override the page title. The default is the name of the manufacturer.
        /// *Default = null*
        /// </summary>
        public virtual string? MetaTitle { get; set; }

        /// <summary>
        /// ## MetaDescription
        /// ### Gets or sets the meta description
        /// #### Meta description to be added to manufacturer page header.
        /// *Default = null*
        /// </summary>
        public virtual string? MetaDescription { get; set; }

        #endregion

        #region Mapping

        [JsonIgnore]
        public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

        /// <summary>
        /// ## LimitedToStores
        /// ### Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// #### Option to limit this manufacturer to a certain store. If you have multiple stores, 
        /// #### choose one or several from the list. If you don't use this option just leave this field empty.
        /// *Default = false*
        /// </summary>
        public virtual bool LimitedToStores { get; set; }

        #endregion


        /// <summary>
        /// ## ManufacturerTemplateId
        /// ### Gets or sets a value of used manufacturer template identifier
        /// *Default = 1*
        /// </summary>
        public virtual int ManufacturerTemplateId { get; set; }

        /// <summary>
        /// ## SubjectToAcl
        /// ### Gets or sets a value indicating whether the entity is subject to ACL
        /// *Default = 0*
        /// </summary>
        public virtual bool SubjectToAcl { get; set; }

        /// <summary>
        /// ## Deleted
        /// ### Gets or sets a value indicating whether the entity has been deleted
        /// *Default = false*
        /// </summary>
        public virtual bool Deleted { get; set; }

        /// <summary>
        /// ## CreatedOnUtc
        /// ### Gets or sets the date and time of instance creation
        /// *Default = DateTime.Now*
        /// </summary>
        public virtual DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ## UpdatedOnUtc
        /// ### Gets or sets the date and time of instance update
        /// *Default = DateTime.Now*
        /// </summary>
        public virtual DateTime UpdatedOnUtc { get; set; }


        [JsonIgnore]
        public virtual ICollection<ProductManufacturerMapping> ProductManufacturerMappings { get; set; } = new List<ProductManufacturerMapping>();

        
    }
}
