﻿using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class ProductTemplate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ViewPath { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public string? IgnoredProductTypes { get; set; }
}
