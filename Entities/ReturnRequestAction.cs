﻿using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class ReturnRequestAction
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DisplayOrder { get; set; }
}
