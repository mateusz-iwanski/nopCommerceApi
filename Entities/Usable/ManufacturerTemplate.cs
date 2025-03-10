﻿using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;

public partial class ManufacturerTemplate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ViewPath { get; set; } = null!;

    public int DisplayOrder { get; set; }
}
