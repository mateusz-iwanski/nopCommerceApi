using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class AvalaraItemClassification
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? HsclassificationRequestId { get; set; }

    public int CountryId { get; set; }

    public string? Hscode { get; set; }

    public DateTime UpdatedOnUtc { get; set; }
}
