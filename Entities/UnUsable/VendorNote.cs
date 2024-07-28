using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class VendorNote
{
    public int Id { get; set; }

    public string Note { get; set; } = null!;

    public int VendorId { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Vendor Vendor { get; set; } = null!;
}
