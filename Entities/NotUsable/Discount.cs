using System;
using System.Collections.Generic;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.NotUsable;

public partial class Discount
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? CouponCode { get; set; }

    public string? AdminComment { get; set; }

    public int DiscountTypeId { get; set; }

    public bool UsePercentage { get; set; }

    public decimal DiscountPercentage { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal? MaximumDiscountAmount { get; set; }

    public DateTime? StartDateUtc { get; set; }

    public DateTime? EndDateUtc { get; set; }

    public bool RequiresCouponCode { get; set; }

    public bool IsCumulative { get; set; }

    public int DiscountLimitationId { get; set; }

    public int LimitationTimes { get; set; }

    public int? MaximumDiscountedQuantity { get; set; }

    public bool AppliedToSubCategories { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<DiscountRequirement> DiscountRequirements { get; set; } = new List<DiscountRequirement>();

    public virtual ICollection<DiscountUsageHistory> DiscountUsageHistories { get; set; } = new List<DiscountUsageHistory>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
