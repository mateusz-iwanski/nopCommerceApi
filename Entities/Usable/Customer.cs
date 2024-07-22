using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.NotUsable;

namespace nopCommerceApi.Entities.Usable;

public partial class Customer
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? EmailToRevalidate { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string? Company { get; set; }

    public string? StreetAddress { get; set; }

    public string? StreetAddress2 { get; set; }

    public string? ZipPostalCode { get; set; }

    public string? City { get; set; }

    public string? County { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? VatNumber { get; set; }

    public string? TimeZoneId { get; set; }

    public string? CustomCustomerAttributesXml { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? SystemName { get; set; }

    public string? LastIpAddress { get; set; }

    public int? CurrencyId { get; set; }

    public int? LanguageId { get; set; }

    public int? BillingAddressId { get; set; }

    public int? ShippingAddressId { get; set; }

    public Guid CustomerGuid { get; set; }

    public int CountryId { get; set; }

    public int StateProvinceId { get; set; }

    public int VatNumberStatusId { get; set; }

    public int? TaxDisplayTypeId { get; set; }

    public string? AdminComment { get; set; }

    public bool IsTaxExempt { get; set; }

    public int AffiliateId { get; set; }

    public int VendorId { get; set; }

    public bool HasShoppingCartItems { get; set; }

    public bool RequireReLogin { get; set; }

    public int FailedLoginAttempts { get; set; }

    public DateTime? CannotLoginUntilDateUtc { get; set; }

    public bool Active { get; set; }

    public bool Deleted { get; set; }

    public bool IsSystemAccount { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? LastLoginDateUtc { get; set; }

    public DateTime LastActivityDateUtc { get; set; }

    public int RegisteredInStoreId { get; set; }

    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

    public virtual ICollection<BackInStockSubscription> BackInStockSubscriptions { get; set; } = new List<BackInStockSubscription>();

    public virtual Address? BillingAddress { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<BlogComment> BlogComments { get; set; } = new List<BlogComment>();

    public virtual Currency? Currency { get; set; }

    public virtual ICollection<CustomerPassword> CustomerPasswords { get; set; } = new List<CustomerPassword>();

    public virtual ICollection<ExternalAuthenticationRecord> ExternalAuthenticationRecords { get; set; } = new List<ExternalAuthenticationRecord>();

    public virtual ICollection<ForumsPost> ForumsPosts { get; set; } = new List<ForumsPost>();

    public virtual ICollection<ForumsPrivateMessage> ForumsPrivateMessageFromCustomers { get; set; } = new List<ForumsPrivateMessage>();

    public virtual ICollection<ForumsPrivateMessage> ForumsPrivateMessageToCustomers { get; set; } = new List<ForumsPrivateMessage>();

    public virtual ICollection<ForumsSubscription> ForumsSubscriptions { get; set; } = new List<ForumsSubscription>();

    public virtual ICollection<ForumsTopic> ForumsTopics { get; set; } = new List<ForumsTopic>();

    public virtual Language? Language { get; set; }

    public virtual StateProvince? StateProvince { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual ICollection<NewsComment> NewsComments { get; set; } = new List<NewsComment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PollVotingRecord> PollVotingRecords { get; set; } = new List<PollVotingRecord>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<ReturnRequest> ReturnRequests { get; set; } = new List<ReturnRequest>();

    public virtual ICollection<RewardPointsHistory> RewardPointsHistories { get; set; } = new List<RewardPointsHistory>();

    public virtual Address? ShippingAddress { get; set; }

    public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<CustomerRole> CustomerRoles { get; set; } = new List<CustomerRole>();
}
