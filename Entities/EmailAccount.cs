using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class EmailAccount
{
    public int Id { get; set; }

    public string? DisplayName { get; set; }

    public string Email { get; set; } = null!;

    public string Host { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Port { get; set; }

    public bool EnableSsl { get; set; }

    public int MaxNumberOfEmails { get; set; }

    public int EmailAuthenticationMethodId { get; set; }

    public string? ClientId { get; set; }

    public string? ClientSecret { get; set; }

    public string? TenantId { get; set; }

    public virtual ICollection<QueuedEmail> QueuedEmails { get; set; } = new List<QueuedEmail>();
}
