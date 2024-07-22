using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.NotUsable;

public partial class CheckoutAttributeValue
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ColorSquaresRgb { get; set; }

    public int CheckoutAttributeId { get; set; }

    public decimal PriceAdjustment { get; set; }

    public decimal WeightAdjustment { get; set; }

    public bool IsPreSelected { get; set; }

    public int DisplayOrder { get; set; }

    public virtual CheckoutAttribute CheckoutAttribute { get; set; } = null!;
}
