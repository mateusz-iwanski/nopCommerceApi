using nopCommerceApi.Models.Country;
using nopCommerceApi.Models.State;

namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// Address details Data Transfer Object
    /// </summary>
    /// <remarks>
    /// This object should be used only for the get method in controller
    /// </remarks>
    public class AddressDetailsDto : AddressDto
    {
        /// <summary>
        /// Gets the Nip
        /// </summary>
        public string? NIP { get; set; }

        /// <summary>
        /// Gets the province ID
        /// </summary>
        public int? StateProvinceId { get; set; }

        /// <summary>
        /// Gets the country ID
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets the country object
        /// </summary>
        public CountryDto? Country { get; set; }

        /// <summary>
        /// Gets the state province object
        /// </summary>
        public StateProvinceDto? StateProvince { get; set; }
    }
}
