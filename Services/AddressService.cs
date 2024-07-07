using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Validations;
using System.Text.Json;

namespace nopCommerceApi.Services
{
    public class AddressException : Exception
    {
        public AddressException(string message, string dtoProperty)
        : base(FormatErrorMessage(message, dtoProperty))
        {
        }

        /// <summary>
        /// Format the error message to be returned in JSON format
        /// </summary>
        /// <param name="message">Message to show</param>
        /// <param name="dtoProperty">The property for which the message is to be display</param>
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
        Address Create(CreateAddressDto addressDto);
        bool Delete(int id);
        bool Update(int id, UpdateAddressDto updateAddressDto);
        DetailsAddressDto GetById(int id);
    }

    public class AddressService : IAddressService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

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

        public DetailsAddressDto GetById(int id) {             
            var address = _context.Addresses
                .Include(a => a.Country)
                .Include(a => a.StateProvince).ThenInclude(c => c.Country)
                .FirstOrDefault(a => a.Id == id);
            
            var addressDto = _mapper.Map<DetailsAddressDto>(address);
            return addressDto;
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
        /// Nip has to be always set in the request body.
        /// In function check if the nip already exists in the database excluding the updated object from the check.
        /// If property not set in the request body, it will not be updated.
        /// Cant set empty string on: Company, City, Email, Address1, PhoneNumber. If you don't want to update, just remove from body.
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

            // Only update this fields which are not null

            if (updateAddressDto.FirstName != null)
                address.FirstName = updateAddressDto.FirstName;

            if (updateAddressDto.LastName != null)
                address.LastName = updateAddressDto.LastName;

            if (updateAddressDto.Email != null)
                address.Email = updateAddressDto.Email;

            if (updateAddressDto.Company != null)
                address.Company = updateAddressDto.Company;

            if (updateAddressDto.County != null)
                address.County = updateAddressDto.County;

            if (updateAddressDto.City != null)
                address.City = updateAddressDto.City;

            if (updateAddressDto.Address1 != null)
                address.Address1 = updateAddressDto.Address1;

            if (updateAddressDto.Address2 != null)
                address.Address2 = updateAddressDto.Address2;

            if (updateAddressDto.ZipPostalCode != null)
                address.ZipPostalCode = updateAddressDto.ZipPostalCode;

            if (updateAddressDto.PhoneNumber != null)
                address.PhoneNumber = updateAddressDto.PhoneNumber;

            // Set to Poland every time, this function is only for Polish enterprises
            address.Country = _context.Countries.FirstOrDefault(c => c.Name == "Poland");

            // Validate if the NIP already exists in the database
            // but exclude the updated object from the check
            if (!string.IsNullOrEmpty(updateAddressDto.Nip))
            {
                var addresses = _context.Addresses.ToList();

                var filteredAddresses = addresses.Where(addr => AddressDto.GetValueFromCustomAttribute(addr.CustomAttributes) == updateAddressDto.Nip).ToList();
                // Exclude the updated object from the check
                filteredAddresses = filteredAddresses.Where(addr => addr.Id != updateAddressDto.Id).ToList();

                address.CustomAttributes = filteredAddresses.Count == 0 ?
                    $"<Attributes><AddressAttribute ID=\"{addressAttribute.Id}\"><AddressAttributeValue><Value>{updateAddressDto.Nip}</Value></AddressAttributeValue></AddressAttribute></Attributes>"
                    : throw new AddressException("NIP already exists in the database", "Nip");
            }

            _context.SaveChanges();

            return true;
        }

        public Address Create(CreateAddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            _context.Addresses.Add(address);
            _context.SaveChanges();

            return address;
        }

        public bool Delete(int id)
        {
            var address = _context.Addresses.FirstOrDefault(a => a.Id == id);

            if (address == null) return false;

            _context.Addresses.Remove(address);
            _context.SaveChanges();

            return true;
        }

        public bool Update(int id, UpdateAddressDto updateAddressDto)
        {
            var address = _context.Addresses.FirstOrDefault(a => a.Id == id);

            if (address == null) return false;

            // If is enterprise address, can't update
            if (AddressDto.IsEnterpriseAddress(address, _context.AddressAttributes))
                throw new AddressException("Address is enterprise, can\'t update. Use update-with-nip enterprise addresses.", "Enterprise");


            // Only update this fields which are not null

            if (updateAddressDto.FirstName != null)
                address.FirstName = updateAddressDto.FirstName;

            if (updateAddressDto.LastName != null)
                address.LastName = updateAddressDto.LastName;

            if (updateAddressDto.Email != null)
                address.Email = updateAddressDto.Email;

            if (updateAddressDto.Company != null)
                address.Company = updateAddressDto.Company;

            if (updateAddressDto.County != null)
                address.County = updateAddressDto.County;

            if (updateAddressDto.City != null)
                address.City = updateAddressDto.City;

            if (updateAddressDto.Address1 != null)
                address.Address1 = updateAddressDto.Address1;

            if (updateAddressDto.Address2 != null)
                address.Address2 = updateAddressDto.Address2;

            if (updateAddressDto.ZipPostalCode != null)
                address.ZipPostalCode = updateAddressDto.ZipPostalCode;

            if (updateAddressDto.PhoneNumber != null)
                address.PhoneNumber = updateAddressDto.PhoneNumber;

            if (updateAddressDto.CountryId != null)
                address.CountryId = updateAddressDto.CountryId;

            _context.SaveChanges();

            return true;
        }
    }

}
