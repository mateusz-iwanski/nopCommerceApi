using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;

namespace nopCommerceApi.Services
{
    public interface IAddressService
    {
        IEnumerable<DetailsAddressDto> GetAll();
        Address CreateWithNip(CreatePolishEnterpriseAddressDto newAdressDto);
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

        /// <summary>
        /// Create a new address with NIP as a additional field for enterprises
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

    }

}
