using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;

/// <summary>
/// Represents a state/province
/// </summary>
public partial class StateProvince
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the abbreviation
    /// </summary>
    public string? Abbreviation { get; set; }

    /// <summary>
    /// Gets or sets the country identifier
    /// </summary>
    public int CountryId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is published
    /// </summary>
    public bool Published { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; }
}
