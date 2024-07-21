using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities;

public partial class StockQuantityHistory
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int QuantityAdjustment { get; set; }

    public int StockQuantity { get; set; }

    public string? Message { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public int? CombinationId { get; set; }

    public int? WarehouseId { get; set; }

    public virtual Product Product { get; set; } = null!;
}
