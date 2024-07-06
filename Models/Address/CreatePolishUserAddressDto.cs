using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Address
{
    public class CreatePolishUserAddressDto : AddressDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
