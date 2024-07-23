using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class NewsComment
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int NewsItemId { get; set; }

    public int StoreId { get; set; }

    public string? CommentTitle { get; set; }

    public string? CommentText { get; set; }

    public bool IsApproved { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual News NewsItem { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
