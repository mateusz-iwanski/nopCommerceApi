using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class ProductReview
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public int StoreId { get; set; }

    public bool IsApproved { get; set; }

    public string? Title { get; set; }

    public string? ReviewText { get; set; }

    public string? ReplyText { get; set; }

    public bool CustomerNotifiedOfReply { get; set; }

    public int Rating { get; set; }

    public int HelpfulYesTotal { get; set; }

    public int HelpfulNoTotal { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductReviewHelpfulness> ProductReviewHelpfulnesses { get; set; } = new List<ProductReviewHelpfulness>();

    public virtual ICollection<ProductReviewReviewTypeMapping> ProductReviewReviewTypeMappings { get; set; } = new List<ProductReviewReviewTypeMapping>();

    public virtual Store Store { get; set; } = null!;
}
