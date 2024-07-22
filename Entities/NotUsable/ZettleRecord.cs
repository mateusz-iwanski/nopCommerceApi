using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.NotUsable;

public partial class ZettleRecord
{
    public int Id { get; set; }

    public bool Active { get; set; }

    public string? Uuid { get; set; }

    public int ProductId { get; set; }

    public string? VariantUuid { get; set; }

    public int CombinationId { get; set; }

    public string? ImageUrl { get; set; }

    public int OperationTypeId { get; set; }

    public bool PriceSyncEnabled { get; set; }

    public bool ImageSyncEnabled { get; set; }

    public bool InventoryTrackingEnabled { get; set; }

    public string? ExternalUuid { get; set; }

    public DateTime? UpdatedOnUtc { get; set; }
}
