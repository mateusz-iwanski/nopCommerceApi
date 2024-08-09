using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.ProductVideo
{
    /// <summary>
    /// Associate video url with product
    /// </summary>
    public class ProductVideoDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## VideoId
        /// ### Gets or set the video identifier
        /// </summary>
        [Required]
        public virtual int VideoId { get; set; }

        /// <summary>
        /// ## ProductId
        /// ### Gets or set the product identifier
        /// </summary>
        [Required]
        public virtual int ProductId { get; set; }

        /// <summary>
        /// ## DisplayOrder
        /// ### Gets or set the display order`
        /// #### 1 represents the top of the list
        /// *Default = 0*
        /// </summary>
        public virtual int DisplayOrder { get; set; }
    }
}
