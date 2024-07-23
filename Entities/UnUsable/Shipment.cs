using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class Shipment
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string? TrackingNumber { get; set; }

    public decimal? TotalWeight { get; set; }

    public DateTime? ShippedDateUtc { get; set; }

    public DateTime? DeliveryDateUtc { get; set; }

    public DateTime? ReadyForPickupDateUtc { get; set; }

    public string? AdminComment { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<ShipmentItem> ShipmentItems { get; set; } = new List<ShipmentItem>();
}
