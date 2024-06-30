using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class CheckoutAttribute
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? TextPrompt { get; set; }

    public bool ShippableProductRequired { get; set; }

    public bool IsTaxExempt { get; set; }

    public int TaxCategoryId { get; set; }

    public bool LimitedToStores { get; set; }

    public int? ValidationMinLength { get; set; }

    public int? ValidationMaxLength { get; set; }

    public string? ValidationFileAllowedExtensions { get; set; }

    public int? ValidationFileMaximumSize { get; set; }

    public string? DefaultValue { get; set; }

    public string? ConditionAttributeXml { get; set; }

    public bool IsRequired { get; set; }

    public int AttributeControlTypeId { get; set; }

    public int DisplayOrder { get; set; }

    public virtual ICollection<CheckoutAttributeValue> CheckoutAttributeValues { get; set; } = new List<CheckoutAttributeValue>();
}
