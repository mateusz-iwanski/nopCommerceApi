using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.NotUsable;

public partial class GoogleAuthenticatorRecord
{
    public int Id { get; set; }

    public string? Customer { get; set; }

    public string? SecretKey { get; set; }
}
