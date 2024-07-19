using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.Usable;

public partial class StateProvince
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Abbreviation { get; set; }

    public int CountryId { get; set; }

    public bool Published { get; set; }

    public int DisplayOrder { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; }
}
