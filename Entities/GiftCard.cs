using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class GiftCard
{
    public int Id { get; set; }

    public int? PurchasedWithOrderItemId { get; set; }

    public int GiftCardTypeId { get; set; }

    public decimal Amount { get; set; }

    public bool IsGiftCardActivated { get; set; }

    public string? GiftCardCouponCode { get; set; }

    public string? RecipientName { get; set; }

    public string? RecipientEmail { get; set; }

    public string? SenderName { get; set; }

    public string? SenderEmail { get; set; }

    public string? Message { get; set; }

    public bool IsRecipientNotified { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual ICollection<GiftCardUsageHistory> GiftCardUsageHistories { get; set; } = new List<GiftCardUsageHistory>();

    public virtual OrderItem? PurchasedWithOrderItem { get; set; }
}
