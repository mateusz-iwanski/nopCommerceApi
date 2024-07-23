using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class BlogComment
{
    public int Id { get; set; }

    public int StoreId { get; set; }

    public int CustomerId { get; set; }

    public int BlogPostId { get; set; }

    public string? CommentText { get; set; }

    public bool IsApproved { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual BlogPost BlogPost { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
