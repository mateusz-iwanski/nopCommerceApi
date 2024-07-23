using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;

/// <summary>
/// Represents a customer password
/// </summary>
public partial class CustomerPassword
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the password
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Password format (compatible with nopCommerce 4,70.3)
    /// - Clear (0): The password is stored as plain text.
    /// - Hashed (1): The password is stored as a hash.
    /// - Encrypted (2): The password is stored in an encrypted form.
    /// </summary>
    public int PasswordFormatId { get; set; }

    /// <summary>
    /// Gets or sets the password salt
    /// </summary>
    public string? PasswordSalt { get; set; }

    /// <summary>
    /// Gets or sets the date and time of entity creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
