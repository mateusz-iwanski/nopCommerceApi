using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;

/// <summary>
/// Represents a keyword used for product identification, allowing products to be sorted by certain features
/// and enabling specific, narrow product searches. For instance, in an apparel store, product tags can include
/// "t-shirt," "cotton," "polo." This class also supports editing product tags displayed in the public store.
/// </summary>
public partial class ProductTag
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
