using nopCommerceApi.Entities;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Address
{
    public class AddressUpdateDto : AddressDto 
    {
        public int? CountryId { get; set; }
    }
}
