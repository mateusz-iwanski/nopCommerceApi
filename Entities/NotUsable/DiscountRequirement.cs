using System;
using System.Collections.Generic;

namespace nopCommerceApi.Entities.NotUsable;

public partial class DiscountRequirement
{
    public int Id { get; set; }

    public int DiscountId { get; set; }

    public int? ParentId { get; set; }

    public string? DiscountRequirementRuleSystemName { get; set; }

    public int? InteractionTypeId { get; set; }

    public bool IsGroup { get; set; }

    public virtual Discount Discount { get; set; } = null!;

    public virtual ICollection<DiscountRequirement> InverseParent { get; set; } = new List<DiscountRequirement>();

    public virtual DiscountRequirement? Parent { get; set; }
}
