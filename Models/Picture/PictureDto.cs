using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Picture
{
    /// <summary>
    /// PictureService Data Transfer Object
    /// </summary>
    /// <remarks>
    /// Path to uploadded pictures - nopCommerce\src\Presentation\Nop.Web\wwwroot\images\thumbs\
    /// Doc: https://docs.nopcommerce.com/en/getting-started/design-your-store/media-settings.html
    /// Settings: Configuration → Settings → Media settings.
    /// Every file name should be format like this - for example for product with id 1:
    /// 0000001_{product name}.jpeg - (product name with dash) = 0000001_product-name.jpeg
    /// </remarks>
    public class PictureDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## MimeType
        /// ### Gets or sets the picture mime type
        /// </summary>
        [Required]
        public virtual string MimeType { get; set; }

        /// <summary>
        /// ## SeoFilename 
        /// ### Gets or sets the SEO friendly filename of the picture
        /// #### The SEO filename is the name of product/categories etc. White spaces are replaced with dash - product name = product-name.
        /// *Default = product/categoies etc. name with dash*
        /// </summary>
        [Required]
        public virtual string SeoFilename { get; set; }

        /// <summary>
        /// ## AltAttribute
        /// ### Gets or sets the "alt" attribute for "img" HTML element. If empty, then a default rule will be used (e.g. product name)
        /// *Default = null*
        /// </summary>
        public virtual string? AltAttribute { get; set; }

        /// <summary>
        /// ## TitleAttribute
        /// ### Gets or sets the "title" attribute for "img" HTML element. If empty, then a default rule will be used (e.g. product name)
        /// *Default = null*
        /// </summary>
        public virtual string? TitleAttribute { get; set; }

        /// <summary>
        /// ## IsNew
        /// ### Gets or sets a value indicating whether the picture is new
        /// *Default = false*
        /// </summary>
        public virtual bool IsNew { get; set; }

        /// <summary>
        /// ## VirtualPath
        /// ### Gets or sets the picture virtual path
        /// *Default = null*
        /// </summary>
        public virtual string? VirtualPath { get; set; }

    }
}
