using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class ProductAttributeValuePicture
{
    public int Id { get; set; }

    public int ProductAttributeValueId { get; set; }

    public int PictureId { get; set; }

    public virtual ProductAttributeValue ProductAttributeValue { get; set; } = null!;
}
