using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.NotUsable;

public partial class FacebookPixelConfiguration
{
    public int Id { get; set; }

    public string? PixelId { get; set; }

    public string? AccessToken { get; set; }

    public bool PixelScriptEnabled { get; set; }

    public bool ConversionsApiEnabled { get; set; }

    public bool DisableForUsersNotAcceptingCookieConsent { get; set; }

    public int StoreId { get; set; }

    public bool PassUserProperties { get; set; }

    public bool UseAdvancedMatching { get; set; }

    public bool TrackPageView { get; set; }

    public bool TrackAddToCart { get; set; }

    public bool TrackPurchase { get; set; }

    public bool TrackViewContent { get; set; }

    public bool TrackAddToWishlist { get; set; }

    public bool TrackInitiateCheckout { get; set; }

    public bool TrackSearch { get; set; }

    public bool TrackContact { get; set; }

    public bool TrackCompleteRegistration { get; set; }

    public string? CustomEvents { get; set; }
}
