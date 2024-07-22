using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.NotUsable;

namespace nopCommerceApi.Entities.Usable;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? TwoLetterIsoCode { get; set; }

    public string? ThreeLetterIsoCode { get; set; }

    public bool AllowsBilling { get; set; }

    public bool AllowsShipping { get; set; }

    public int NumericIsoCode { get; set; }

    public bool SubjectToVat { get; set; }

    public bool Published { get; set; }

    public int DisplayOrder { get; set; }

    public bool LimitedToStores { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<StateProvince> StateProvinces { get; set; } = new List<StateProvince>();

    public virtual ICollection<ShippingMethod> ShippingMethods { get; set; } = new List<ShippingMethod>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

}
