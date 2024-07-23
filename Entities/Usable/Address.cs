using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.NotUsable;

namespace nopCommerceApi.Entities.Usable;

/// <summary>
/// Address is used for billing, shipping, pickup addresses
/// </summary>
public partial class Address
{
    /// <summary>
    /// Gets or sets the entity identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the country identifier
    /// </summary>
    public int? CountryId { get; set; }

    /// <summary>
    /// Gets or sets the state/province identifier
    /// </summary>
    public int? StateProvinceId { get; set; }

    /// <summary>
    /// Gets or sets the first name
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the company
    /// </summary>
    public string? Company { get; set; }

    /// <summary>
    /// Gets or sets the county
    /// </summary>
    public string? County { get; set; }

    /// <summary>
    /// Gets or sets the city
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets the address 1
    /// </summary>
    public string? Address1 { get; set; }

    /// <summary>
    /// Gets or sets the address 2
    /// </summary>
    public string? Address2 { get; set; }

    /// <summary>
    /// Gets or sets the zip/postal code
    /// </summary>
    public string? ZipPostalCode { get; set; }

    /// <summary>
    /// Gets or sets the phone number
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the fax number
    /// </summary>
    public string? FaxNumber { get; set; }

    /// <summary>
    /// Gets or sets the custom attributes (see "AddressAttribute" entity for more info).
    /// It's in XML Format
    /// </summary>
    public string? CustomAttributes { get; set; }

    /// <summary>
    /// Gets or sets the date and time of instance creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    public virtual ICollection<Affiliate> Affiliates { get; set; } = new List<Affiliate>();

    public virtual Country? Country { get; set; }

    public virtual ICollection<Customer> CustomerBillingAddresses { get; set; } = new List<Customer>();

    public virtual ICollection<Customer> CustomerShippingAddresses { get; set; } = new List<Customer>();

    public virtual ICollection<Order> OrderBillingAddresses { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderPickupAddresses { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderShippingAddresses { get; set; } = new List<Order>();

    public virtual StateProvince? StateProvince { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
