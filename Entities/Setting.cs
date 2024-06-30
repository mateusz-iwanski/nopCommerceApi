using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class Setting
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    public int StoreId { get; set; }
}
