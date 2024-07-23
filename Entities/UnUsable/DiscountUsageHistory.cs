using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class DiscountUsageHistory
{
    public int Id { get; set; }

    public int DiscountId { get; set; }

    public int OrderId { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Discount Discount { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
