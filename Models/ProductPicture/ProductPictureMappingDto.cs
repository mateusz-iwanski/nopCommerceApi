using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.ProductPicture
{
    public class ProductPictureMappingDto : BaseDto
    {
        public int Id { get; set; }

        /// <summary>
        /// ## PictureId
        /// ### Gets or sets the picture identifier
        /// </summary>
        [Required]
        public int PictureId { get; set; }

        /// <summary>
        /// ## ProductId
        /// ### Gets or sets the product identifier
        /// </summary>
        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// ## DisplayOrder
        /// ### Gets or sets the display order
        /// #### The attribute display order. 1 represents the first item in the list.
        /// *Default = 0*
        /// </summary>
        public int DisplayOrder { get; set; }

    }
}
