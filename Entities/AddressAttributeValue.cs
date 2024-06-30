using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class AddressAttributeValue
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AddressAttributeId { get; set; }

    public bool IsPreSelected { get; set; }

    public int DisplayOrder { get; set; }

    public virtual AddressAttribute AddressAttribute { get; set; } = null!;
}
