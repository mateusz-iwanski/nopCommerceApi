using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities;

public partial class BlogPost
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Body { get; set; } = null!;

    public string? MetaKeywords { get; set; }

    public string? MetaTitle { get; set; }

    public int LanguageId { get; set; }

    public bool IncludeInSitemap { get; set; }

    public string? BodyOverview { get; set; }

    public bool AllowComments { get; set; }

    public string? Tags { get; set; }

    public DateTime? StartDateUtc { get; set; }

    public DateTime? EndDateUtc { get; set; }

    public string? MetaDescription { get; set; }

    public bool LimitedToStores { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual ICollection<BlogComment> BlogComments { get; set; } = new List<BlogComment>();

    public virtual Language Language { get; set; } = null!;
}
