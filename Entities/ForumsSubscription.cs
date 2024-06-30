using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class ForumsSubscription
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public Guid SubscriptionGuid { get; set; }

    public int ForumId { get; set; }

    public int TopicId { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
