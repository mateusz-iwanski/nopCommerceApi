using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.NotUsable;

public partial class GenericAttribute
{
    public int Id { get; set; }

    public string KeyGroup { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public int EntityId { get; set; }

    public int StoreId { get; set; }

    public DateTime? CreatedOrUpdatedDateUtc { get; set; }
}
