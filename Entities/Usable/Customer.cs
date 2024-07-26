using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.NotUsable;

namespace nopCommerceApi.Entities.Usable;

/// <summary>
/// Represents a customer
/// </summary>
public partial class Customer
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the username
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the email that should be re-validated. Used in scenarios when a customer is already registered and wants to change an email address.
    /// </summary>
    public string? EmailToRevalidate { get; set; }

    /// <summary>
    /// Gets or sets the first name
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the gender
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// Gets or sets the company name
    /// </summary>
    public string? Company { get; set; }

    /// <summary>
    /// Gets or sets the street address
    /// </summary>
    public string? StreetAddress { get; set; }

    /// <summary>
    /// Gets or sets the street address 2
    /// </summary>
    public string? StreetAddress2 { get; set; }

    /// <summary>
    /// Gets or sets the zip
    /// </summary>
    public string? ZipPostalCode { get; set; }

    /// <summary>
    /// Gets or sets the city
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets the county
    /// </summary>
    public string? County { get; set; }

    /// <summary>
    /// Gets or sets the phone number
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets the fax
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    /// Gets or sets the vat number
    /// </summary>
    public string? VatNumber { get; set; }

    /// <summary>
    /// Gets or sets the time zone id
    /// </summary>
    public string? TimeZoneId { get; set; }

    /// <summary>
    /// Gets or sets the custom attributes
    /// </summary>
    public string? CustomCustomerAttributesXml { get; set; }

    /// <summary>
    /// Gets or sets the date of birth
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the customer system name
    /// </summary>
    public string? SystemName { get; set; }

    /// <summary>
    /// Gets or sets the last IP address
    /// </summary>
    public string? LastIpAddress { get; set; }

    /// <summary>
    /// Gets or sets the currency id
    /// </summary>
    public int? CurrencyId { get; set; }

    /// <summary>
    /// Get or sets the language id
    /// </summary>
    public int? LanguageId { get; set; }

    /// <summary>
    /// Gets or sets the billing address identifier
    /// </summary>
    public int? BillingAddressId { get; set; }

    /// <summary>
    /// Gets or sets the shipping address identifier
    /// </summary>
    public int? ShippingAddressId { get; set; }

    /// <summary>
    /// Gets or sets the customer GUID
    /// </summary>
    public Guid CustomerGuid { get; set; }

    /// <summary>
    /// Gets or sets the country id
    /// </summary>
    public int CountryId { get; set; }

    /// <summary>
    /// Gets or sets the state province id
    /// </summary>
    public int StateProvinceId { get; set; }

    /// <summary>
    /// Gets or sets the vat number status id
    /// </summary>
    public int VatNumberStatusId { get; set; }

    /// <summary>
    /// Gets or sets the tax display type id
    /// </summary>
    public int? TaxDisplayTypeId { get; set; }

    /// <summary>
    /// Gets or sets the admin comment
    /// </summary>
    public string? AdminComment { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the customer is tax exempt
    /// </summary>
    public bool IsTaxExempt { get; set; }

    /// <summary>
    /// Gets or sets the affiliate identifier
    /// </summary>
    public int AffiliateId { get; set; }

    /// <summary>
    /// Gets or sets the vendor identifier with which this customer is associated (manager)
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this customer has some products in the shopping cart.
    /// The same as if we run ShoppingCartItems.Count > 0.
    /// We use this property for performance optimization:
    /// if this property is set to false, then we do not need to load "ShoppingCartItems" navigation property for each page load.
    /// It's used only in a couple of places in the presentation layer.
    /// </summary>
    public bool HasShoppingCartItems { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the customer is required to re-login
    /// </summary>
    public bool RequireReLogin { get; set; }

    /// <summary>
    /// Gets or sets a value indicating number of failed login attempts (wrong password)
    /// </summary>
    public int FailedLoginAttempts { get; set; }

    /// <summary>
    /// Gets or sets the date and time until which a customer cannot login (locked out)
    /// </summary>
    public DateTime? CannotLoginUntilDateUtc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the customer is active
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the customer has been deleted
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the customer account is system
    /// </summary>
    public bool IsSystemAccount { get; set; }

    /// <summary>
    /// Gets or sets the date and time of entity creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the date and time of last login
    /// </summary>
    public DateTime? LastLoginDateUtc { get; set; }

    /// <summary>
    /// Gets or sets the date and time of last activity
    /// </summary>
    public DateTime LastActivityDateUtc { get; set; }

    /// <summary>
    ///  Gets or sets the store identifier in which customer registered
    /// </summary>
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
