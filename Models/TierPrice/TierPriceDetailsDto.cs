using nopCommerceApi.Models.Customer;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Models.TierPrice
{
    public class TierPriceDetailsDto : TierPriceDto
    {
        public virtual CustomerRoleDto? CustomerRole { get; set; }
        public virtual ProductDto Product { get; set; }
    }
}
