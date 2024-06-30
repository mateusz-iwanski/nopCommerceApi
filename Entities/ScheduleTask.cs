using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class ScheduleTask
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int Seconds { get; set; }

    public DateTime? LastEnabledUtc { get; set; }

    public bool Enabled { get; set; }

    public bool StopOnError { get; set; }

    public DateTime? LastStartUtc { get; set; }

    public DateTime? LastEndUtc { get; set; }

    public DateTime? LastSuccessUtc { get; set; }
}
