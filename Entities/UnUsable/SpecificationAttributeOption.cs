using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class SpecificationAttributeOption
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ColorSquaresRgb { get; set; }

    public int SpecificationAttributeId { get; set; }

    public int DisplayOrder { get; set; }

    public virtual ICollection<ProductSpecificationAttributeMapping> ProductSpecificationAttributeMappings { get; set; } = new List<ProductSpecificationAttributeMapping>();

    public virtual SpecificationAttribute SpecificationAttribute { get; set; } = null!;
}
