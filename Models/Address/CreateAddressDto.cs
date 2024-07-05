namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// <c>CreateAddressDto</c> uses for creating address for individual person
    /// </summary>
    public class CreateAddressDto : AddressDto
    {
        public int CountryId { get; set; }
        /// <value>
        /// Sometimes individual person has personal nip
        /// </value>
        public string? Nip { get; set; }
    }
}
