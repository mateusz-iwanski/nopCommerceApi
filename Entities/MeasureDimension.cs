using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class MeasureDimension
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string SystemKeyword { get; set; } = null!;

    public decimal Ratio { get; set; }

    public int DisplayOrder { get; set; }
}
