using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.SpecyficationAttributeGroup
{
    public class SpecificationAttributeGroupDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## Name
        /// ### Gets or sets the name
        /// </summary>
        [Required]
        public virtual string Name { get; set; } = null!;

        /// <summary>
        /// ## DisplayOrder
        /// ### Gets or sets the display order
        /// #### 1 represents the top of the list
        /// *Default = 0*
        /// </summary>
        public virtual int DisplayOrder { get; set; }
    }
}
