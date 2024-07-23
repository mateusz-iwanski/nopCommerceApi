using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;


/// <summary>
/// Tier pricing is a promotional tool that allows a store owner to price items differently for higher quantities.
/// You can also use it as B2B/B2C prices, every customer can be assigned to a customer role and have a different price.
/// </summary>
public partial class TierPrice
{
    public int Id { get; set; }

    /// <summary>
    /// If null, applies to all customer roles.
    /// </summary>
    public int? CustomerRoleId { get; set; }

    /// <summary>
    /// Gets or sets the product identifier
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Leave empty if not multi-store. Default storeId is 0.
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// Gets or sets the quantity
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the price
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the start date and time in UTC
    /// </summary>
    public DateTime? StartDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the end date and time in UTC
    /// </summary>
    public DateTime? EndDateTimeUtc { get; set; }

    public virtual CustomerRole? CustomerRole { get; set; }

    public virtual Product Product { get; set; } = null!;
}
