using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductSpecificationAttributeMapping
{
    /// <summary>
    /// Product specification attribute mapping DTO
    /// </summary>
    /// <reamarks>
    /// Note: Specification attribute need to have value! If not, it will be ignored in Product.
    /// For example: Product (specification attribute group) -> color (specification attribute) -> red, blue, green (specification attribute option)
    /// </reamarks>
    public class ProductSpecificationAttributeMappingDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## CustomValue
        /// #### I don't know what this is for, always set to null
        /// *Default = null*
        /// </summary>
        [JsonIgnore]
        public virtual string? CustomValue { get; set; } = null;

        /// <summary>
        /// ## ProductId
        /// ### Gets or sets the product identifier
        /// </summary>
        [Required]
        public virtual int ProductId { get; set; }

        /// <summary>
        /// ## SpecificationAttributeOptionId
        /// ### Gets or sets the specification attribute option identifier
        /// #### Note: Specification attribute need to have value! If not, it will be ignored in Product.
        /// #### For example: Product (specification attribute group) -> color (specification attribute) -> red, blue, green (specification attribute option)
        /// </summary>
        [Required]
        public virtual int SpecificationAttributeOptionId { get; set; }

        /// <summary>
        /// ## AttributeTypeId
        /// ### Gets or sets the attribute type identifier
        /// #### If is 0, it will set as Option type
        /// #### Always set to 0
        /// *Default = 0*
        /// </summary>
        [JsonIgnore]
        public virtual int AttributeTypeId { get; set; } = 0;

        /// <summary>
        /// ## AllowFiltering
        /// ### Gets or sets a value indicating whether the product attribute is allowed to filter
        /// #### Allow product filtering by this attribute.
        /// *Default = false*
        /// </summary>
        public virtual bool AllowFiltering { get; set; }

        /// <summary>
        /// ## ShowOnProductPage
        /// ### Gets or sets a value indicating whether the product attribute is shown on the product page
        /// #### The value of the specification attribute. Be visible on the product page.
        /// *Default = false*
        /// </summary>
        public virtual bool ShowOnProductPage { get; set; }

        /// <summary>
        /// ## DisplayOrder
        /// ### Gets or sets the display order
        /// #### 1 represents the top of the list
        /// *Default = 0*
        /// </summary>
        public virtual int DisplayOrder { get; set; }

    }
}
