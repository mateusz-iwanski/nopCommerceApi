namespace nopCommerceApi.Models.Address
{
    public class CreateAddressDto : AddressDto
    {
        public int CountryId { get; set; }
        public string? Nip { get; set; }
    }
}
