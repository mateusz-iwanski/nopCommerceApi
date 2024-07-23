using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.NotUsable;

namespace nopCommerceApi.Entities.Usable;

/// <summary>
/// Represents a language
/// </summary>
public partial class Language
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the language culture
    /// </summary>
    public string LanguageCulture { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique SEO code
    /// </summary>
    public string? UniqueSeoCode { get; set; }

    /// <summary>
    /// Gets or sets the flag image file name
    /// </summary>
    public string? FlagImageFileName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the language supports "Right-to-left"
    /// </summary>
    public bool Rtl { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
    /// </summary>
    public bool LimitedToStores { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the default currency for this language; 0 is set when we use the default currency display order
    /// </summary>
    public int DefaultCurrencyId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the language is published
    /// </summary>
    public bool Published { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }

    public virtual ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<LocaleStringResource> LocaleStringResources { get; set; } = new List<LocaleStringResource>();

    public virtual ICollection<LocalizedProperty> LocalizedProperties { get; set; } = new List<LocalizedProperty>();

    public virtual ICollection<News> News { get; set; } = new List<News>();

    public virtual ICollection<Poll> Polls { get; set; } = new List<Poll>();
}
