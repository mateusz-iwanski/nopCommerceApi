using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.NotUsable;

namespace nopCommerceApi.Entities.Usable;

public partial class SpecificationAttribute
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? SpecificationAttributeGroupId { get; set; }

    public int DisplayOrder { get; set; }

    public virtual SpecificationAttributeGroup? SpecificationAttributeGroup { get; set; }

    public virtual ICollection<SpecificationAttributeOption> SpecificationAttributeOptions { get; set; } = new List<SpecificationAttributeOption>();
}
