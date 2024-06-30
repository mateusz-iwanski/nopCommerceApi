using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class ActivityLog
{
    public int Id { get; set; }

    public string Comment { get; set; } = null!;

    public string? IpAddress { get; set; }

    public string? EntityName { get; set; }

    public int ActivityLogTypeId { get; set; }

    public int CustomerId { get; set; }

    public int? EntityId { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual ActivityLogType ActivityLogType { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
