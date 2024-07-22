using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.NotUsable;

public partial class SpecificationAttributeGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public virtual ICollection<SpecificationAttribute> SpecificationAttributes { get; set; } = new List<SpecificationAttribute>();
}
