using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class ForumsPost
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public string? Ipaddress { get; set; }

    public int CustomerId { get; set; }

    public int TopicId { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime UpdatedOnUtc { get; set; }

    public int VoteCount { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<ForumsPostVote> ForumsPostVotes { get; set; } = new List<ForumsPostVote>();

    public virtual ForumsTopic Topic { get; set; } = null!;
}
