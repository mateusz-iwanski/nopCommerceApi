using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class PictureBinary
{
    public int Id { get; set; }

    public int PictureId { get; set; }

    public byte[]? BinaryData { get; set; }

    public virtual Picture Picture { get; set; } = null!;
}
