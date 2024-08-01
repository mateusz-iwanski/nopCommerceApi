using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class ProductAttributeCombinationPicture
{
    public int Id { get; set; }

    public int ProductAttributeCombinationId { get; set; }

    public int PictureId { get; set; }

    public virtual ProductAttributeCombination ProductAttributeCombination { get; set; } = null!;
}
