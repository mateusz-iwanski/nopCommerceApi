using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class News
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Short { get; set; } = null!;

    public string Full { get; set; } = null!;

    public string? MetaKeywords { get; set; }

    public string? MetaTitle { get; set; }

    public int LanguageId { get; set; }

    public bool Published { get; set; }

    public DateTime? StartDateUtc { get; set; }

    public DateTime? EndDateUtc { get; set; }

    public bool AllowComments { get; set; }

    public bool LimitedToStores { get; set; }

    public string? MetaDescription { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Language Language { get; set; } = null!;

    public virtual ICollection<NewsComment> NewsComments { get; set; } = new List<NewsComment>();
}
