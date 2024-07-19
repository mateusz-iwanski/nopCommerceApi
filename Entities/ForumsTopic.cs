using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities;

public partial class ForumsTopic
{
    public int Id { get; set; }

    public string Subject { get; set; } = null!;

    public int CustomerId { get; set; }

    public int ForumId { get; set; }

    public int TopicTypeId { get; set; }

    public int NumPosts { get; set; }

    public int Views { get; set; }

    public int LastPostId { get; set; }

    public int LastPostCustomerId { get; set; }

    public DateTime? LastPostTime { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime UpdatedOnUtc { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ForumsForum Forum { get; set; } = null!;

    public virtual ICollection<ForumsPost> ForumsPosts { get; set; } = new List<ForumsPost>();
}
