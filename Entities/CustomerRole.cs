using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

/// <summary>
/// In order to use this functionality, you have to disable the following setting: Catalog settings > Ignore ACL rules.
/// This settings is usefull for different prices in tier prices
/// </summary>
public partial class CustomerRole
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the customer role name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the customer role system name
    /// </summary>
    public string? SystemName { get; set; }

    /// <summary>
    /// Check to allow customers in this role to get free shipping on their orders.
    /// </summary>
    public bool FreeShipping { get; set; }

    /// <summary>
    /// Check to allow customers in this role to make tax free purchases.
    /// </summary>
    public bool TaxExempt { get; set; }

    /// <summary>
    /// Check to make this role active.
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// A value indicating whether it's a system role.
    /// </summary>
    public bool IsSystemRole { get; set; }

    /// <summary>
    /// Check to force customers to change their passwords after a specified time.
    /// </summary>
    public bool EnablePasswordLifetime { get; set; }

    /// <summary>
    /// Override default tax display type
    /// </summary>
    public bool OverrideTaxDisplayType { get; set; }

    /// <summary>
    /// Default tax display type
    /// </summary>
    public int DefaultTaxDisplayTypeId { get; set; }

    /// <summary>
    /// A customer is added to this customer role once a specified product is purchased (paid).
    /// Please note that in case of refund or order cancellation you have to manually remove a customer from this role.
    /// </summary>
    public int PurchasedWithProductId { get; set; }

    /// <summary>
    /// Access Control List (ACL) restricts or grants users access to certain areas of the site    
    /// If you want to ues customer role for products you need to disable the following setting: Catalog settings > Ignore ACL rules
    /// </summary>
    public virtual ICollection<AclRecord> AclRecords { get; set; } = new List<AclRecord>();

    public virtual ICollection<TierPrice> TierPrices { get; set; } = new List<TierPrice>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<PermissionRecord> PermissionRecords { get; set; } = new List<PermissionRecord>();
}
