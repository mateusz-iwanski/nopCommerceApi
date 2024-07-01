using nopCommerceApi.Entities;

namespace nopCommerceApi.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Company { get; set; }
        public string? StreetAddress { get; set; }
        public string? StreetAddress2 { get; set; }
        public string? ZipPostalCode { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public string? Phone { get; set; }
        public string? VatNumber { get; set; }
        public string? SystemName { get; set; }
        public Guid CustomerGuid { get; set; }
        public bool IsTaxExempt { get; set; }
        public int VendorId { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        public AddressDto? BillingAddress { get; set; }
        public AddressDto? ShippingAddress { get; set; }
        public LanguageDto? Language { get; set; }
        
        public CountryDto? Country { get; set; }
        public StateProvinceDto? StateProvince { get; set; }
        public CurrencyDto? Currency { get; set; }
    }
}
