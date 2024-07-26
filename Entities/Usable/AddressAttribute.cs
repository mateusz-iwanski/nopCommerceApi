using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.NotUsable;

namespace nopCommerceApi.Entities.Usable;

/// <summary>
/// If the default form fields are not enough for your needs, then you can manage additional address attributes.
/// </summary>
public partial class AddressAttribute
{
    /// <summary>
    /// Gets or sets the entity identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets a value indicating whether the attribute is required
    /// </summary>
    public bool IsRequired { get; set; }

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
    public int AttributeControlTypeId { get; set; }

    /// <summary>
    /// Gets or sets the display order. From 0 to N
    /// </summary>
    public int DisplayOrder { get; set; }

    public virtual ICollection<AddressAttributeValue> AddressAttributeValues { get; set; } = new List<AddressAttributeValue>();
}
