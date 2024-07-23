using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;

/// <summary>
/// Represents a country
/// </summary>
public partial class Country
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the two letter ISO code
    /// </summary>
    public string? TwoLetterIsoCode { get; set; }

    /// <summary>
    /// Gets or sets the three letter ISO code
    /// </summary>
    public string? ThreeLetterIsoCode { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether billing is allowed to this country
    /// </summary>
    public bool AllowsBilling { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether shipping is allowed to this country
    /// </summary>
    public bool AllowsShipping { get; set; }

    /// <summary>
    /// Gets or sets the numeric ISO code
    /// </summary>
    public int NumericIsoCode { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether customers in this country must be charged EU VAT
    /// </summary>
    public bool SubjectToVat { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is published
    /// </summary>
    public bool Published { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
    /// </summary>
    public bool LimitedToStores { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<StateProvince> StateProvinces { get; set; } = new List<StateProvince>();

    public virtual ICollection<ShippingMethod> ShippingMethods { get; set; } = new List<ShippingMethod>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

}
