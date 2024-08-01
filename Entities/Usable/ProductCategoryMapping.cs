using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;

public partial class ProductCategoryMapping
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public int ProductId { get; set; }

    public bool IsFeaturedProduct { get; set; }

    public int DisplayOrder { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
