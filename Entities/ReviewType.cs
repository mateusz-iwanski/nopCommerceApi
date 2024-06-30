using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class ReviewType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public bool VisibleToAllCustomers { get; set; }

    public bool IsRequired { get; set; }

    public virtual ICollection<ProductReviewReviewTypeMapping> ProductReviewReviewTypeMappings { get; set; } = new List<ProductReviewReviewTypeMapping>();
}
