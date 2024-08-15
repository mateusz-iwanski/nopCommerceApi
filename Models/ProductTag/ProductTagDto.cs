using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.ProductTag
{
    /// <summary>
    /// Product tag Data Transfer Object
    /// </summary>
    /// <remarks>
    /// Should be used only for the get method in controller
    /// </remarks>
    public class ProductTagDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## Name
        /// ### Gets or sets the name
        /// </summary>
        [Required]
        public virtual string Name { get; set; }
    }
}
