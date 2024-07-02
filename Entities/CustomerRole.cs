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

    public string Name { get; set; } = null!;

    public string? SystemName { get; set; }

    public bool FreeShipping { get; set; }

    public bool TaxExempt { get; set; }

    public bool Active { get; set; }

    public bool IsSystemRole { get; set; }

    public bool EnablePasswordLifetime { get; set; }

    public bool OverrideTaxDisplayType { get; set; }

    public int DefaultTaxDisplayTypeId { get; set; }

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
