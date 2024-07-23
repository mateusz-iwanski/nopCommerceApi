using nopCommerceApi.Models.Customer;

namespace nopCommerceApi.Models.Product
{
    public class TierPriceDetailsDto : TierPriceDto
    {
        public virtual CustomerRoleDto? CustomerRole { get; set; }
        public virtual ProductDto Product { get; set;}
    }
}
