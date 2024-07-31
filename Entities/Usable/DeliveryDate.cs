using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;

// TODO: add dtos and all rest
public partial class DeliveryDate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DisplayOrder { get; set; }
}
