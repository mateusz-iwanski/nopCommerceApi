using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// Additional attribute for address
    /// </summary>
    /// <remarks>
    /// This object should be used only for the get method in controller
    /// </remarks>
    public class AddressAttributeDto : BaseDto
    {
        public virtual int? Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public virtual string? Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the attribute is required
        /// </summary>
        public virtual bool? IsRequired { get; set; }

        /// <summary>
        /// From Nop.Core.Domain.Catalog.AttributeControlType enum type (compatible with nopCommerce 4.70.3)
        /// Defines the types of form controls available for use in the application. 
        /// - DropdownList (1): A dropdown list allowing single selection among multiple options.
        /// - RadioList (2): A list of radio buttons allowing single selection among multiple options.
        /// - Checkboxes (3): A group of checkboxes allowing multiple selections.
        /// - TextBox (4): A single-line text input field.
        /// - MultilineTextbox (10): A multi-line text input field for longer inputs.
        /// - Datepicker (20): A control for selecting a date.
        /// - FileUpload (30): A control for uploading files.
        /// - ColorSquares (40): A selection of color squares allowing users to pick a color.
        /// - ImageSquares (45): A selection of image squares allowing users to pick an image.
        /// - ReadonlyCheckboxes (50): A group of checkboxes that are read-only, typically used for displaying information.
        /// </summary>
        public virtual int? AttributeControlTypeId { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public virtual int? DisplayOrder { get; set; }
    }
}
