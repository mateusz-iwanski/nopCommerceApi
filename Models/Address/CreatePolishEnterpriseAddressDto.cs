namespace nopCommerceApi.Models.Address
{
    public class CreatePolishEnterpriseAddressDto : AddressDto
    {
        public int CountryId { get; set; }
        public virtual string Company { get; set; }
        public string Nip { get; set; }
        public virtual string City { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string CustomAttributes { get; set; }
    }
}
