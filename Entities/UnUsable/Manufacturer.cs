using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.NotUsable;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? MetaKeywords { get; set; }

    public string? MetaTitle { get; set; }

    public string? PageSizeOptions { get; set; }

    public string? Description { get; set; }

    public int ManufacturerTemplateId { get; set; }

    public string? MetaDescription { get; set; }

    public int PictureId { get; set; }

    public int PageSize { get; set; }

    public bool AllowCustomersToSelectPageSize { get; set; }

    public bool SubjectToAcl { get; set; }

    public bool LimitedToStores { get; set; }

    public bool Published { get; set; }

    public bool Deleted { get; set; }

    public int DisplayOrder { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime UpdatedOnUtc { get; set; }

    public bool PriceRangeFiltering { get; set; }

    public decimal PriceFrom { get; set; }

    public decimal PriceTo { get; set; }

    public bool ManuallyPriceRange { get; set; }

    public virtual ICollection<ProductManufacturerMapping> ProductManufacturerMappings { get; set; } = new List<ProductManufacturerMapping>();

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
}
