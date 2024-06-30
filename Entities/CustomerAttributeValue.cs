using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class CustomerAttributeValue
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CustomerAttributeId { get; set; }

    public bool IsPreSelected { get; set; }

    public int DisplayOrder { get; set; }

    public virtual CustomerAttribute CustomerAttribute { get; set; } = null!;
}
