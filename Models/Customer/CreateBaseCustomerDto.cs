using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Customer
{
    public class CreateBaseCustomerDto : BaseDto //:CustomerDto
    {
        private bool _isTaxExempt = false; // every PL customer is not tax exempt
        private int _vendorId = 0; // disable multi-vendor option
        private bool _active = true; // when we create PL customer it should be active
        private bool _deleted = false; // we create customer so is not deleted 
        private bool _isSystemAccount = false; // we create customer so is not system account

        public string Username { get; set; }
        public string? Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [JsonIgnore]
        public virtual Guid CustomerGuid { get; set; } = Guid.NewGuid();

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Company { get; set; }
        public virtual string? StreetAddress { get; set; }
        public virtual string? StreetAddress2 { get; set; }
        public virtual string? ZipPostalCode { get; set; }
        public virtual string? City { get; set; }
        public virtual string? County { get; set; }
        public virtual string? Phone { get; set; }

        [JsonIgnore]
        public bool IsTaxExempt
        {
            get => _isTaxExempt;
            set { }
        }

        [JsonIgnore]
        public int VendorId
        {
            get => _vendorId;
            set { }
        }

        [JsonIgnore]
        public bool Active
        {
            get => _active;
            set { }
        }

        [JsonIgnore]
        public bool Deleted
        {
            get => _deleted;
            set { }
        }

        [JsonIgnore]
        public bool IsSystemAccount
        {
            get => _isSystemAccount;
            set { }
        }

        [JsonIgnore]
        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
    }
}
