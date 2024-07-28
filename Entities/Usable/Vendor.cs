using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.NotUsable;

namespace nopCommerceApi.Entities.Usable;

public partial class Vendor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? MetaKeywords { get; set; }

    public string? MetaTitle { get; set; }

    public string? PageSizeOptions { get; set; }

    public string? Description { get; set; }

    public int PictureId { get; set; }

    public int AddressId { get; set; }

    public string? AdminComment { get; set; }

    public bool Active { get; set; }

    public bool Deleted { get; set; }

    public int DisplayOrder { get; set; }

    public string? MetaDescription { get; set; }

    public int PageSize { get; set; }

    public bool AllowCustomersToSelectPageSize { get; set; }

    public bool PriceRangeFiltering { get; set; }

    public decimal PriceFrom { get; set; }

    public decimal PriceTo { get; set; }

    public bool ManuallyPriceRange { get; set; }

    public virtual ICollection<VendorNote> VendorNotes { get; set; } = new List<VendorNote>();
}
