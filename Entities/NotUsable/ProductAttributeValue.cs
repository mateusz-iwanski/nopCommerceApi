using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.NotUsable;

public partial class ProductAttributeValue
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ColorSquaresRgb { get; set; }

    public int ProductAttributeMappingId { get; set; }

    public int AttributeValueTypeId { get; set; }

    public int AssociatedProductId { get; set; }

    public int ImageSquaresPictureId { get; set; }

    public decimal PriceAdjustment { get; set; }

    public bool PriceAdjustmentUsePercentage { get; set; }

    public decimal WeightAdjustment { get; set; }

    public decimal Cost { get; set; }

    public bool CustomerEntersQty { get; set; }

    public int Quantity { get; set; }

    public bool IsPreSelected { get; set; }

    public int DisplayOrder { get; set; }

    public int? PictureId { get; set; }

    public virtual ProductProductAttributeMapping ProductAttributeMapping { get; set; } = null!;

    public virtual ICollection<ProductAttributeValuePicture> ProductAttributeValuePictures { get; set; } = new List<ProductAttributeValuePicture>();
}
