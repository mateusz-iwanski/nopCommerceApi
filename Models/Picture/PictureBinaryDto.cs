using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Picture
{
    /// <summary>
    /// PictureBinaryService Data Transfer Object
    /// </summary>
    public class PictureBinaryDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## PictureId
        /// ### Gets or sets the picture ID
        /// </summary>
        [Required]
        public virtual int PictureId { get; set; }

        /// <summary>
        /// ## BinaryData
        /// ### Gets or sets the binary data of the picture
        /// *Default = null*
        /// </summary>
        public virtual byte[]? BinaryData { get; set; }
    }
}
