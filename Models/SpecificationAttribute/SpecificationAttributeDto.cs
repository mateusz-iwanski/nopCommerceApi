using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.SpecyficationAttribute
{
    /// <summary>
    /// Specification attribute DTO
    /// </summary>
    /// <remarks>
    /// Specification attributes are similar to product attributes
    /// however, they are only used for information (visible on the product details page) 
    /// and for filtering products on the category details page. 
    /// They don't define product price and can't be used for inventory tracking.
    /// Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/specification-attributes.html
    /// Catalog → Attributes → Specification attributes.
    /// Note: Specification attribute need to have option! If not, it will be ignored.
    /// </remarks>
    public class SpecificationAttributeDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## Name
        /// ### Gets or sets the name
        /// </summary>
        [Required]
        public virtual string Name { get; set; } = null!;

        /// <summary>
        /// ## SpecificationAttributeGroupId
        /// ### Gets or sets the specification attribute group identifier
        /// *Default = null*
        /// </summary>
        [Required]
        public virtual int? SpecificationAttributeGroupId { get; set; }

        /// <summary>
        /// ## DisplayOrder
        /// ### Gets or sets the display order
        /// #### 1 represents the top of the list
        /// *Default = 0*
        /// </summary>
        public virtual int DisplayOrder { get; set; }
    }
}
