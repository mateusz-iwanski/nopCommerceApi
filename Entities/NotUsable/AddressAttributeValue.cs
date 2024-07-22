using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class AddressAttributeValue
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AddressAttributeId { get; set; }

    public bool IsPreSelected { get; set; }

    public int DisplayOrder { get; set; }

    public virtual AddressAttribute AddressAttribute { get; set; } = null!;
}
