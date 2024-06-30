using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class Order
{
    public int Id { get; set; }

    public string CustomOrderNumber { get; set; } = null!;

    public int BillingAddressId { get; set; }

    public int CustomerId { get; set; }

    public int? PickupAddressId { get; set; }

    public int? ShippingAddressId { get; set; }

    public string? CustomerIp { get; set; }

    public Guid OrderGuid { get; set; }

    public int StoreId { get; set; }

    public bool PickupInStore { get; set; }

    public int OrderStatusId { get; set; }

    public int ShippingStatusId { get; set; }

    public int PaymentStatusId { get; set; }

    public string? PaymentMethodSystemName { get; set; }

    public string? CustomerCurrencyCode { get; set; }

    public decimal CurrencyRate { get; set; }

    public int CustomerTaxDisplayTypeId { get; set; }

    public string? VatNumber { get; set; }

    public decimal OrderSubtotalInclTax { get; set; }

    public decimal OrderSubtotalExclTax { get; set; }

    public decimal OrderSubTotalDiscountInclTax { get; set; }

    public decimal OrderSubTotalDiscountExclTax { get; set; }

    public decimal OrderShippingInclTax { get; set; }

    public decimal OrderShippingExclTax { get; set; }

    public decimal PaymentMethodAdditionalFeeInclTax { get; set; }

    public decimal PaymentMethodAdditionalFeeExclTax { get; set; }

    public string? TaxRates { get; set; }

    public decimal OrderTax { get; set; }

    public decimal OrderDiscount { get; set; }

    public decimal OrderTotal { get; set; }

    public decimal RefundedAmount { get; set; }

    public int? RewardPointsHistoryEntryId { get; set; }

    public string? CheckoutAttributeDescription { get; set; }

    public string? CheckoutAttributesXml { get; set; }

    public int CustomerLanguageId { get; set; }

    public int AffiliateId { get; set; }

    public bool AllowStoringCreditCardNumber { get; set; }

    public string? CardType { get; set; }

    public string? CardName { get; set; }

    public string? CardNumber { get; set; }

    public string? MaskedCreditCardNumber { get; set; }

    public string? CardCvv2 { get; set; }

    public string? CardExpirationMonth { get; set; }

    public string? CardExpirationYear { get; set; }

    public string? AuthorizationTransactionId { get; set; }

    public string? AuthorizationTransactionCode { get; set; }

    public string? AuthorizationTransactionResult { get; set; }

    public string? CaptureTransactionId { get; set; }

    public string? CaptureTransactionResult { get; set; }

    public string? SubscriptionTransactionId { get; set; }

    public DateTime? PaidDateUtc { get; set; }

    public string? ShippingMethod { get; set; }

    public string? ShippingRateComputationMethodSystemName { get; set; }

    public string? CustomValuesXml { get; set; }

    public bool Deleted { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public int? RedeemedRewardPointsEntryId { get; set; }

    public virtual Address BillingAddress { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<DiscountUsageHistory> DiscountUsageHistories { get; set; } = new List<DiscountUsageHistory>();

    public virtual ICollection<GiftCardUsageHistory> GiftCardUsageHistories { get; set; } = new List<GiftCardUsageHistory>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<OrderNote> OrderNotes { get; set; } = new List<OrderNote>();

    public virtual Address? PickupAddress { get; set; }

    public virtual ICollection<RecurringPayment> RecurringPayments { get; set; } = new List<RecurringPayment>();

    public virtual RewardPointsHistory? RewardPointsHistoryEntry { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public virtual Address? ShippingAddress { get; set; }
}
