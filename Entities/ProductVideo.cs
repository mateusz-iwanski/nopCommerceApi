using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities;

public partial class ProductVideo
{
    public int Id { get; set; }

    public int VideoId { get; set; }

    public int ProductId { get; set; }

    public int DisplayOrder { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Video Video { get; set; } = null!;
}
