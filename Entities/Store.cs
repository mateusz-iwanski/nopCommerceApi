using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class Store
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string? Hosts { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyAddress { get; set; }

    public string? CompanyPhoneNumber { get; set; }

    public string? CompanyVat { get; set; }

    public string? DefaultMetaKeywords { get; set; }

    public string? DefaultMetaDescription { get; set; }

    public string? DefaultTitle { get; set; }

    public string? HomepageTitle { get; set; }

    public string? HomepageDescription { get; set; }

    public bool SslEnabled { get; set; }

    public int DefaultLanguageId { get; set; }

    public int DisplayOrder { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<BlogComment> BlogComments { get; set; } = new List<BlogComment>();

    public virtual ICollection<NewsComment> NewsComments { get; set; } = new List<NewsComment>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<StoreMapping> StoreMappings { get; set; } = new List<StoreMapping>();
}
