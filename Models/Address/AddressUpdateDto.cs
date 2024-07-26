using nopCommerceApi.Entities;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// Address Data Transfer Object for updating
    /// </summary>
    public class AddressUpdateDto : AddressDto 
    {
        /// <summary>
        /// Update id of country
        /// </summary>
        public int? CountryId { get; set; }
    }
}
