using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.NotUsable;

public partial class GdprConsent
{
    public int Id { get; set; }

    public string Message { get; set; } = null!;

    public bool IsRequired { get; set; }

    public string? RequiredMessage { get; set; }

    public bool DisplayDuringRegistration { get; set; }

    public bool DisplayOnCustomerInfoPage { get; set; }

    public int DisplayOrder { get; set; }
}
