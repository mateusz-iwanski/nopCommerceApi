using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class PollVotingRecord
{
    public int Id { get; set; }

    public int PollAnswerId { get; set; }

    public int CustomerId { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual PollAnswer PollAnswer { get; set; } = null!;
}
