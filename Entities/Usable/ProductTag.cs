using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;

public partial class ProductTag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
