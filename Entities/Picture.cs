using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities;

public partial class Picture
{
    public int Id { get; set; }

    public string MimeType { get; set; } = null!;

    public string? SeoFilename { get; set; }

    public string? AltAttribute { get; set; }

    public string? TitleAttribute { get; set; }

    public bool IsNew { get; set; }

    public string? VirtualPath { get; set; }

    public virtual ICollection<PictureBinary> PictureBinaries { get; set; } = new List<PictureBinary>();

    public virtual ICollection<ProductPictureMapping> ProductPictureMappings { get; set; } = new List<ProductPictureMapping>();
}
