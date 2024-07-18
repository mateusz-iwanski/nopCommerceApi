using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Address;
using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Customer
{
    public class CustomerDto : BaseDto
    {
        private Guid _customerGuid = Guid.NewGuid();
        // If we not set/get Email over private _email, we will get an error 'Access violation' from IIS
        protected string? _email { get; set; }
        protected string? _username { get; set; }

        // username can't be null, default it will be set as email when 
        // not set username
        public virtual string? Username
        {
            get => _username;
            set => _username = value?.Trim();
        }

        [EmailAddress]
        public virtual string Email
        {
            get => _email;
            set => _email = value?.Trim();
        }
        public virtual DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        public virtual string? Company { get; set; }
        public virtual string? StreetAddress { get; set; }
        public virtual string? StreetAddress2 { get; set; }
        public virtual string? ZipPostalCode { get; set; }
        public virtual string? City { get; set; }
        public virtual string? County { get; set; }
        public virtual string? Phone { get; set; }
        public virtual string? VatNumber { get; set; }
        public virtual string? SystemName { get; set; }
        public virtual bool IsSystemAccount { get; set; } = false;

        public virtual AddressDto? BillingAddress { get; set; }
        public virtual AddressDto? ShippingAddress { get; set; }
        public virtual LanguageDto? Language { get; set; }
        public virtual CountryDto? Country { get; set; }
        public virtual StateProvinceDto? StateProvince { get; set; }
        public virtual CurrencyDto? Currency { get; set; }

        public virtual Guid CustomerGuid
        {
            get => _customerGuid;
            set
            {
                _customerGuid = Guid.NewGuid();
            }
        }
        public virtual bool IsTaxExempt { get; set; }
        public virtual int VendorId { get; set; }
        public virtual bool Active { get; set; } = true;
        public virtual bool Deleted { get; set; }
    }
}
