using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities;

public partial class Log
{
    public int Id { get; set; }

    public string ShortMessage { get; set; } = null!;

    public string? IpAddress { get; set; }

    public int? CustomerId { get; set; }

    public int LogLevelId { get; set; }

    public string? FullMessage { get; set; }

    public string? PageUrl { get; set; }

    public string? ReferrerUrl { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Customer? Customer { get; set; }
}
