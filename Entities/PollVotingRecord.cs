using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class PollVotingRecord
{
    public int Id { get; set; }

    public int PollAnswerId { get; set; }

    public int CustomerId { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual PollAnswer PollAnswer { get; set; } = null!;
}
