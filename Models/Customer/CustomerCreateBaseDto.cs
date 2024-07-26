using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Customer
{
    /// <summary>
    /// <c>CustomerCreateBaseDto</c> uses for creating nopCommerce customer
    /// </summary>
    public class CustomerCreateBaseDto : BaseDto 
    {
        private bool _isTaxExempt = false; // every PL customer is not tax exempt
        private int _vendorId = 0; // disable multi-vendor option
        private bool _active = true; // when we create PL customer it should be active
        private bool _deleted = false; // we create customer so is not deleted 
        private bool _isSystemAccount = false; // we create customer so is not system account

        /// <summary>
        /// Sets the username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Sets the email
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Sets the email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Automatically sets the guid
        /// </summary>
        [JsonIgnore]
        public virtual Guid CustomerGuid { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the company name
        /// </summary>
        public string? Company { get; set; }

        /// <summary>
        /// Gets or sets the street address
        /// </summary>
        public virtual string? StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the street address 2
        /// </summary>
        public virtual string? StreetAddress2 { get; set; }

        /// <summary>
        /// Gets or sets the zip
        /// </summary>
        public virtual string? ZipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public virtual string? City { get; set; }

        /// <summary>
        /// Gets or sets the county
        /// </summary>
        public virtual string? County { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
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
