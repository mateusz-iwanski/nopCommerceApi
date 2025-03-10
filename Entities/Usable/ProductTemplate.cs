﻿using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;

/// <summary>
/// Represents a product template.
/// </summary>
/// <remarks>
/// In nopCommerce, you can specify an alternate layout template for a category, manufacturer, 
/// product, and topic. You can see a list of the existing templates on the System → Templates page.
/// Doc: https://docs.nopcommerce.com/en/running-your-store/system-administration/templates.html
/// </remarks>
public partial class ProductTemplate
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the template name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the view path
    /// </summary>
    public string ViewPath { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Gets or sets a comma-separated list of product type identifiers NOT supported by this template
    /// </summary>
    public string IgnoredProductTypes { get; set; }
}
