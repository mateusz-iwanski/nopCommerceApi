namespace nopCommerceApi.Models.Address
{
    public class CreatePolishEnterpriseAddressDto : AddressDto
    {
        public string Company { get; set; }
        public string Nip { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
    }
}
