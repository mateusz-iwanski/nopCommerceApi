using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Models.Country;
using nopCommerceApi.Models.Language;
using nopCommerceApi.Models.State;
using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Customer
{
    public class CustomerDto : BaseDto
    {
        public virtual string Id { get; set; }  
        public virtual string? Username { get; set; }

        [EmailAddress]
        public virtual string Email { get; set; }
        public virtual DateTime CreatedOnUtc { get; set; }
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
        public virtual bool IsSystemAccount { get; set; }

        public virtual AddressDto? BillingAddress { get; set; }
        public virtual AddressDto? ShippingAddress { get; set; }
        public virtual LanguageDto? Language { get; set; }
        public virtual CountryDto? Country { get; set; }
        public virtual StateProvinceDto? StateProvince { get; set; }
        public virtual CurrencyDto? Currency { get; set; }
        public virtual Guid CustomerGuid { get; set; }
        public virtual bool IsTaxExempt { get; set; }
        public virtual int VendorId { get; set; }
        public virtual bool Active { get; set; }
        public virtual bool Deleted { get; set; }
    }
}
