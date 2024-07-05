using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Validations;
using System.Text.Json;

namespace nopCommerceApi.Services
{
    public class UpdateAddressException : Exception
    {

        public UpdateAddressException(string message, string dtoProperty)
        : base(FormatErrorMessage(message, dtoProperty))
        {
        }

        /// <summary>
        /// Format the error message to be returned in JSON format, the same as Validator format
        /// </summary>
        /// <param name="message">Message to show</param>
        /// <param name="dtoProperty">The property for which the message is to be displayed</param>
        /// <returns></returns>
        private static string FormatErrorMessage(string message, string dtoProperty)
        {
            var errorMessage = new Dictionary<string, List<string>>
            {
                { dtoProperty, new List<string> { message } }
            };
            return JsonSerializer.Serialize(errorMessage, new JsonSerializerOptions { WriteIndented = true });
        }
    }

    public interface IAddressService
    {
        IEnumerable<DetailsAddressDto> GetAll();
        Address CreateWithNip(CreatePolishEnterpriseAddressDto newAdressDto);
        bool UpdateWithNip(int id, UpdatePolishEnterpriseAddressDto updateAddressDto);
    }

    public class AddressService : IAddressService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        private UpdatePolishEnterpriseAddressDtoValidator _updateValidator;

        public AddressService(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            
        }

        public IEnumerable<DetailsAddressDto> GetAll()
        {
            var detailsAddresses = _context.Addresses
               .Include(a => a.Country)
               .Include(a => a.StateProvince).ThenInclude(c => c.Country)
               .ToList();
            var addressDtos = _mapper.Map<List<DetailsAddressDto>>(detailsAddresses);

            return addressDtos;
        }

        /// <summary>
        /// Create a new address with NIP as a additional field for enterprises
        /// 
        /// Only for Polish enterprises.
        /// Polish enterprises have an additional field NIP, nop commerce doesn't have this property default in the addrres.
        /// Nip has to be added as a custom attribute to address.
        /// </summary>
        public Address CreateWithNip(CreatePolishEnterpriseAddressDto newAdressDto)
        {
            var address = _mapper.Map<Address>(newAdressDto);
            
            var addressAttribute = _context.AddressAttributes
                .FirstOrDefault(c => c.Name == "NIP" && c.AttributeControlTypeId == 4);

            // If the additional attribute does not exist, create it
            // NopCommerce default doesn't have NIP field in address
            if (addressAttribute == null)
            {
                addressAttribute = new AddressAttribute
                {
                    Name = "NIP",
                    IsRequired = false,
                    AttributeControlTypeId = 4,
                    DisplayOrder = 0,
                };                
                _context.AddressAttributes.Add(addressAttribute);
                _context.SaveChanges();
            }

            // Get Country->Poland ID
            var country = _context.Countries.FirstOrDefault(c => c.Name == "Poland");


            // Add NIP to the address as a custom attribute
            address.CustomAttributes =
                    $"<Attributes><AddressAttribute ID=\"{addressAttribute.Id}\"><AddressAttributeValue><Value>{newAdressDto.Nip}</Value></AddressAttributeValue></AddressAttribute></Attributes>";
            // For polish addresses, the country is always Poland
            address.Country = country;
            address.CreatedOnUtc = DateTime.Now;

            _context.Addresses.Add(address);
            _context.SaveChanges();

            return address;
        }

        /// <summary>
        /// Update address for Polish enterprises
        /// 
        /// Validator check only nip format, in function check if the nip already exists in the database.
        /// In function check if the nip already exists in the database excluding the updated object from the check.
        /// </summary>
        public bool UpdateWithNip(int id, UpdatePolishEnterpriseAddressDto updateAddressDto)
        {
            var address = _context.Addresses
            .Include(a => a.Country)
            .Include(a => a.StateProvince)
            .FirstOrDefault(a => a.Id == id);

            var addressAttribute = _context.AddressAttributes
                .FirstOrDefault(c => c.Name == "NIP" && c.AttributeControlTypeId == 4);

            if (address == null) return false;

            address.FirstName = updateAddressDto.FirstName;
            address.LastName = updateAddressDto.LastName;
            address.Email = updateAddressDto.Email;
            address.Company = updateAddressDto.Company;
            address.County = updateAddressDto.County;
            address.City = updateAddressDto.City;
            address.Address1 = updateAddressDto.Address1;
            address.Address2 = updateAddressDto.Address2;
            address.ZipPostalCode = updateAddressDto.ZipPostalCode;
            address.PhoneNumber = updateAddressDto.PhoneNumber;
            // Set to Poland every time, this function is only for Polish enterprises
            address.Country = _context.Countries.FirstOrDefault(c => c.Name == "Poland");

            // Validate if the NIP already exists in the database
            if (!string.IsNullOrEmpty(updateAddressDto.Nip))
            {
                var addresses = _context.Addresses.ToList();
                    
                var filteredAddresses = addresses.Where(addr => AddressDto.GetValueFromCustomAttribute(addr.CustomAttributes) == updateAddressDto.Nip).ToList();
                // Exclude the updated object from the check
                filteredAddresses = filteredAddresses.Where(addr => addr.Id != updateAddressDto.Id).ToList();

                address.CustomAttributes = filteredAddresses.Count == 0 ?
                    $"<Attributes><AddressAttribute ID=\"{addressAttribute.Id}\"><AddressAttributeValue><Value>{updateAddressDto.Nip}</Value></AddressAttributeValue></AddressAttribute></Attributes>"
                    : throw new UpdateAddressException("NIP already exists in the database", "Nip");
            }

            _context.SaveChanges();

            return true;
            
        }

    }

}
