using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class ShippingMethod
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int DisplayOrder { get; set; }

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
}
