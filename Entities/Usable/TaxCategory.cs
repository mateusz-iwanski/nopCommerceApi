﻿using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;

/// <summary>
/// Represents a tax category
/// Choose the Default tax category for products. It will be pre-selected on the Add new product page.
/// </summary>
public partial class TaxCategory
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }
}
