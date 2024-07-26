using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// <c>CreateAddressDto</c> uses for creating address for individual person
    /// </summary>
    public class AddressCreateDto : AddressDto
    {
        /// <summary>
        /// Sets the first name
        /// </summary>
        [Required]
        public override string FirstName { get; set; }

        /// <summary>
        /// Sets the last name
        /// </summary>
        [Required]
        public override string LastName { get; set; }

        /// <summary>
        /// Sets country ID
        /// </summary>
        [Required]
        public int CountryId { get; set; }
    }
}
