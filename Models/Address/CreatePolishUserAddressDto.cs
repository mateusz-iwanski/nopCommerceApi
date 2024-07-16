﻿using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Address
{
    public class CreatePolishUserAddressDto : AddressDto
    {
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override string PhoneNumber { get; set; }
    }
}
