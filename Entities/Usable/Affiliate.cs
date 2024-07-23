using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;

/// <summary>
/// Affiliate marketing is an internet-based marketing practice where affiliates are rewarded for generating website traffic (each visitor or customer). It's a web-based pay-for-performance program designed to compensate affiliate partners for driving qualified leads or sales from their websites to the merchant's website.
/// 
/// Affiliates are third parties who refer customers to your site. The nopCommerce software can track those referrals so that the store administrator can determine the commission to be paid to affiliates. Once a customer is assigned an affiliate ID, every order they place will also be tagged with that ID.
/// 
/// In nopCommerce, an affiliate partner link looks as follows: http://www.yourstore.com/?AffiliateID=N (where N is an affiliate ID). A store owner can also specify the friendly URL name field for marketing purposes: http://www.yourstore.com/?affiliate=your_friendly_name_here. This URL is displayed when you visit the affiliate details page. Whenever this hyperlink is clicked on the affiliate site, nopCommerce looks for an affiliate ID query string parameter.
/// </summary>
public partial class Affiliate
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the address identifier
    /// </summary>
    public int AddressId { get; set; }

    /// <summary>
    /// Gets or sets the admin comment
    /// </summary>
    public string? AdminComment { get; set; }

    /// <summary>
    /// Gets or sets the friendly name for generated affiliate URL (by default affiliate ID is used)
    /// </summary>
    public string? FriendlyUrlName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity has been deleted
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is active
    /// </summary>
    public bool Active { get; set; }

    public virtual Address Address { get; set; } = null!;
}
