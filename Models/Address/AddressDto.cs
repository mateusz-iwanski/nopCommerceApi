using System;
using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Address
{
    public class AddressDto
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        [EmailAddress]
        public virtual string? Email { get; set; }
        public virtual string? Company { get; set; }        
        public virtual string? County { get; set; }
        public virtual string? City { get; set; }
        public virtual string? Address1 { get; set; }
        public virtual string? Address2 { get; set; }
        public virtual string? ZipPostalCode { get; set; }
        public virtual string? PhoneNumber { get; set; }
        public virtual string? FaxNumber { get; set; }
        public virtual string? CustomAttributes { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }

}
