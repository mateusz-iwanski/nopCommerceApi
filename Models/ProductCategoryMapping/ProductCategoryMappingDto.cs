using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.ProductCategory
{
    /// <summary>
    /// Product category mapping DTO
    /// </summary>
    /// <remarks>
    /// Associate a product with a category
    /// </remarks>
    public class ProductCategoryMappingDto : BaseDto
    {

        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or set the category identifier
        /// </summary>
        [Required]
        public virtual int CategoryId { get; set; }

        /// <summary>
        /// Gets or set the product identifier
        /// </summary>
        [Required]
        public virtual int ProductId { get; set; }

        /// <summary>
        /// Gets or set a value indicating whether the product is featured
        /// *Default = false*
        /// </summary>
        public virtual bool IsFeaturedProduct { get; set; }

        /// <summary>
        /// Gets or set the display order        
        /// </summary>
        /// <remarks>
        /// *Default = false*
        /// </remarks>
        public virtual int DisplayOrder { get; set; }

    }
}
