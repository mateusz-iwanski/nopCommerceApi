using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Customer
{
    public class CreateBaseCustomerPLDto : CustomerDto
    {
        public override string Username
        {
            get => _username;
            set => _username = value.Trim(); //= !string.IsNullOrWhiteSpace(value) ? value.Trim() : throw new BadRequestException("Username is empty");
        }

        [EmailAddress]
        public override string Email
        {
            get => _email;
            set => _email = value.Trim();
        }

        public override Guid CustomerGuid { get; set; } = Guid.NewGuid();
        public override bool IsTaxExempt { get; set; } = false;
        public override int VendorId { get; set; } = 0;
        public override bool Active { get; set; } = true;
        public override bool Deleted { get; set; } = false;
    }
}
