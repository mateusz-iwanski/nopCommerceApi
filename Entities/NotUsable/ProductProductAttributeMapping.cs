using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class ProductProductAttributeMapping
{
    public int Id { get; set; }

    public int ProductAttributeId { get; set; }

    public int ProductId { get; set; }

    public string? TextPrompt { get; set; }

    public bool IsRequired { get; set; }

    public int AttributeControlTypeId { get; set; }

    public int DisplayOrder { get; set; }

    public int? ValidationMinLength { get; set; }

    public int? ValidationMaxLength { get; set; }

    public string? ValidationFileAllowedExtensions { get; set; }

    public int? ValidationFileMaximumSize { get; set; }

    public string? DefaultValue { get; set; }

    public string? ConditionAttributeXml { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ProductAttribute ProductAttribute { get; set; } = null!;

    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>();
}
