using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.ProductAttribute
{
    public class ProductProductAttributeMappingDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## ProductAttributeId
        /// ### Gets or set the product attribute identifier
        /// </summary>
        [Required]
        public virtual int ProductAttributeId { get; set; }

        /// <summary>
        /// ## ProductId
        /// ### Gets or set the product identifier
        /// </summary>
        [Required]
        public virtual int ProductId { get; set; }

        /// <summary>
        /// ## TextPrompt
        /// ### Gets or set the text prompt
        /// *Default = null*
        /// </summary>
        public virtual string? TextPrompt { get; set; }

        /// <summary>
        /// ### Gets or set a value indicating whether the attribute is required
        /// #### When an attribute is required, the customer must choose an appropriate attribute value before they can continue.
        /// *Default = false*
        /// </summary>
        public virtual bool IsRequired { get; set; }

        /// <summary>
        /// ### Gets or set the attribute control type identifier
        /// #### Choose how to display your attribute values.
        /// </summary>
        [Required]
        public virtual int AttributeControlTypeId { get; set; }

        /// <summary>
        /// ### Gets or set the display order
        /// #### The attribute display order. 1 represents the first item in the list.
        /// *Default = 0*
        /// </summary>
        public virtual int DisplayOrder { get; set; }

        /// <summary>
        /// ## ValidationMinLength
        /// ### Gets or set the minimum length of the attribute value
        /// *Default = null*
        /// </summary>
        public virtual int? ValidationMinLength { get; set; }

        /// <summary>
        /// ## ValidationMaxLength
        /// ### Gets or sets the maximum length of the attribute value
        /// *Default = null*
        /// </summary>
        public virtual int? ValidationMaxLength { get; set; }

        /// <summary>
        /// ## ValidationFileAllowedExtensions
        /// ### Gets or set the allowed file extensions
        /// *Default = null*
        /// </summary>
        public virtual string? ValidationFileAllowedExtensions { get; set; }

        /// <summary>
        /// ## ValidationFileMaximumSize 
        /// ### Gets or sets the maximum size of the file
        /// *Default = null*
        /// </summary>
        public virtual int? ValidationFileMaximumSize { get; set; }

        /// <summary>
        /// ## DefaultValue 
        /// ### Gets or set the default value
        /// *Default = null*
        /// </summary>
        public virtual string? DefaultValue { get; set; }

        /// <summary>
        /// ## ConditionAttributeXml
        /// ### Gets or sets the condition attribute XML
        /// *Deafault = null*
        /// </summary>
        public virtual string? ConditionAttributeXml { get; set; }
    }
}
