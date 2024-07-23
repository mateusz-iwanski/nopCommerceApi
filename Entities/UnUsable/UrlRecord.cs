using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.NotUsable;

public partial class UrlRecord
{
    public int Id { get; set; }

    public string EntityName { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public int EntityId { get; set; }

    public bool IsActive { get; set; }

    public int LanguageId { get; set; }
}
