using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class ProductManufacturerMapping
{
    public int Id { get; set; }

    public int ManufacturerId { get; set; }

    public int ProductId { get; set; }

    public bool IsFeaturedProduct { get; set; }

    public int DisplayOrder { get; set; }

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
