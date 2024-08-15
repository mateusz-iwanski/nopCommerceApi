using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class StoreMapping
{
    public int Id { get; set; }

    public string EntityName { get; set; } = null!;

    public int StoreId { get; set; }

    public int EntityId { get; set; }

    public virtual Store Store { get; set; } = null!;
}
