using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.NotUsable;

public partial class ProductAttribute
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<PredefinedProductAttributeValue> PredefinedProductAttributeValues { get; set; } = new List<PredefinedProductAttributeValue>();

    public virtual ICollection<ProductProductAttributeMapping> ProductProductAttributeMappings { get; set; } = new List<ProductProductAttributeMapping>();
}
