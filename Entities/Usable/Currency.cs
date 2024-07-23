using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;

/// <summary>
/// Represents a currency
/// </summary>
public partial class Currency
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the currency code
    /// </summary>
    public string CurrencyCode { get; set; } = null!;

    /// <summary>
    /// Gets or sets the display locale
    /// </summary>
    public string? DisplayLocale { get; set; }

    /// <summary>
    /// Gets or sets the custom formatting
    /// </summary>
    public string? CustomFormatting { get; set; }

    /// <summary>
    /// Gets or sets the rate
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
    /// </summary>
    public bool LimitedToStores { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is published
    /// </summary>
    public bool Published { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Gets or sets the date and time of instance creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the date and time of instance update
    /// </summary>
    public DateTime UpdatedOnUtc { get; set; }

    /// <summary>
    /// Compatible with nopComerrce 4.70.3
    /// Defines the types of rounding available for price adjustments.
    /// - Rounding001 (0): Default rounding (Math.Round(num, 2)).
    /// - Rounding005Up (10): Prices are rounded up to the nearest multiple of 5 cents for sales ending in: 3¢ & 4¢ round to 5¢; and, 8¢ & 9¢ round to 10¢.
    /// - Rounding005Down (20): Prices are rounded down to the nearest multiple of 5 cents for sales ending in: 1¢ & 2¢ to 0¢; and, 6¢ & 7¢ to 5¢.
    /// - Rounding01Up (30): Round up to the nearest 10 cent value for sales ending in 5¢.
    /// - Rounding01Down (40): Round down to the nearest 10 cent value for sales ending in 5¢.
    /// - Rounding05 (50): Sales ending in 1–24 cents round down to 0¢; Sales ending in 25–49 cents round up to 50¢; Sales ending in 51–74 cents round down to 50¢; Sales ending in 75–99 cents round up to the next whole dollar.
    /// - Rounding1 (60): Sales ending in 1–49 cents round down to 0; Sales ending in 50–99 cents round up to the next whole dollar. For example, Swedish Krona.
    /// - Rounding1Up (70): Sales ending in 1–99 cents round up to the next whole dollar.
    /// </summary>
    public int RoundingTypeId { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

}
