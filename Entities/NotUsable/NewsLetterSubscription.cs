using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.NotUsable;

public partial class NewsLetterSubscription
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public Guid NewsLetterSubscriptionGuid { get; set; }

    public bool Active { get; set; }

    public int StoreId { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public int LanguageId { get; set; }
}
