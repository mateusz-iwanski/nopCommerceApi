﻿namespace nopCommerceApi.Models.Address
{
    public class CreatePolishEnterpriseAddressDto : AddressDto
    {
        public override string Company { get; set; }
        public string Nip { get; set; }
        public override string City { get; set; }
        public override string Address1 { get; set; }
    }
}
