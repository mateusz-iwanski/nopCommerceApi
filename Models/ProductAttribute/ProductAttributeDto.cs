using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.ProductAttribute
{
    /// <summary>
    /// Product Attribute DTO
    /// </summary>
    /// <remarks>
    /// Product attributes are quantifiable or descriptive aspects of a product (such as, color). 
    /// For example, if you were to create an attribute for color, with the values of blue, green, yellow, and 
    /// so on, you may want to apply this attribute to shirts, which you sell in various 
    /// colors (you can adjust a price or weight for any of existing attribute values). 
    /// You can add attribute for your product using existing list of attributes, or if you need to create a new 
    /// one go to Catalog > Attributes > Product attributes. Please notice that if you want to manage inventory by 
    /// product attributes (e.g. 5 green shirts and 3 blue ones), then ensure that 
    /// "Inventory method" is set to "Track inventory by product attributes".
    /// </remarks>
    public class ProductAttributeDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## Name
        /// ### Gets or sets the name
        /// </summary>
        [Required]
        public virtual string Name { get; set; } = null!;

        /// <summary>
        /// ## Description 
        /// ### Gets or set description
        /// *Default = null*
        /// </summary>
        public virtual string? Description { get; set; }
    }
}
