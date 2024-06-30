using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class LocaleStringResource
{
    public int Id { get; set; }

    public string ResourceName { get; set; } = null!;

    public string ResourceValue { get; set; } = null!;

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; } = null!;
}
