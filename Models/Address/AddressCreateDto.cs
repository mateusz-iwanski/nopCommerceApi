using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// <c>CreateAddressDto</c> uses for creating address for individual person
    /// </summary>
    public class AddressCreateDto : AddressDto
    {
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public int CountryId { get; set; }
    }
}
