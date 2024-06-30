using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class Topic
{
    public int Id { get; set; }

    public string? SystemName { get; set; }

    public bool IncludeInSitemap { get; set; }

    public bool IncludeInTopMenu { get; set; }

    public bool IncludeInFooterColumn1 { get; set; }

    public bool IncludeInFooterColumn2 { get; set; }

    public bool IncludeInFooterColumn3 { get; set; }

    public int DisplayOrder { get; set; }

    public bool AccessibleWhenStoreClosed { get; set; }

    public bool IsPasswordProtected { get; set; }

    public string? Password { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    public bool Published { get; set; }

    public int TopicTemplateId { get; set; }

    public string? MetaKeywords { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaTitle { get; set; }

    public bool SubjectToAcl { get; set; }

    public bool LimitedToStores { get; set; }
}
