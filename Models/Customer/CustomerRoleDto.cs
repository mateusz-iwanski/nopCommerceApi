namespace nopCommerceApi.Models.Customer
{
    public class CustomerRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? SystemName { get; set; }
        public bool FreeShipping { get; set; }
        public bool TaxExempt { get; set; }
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }
        public bool EnablePasswordLifetime { get; set; }
        public bool OverrideTaxDisplayType { get; set; }
        public int DefaultTaxDisplayTypeId { get; set; }
        public int PurchasedWithProductId { get; set; }
    }
}
