using nopCommerceApi.Entities;

namespace nopCommerceApi.Models.Customer
{
    /// <summary>
    /// The customer roles in nopCommerce enable you to form groups of your web store users. 
    /// You can create various groups, such as store admins, shoppers, vendors, and others. 
    /// 
    /// If you don't need this option just leave this field empty. 
    /// In order to use this functionality, you have to disable the following 
    /// setting: Configuration > Settings > Catalog > Ignore ACL rules (sitewide).
    /// </summary>

    public class CustomerRoleDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? SystemName { get; set; }
        public bool FreeShipping {  get; set; }
        public bool TaxExempt { get; set; }
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }
        public bool EnablePasswordLifetime { get; set; }
        public bool OverrideTaxDisplayType { get; set; }
        public int DefaultTaxDisplayTypeId { get; set; }
        public int PurchasedWithProductId { get; set; }
    }
}
