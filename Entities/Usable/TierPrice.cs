using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;


/// <summary>
/// Tier pricing is a promotional tool that allows a store owner to price items differently for higher quantities.
/// Youc can also use it as B2B/B2C prices, every customer can be assigned to a customer role and have a different price.
/// </summary>
public partial class TierPrice
{
    public int Id { get; set; }

    public int? CustomerRoleId { get; set; }

    public int ProductId { get; set; }

    // For multi-store
    public int StoreId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public DateTime? StartDateTimeUtc { get; set; }

    public DateTime? EndDateTimeUtc { get; set; }

    public virtual CustomerRole? CustomerRole { get; set; }

    public virtual Product Product { get; set; } = null!;
}
