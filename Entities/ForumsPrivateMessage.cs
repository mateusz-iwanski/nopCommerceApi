using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class ForumsPrivateMessage
{
    public int Id { get; set; }

    public string Subject { get; set; } = null!;

    public string Text { get; set; } = null!;

    public int FromCustomerId { get; set; }

    public int ToCustomerId { get; set; }

    public int StoreId { get; set; }

    public bool IsRead { get; set; }

    public bool IsDeletedByAuthor { get; set; }

    public bool IsDeletedByRecipient { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Customer FromCustomer { get; set; } = null!;

    public virtual Customer ToCustomer { get; set; } = null!;
}
