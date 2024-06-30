using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class PermissionRecord
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string SystemName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public virtual ICollection<CustomerRole> CustomerRoles { get; set; } = new List<CustomerRole>();
}
