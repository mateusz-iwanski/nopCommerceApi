using AutoMapper;
using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Models.Manufacturer;
using nopCommerceApi.Validations;
using System.Text.Json;

namespace nopCommerceApi.Services
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDetailsDto>> GetAllAsync();
        Task<AddressDetailsDto> CreateWithNipAsync(AddressCreatePolishEnterpriseDto newAdressDto);
        Task<AddressDetailsDto> UpdateWithNipAsync(AddressUpdatePolishEnterpriseDto updateAddressDto);
        Task<AddressDetailsDto> CreateAsync(AddressCreateDto addressDto);
        Task<bool> DeleteAsync(int id);
        Task<AddressDetailsDto> UpdateAsync(AddressUpdateDto updateAddressDto);
        Task<AddressDetailsDto> GetByIdAsync(int id);
    }

    public class AddressService : BaseService, IAddressService
    {
        public AddressService(NopCommerceContext context, IMapper mapper, ILogger<AddressAttributeService> logger
            ) : base(context, mapper, logger)
        {
        }

        public async Task<IEnumerable<AddressDetailsDto>> GetAllAsync()
        {
            var detailsAddresses = await _context.Addresses
               .Include(a => a.Country)
               .Include(a => a.StateProvince).ThenInclude(c => c.Country)
               .AsNoTracking()
               .ToListAsync();
            var addressDtos = _mapper.Map<List<AddressDetailsDto>>(detailsAddresses);

            return addressDtos;
        }

        public async Task<AddressDetailsDto> GetByIdAsync(int id)
        {
            var address = await _context.Addresses
                .Include(a => a.Country)
                .Include(a => a.StateProvince).ThenInclude(c => c.Country)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (address == null) throw new NotFoundExceptions($"Address with {id} not found.");

            var addressDto = _mapper.Map<AddressDetailsDto>(address);
            return addressDto;
        }

        /// <summary>
        /// Create a new address with NIP as a additional field for enterprises
        /// 
        /// Only for Polish enterprises.
        /// Polish enterprises have an additional field NIP, nop commerce doesn't have this property default in the addrres.
        /// Nip has to be added as a custom attribute to address.
        /// </summary>
        public async Task<AddressDetailsDto> CreateWithNipAsync(AddressCreatePolishEnterpriseDto newAdressDto)
        {
            var address = _mapper.Map<Address>(newAdressDto);

            var addressAttribute = await _context.AddressAttributes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == "NIP" && c.AttributeControlTypeId == 4);

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

                await _context.SaveChangesAsync();
            }

            // Get Country->Poland ID
            var country = await _context.Countries
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == "Poland");


            // Add NIP to the address as a custom attribute
            address.CustomAttributes =
                    $"<Attributes><AddressAttribute ID=\"{addressAttribute.Id}\"><AddressAttributeValue><Value>{newAdressDto.Nip}</Value></AddressAttributeValue></AddressAttribute></Attributes>";

            // For polish addresses, the country is always Poland
            address.CountryId = country.Id;
            address.CreatedOnUtc = DateTime.Now;

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            var addressDto = _mapper.Map<AddressDetailsDto>(address);

            return addressDto;
        }

        /// <summary>
        /// Update address for Polish enterprises
        /// </summary>
        /// <remarks>
        /// Nip has to be always set in the request body.
        /// In function check if the nip already exists in the database excluding the updated object from the check.
        /// If property not set in the request body, it will not be updated.
        /// Cant set empty string on: Company, City, Email, Address1, PhoneNumber. If you don't want to update, just remove from body.
        /// </remarks>
        public async Task<AddressDetailsDto> UpdateWithNipAsync(AddressUpdatePolishEnterpriseDto updateAddressDto)
        {
            var id = updateAddressDto.Id;

            var address = await _context.Addresses                
                .FirstOrDefaultAsync(a => a.Id == id);

            updateAddressDto.CreatedOnUtc = address.CreatedOnUtc;
            updateAddressDto.CountryId = address.CountryId;

            var addressAttribute = await _context.AddressAttributes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == "NIP" && c.AttributeControlTypeId == 4);

            updateAddressDto.CustomAttributes =
                $"<Attributes><AddressAttribute ID=\"{addressAttribute.Id}\"><AddressAttributeValue><Value>{updateAddressDto.Nip}</Value></AddressAttributeValue></AddressAttribute></Attributes>";

            _mapper.Map(updateAddressDto, address);
             
            _context.Addresses.Update(address);

            await _context.SaveChangesAsync();

            var addressDto = _mapper.Map<AddressDto>(address);

            var addressDetailsDto = _mapper.Map<AddressDetailsDto>(addressDto);

            return addressDetailsDto;
        }

        public async Task<AddressDetailsDto> CreateAsync(AddressCreateDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            var addressDetailsDto = _mapper.Map<AddressDetailsDto>(address);

            return addressDetailsDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var address = await _context.Addresses
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (address == null) throw new NotFoundExceptions($"Address with {id} not found.");

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<AddressDetailsDto> UpdateAsync(AddressUpdateDto updateAddressDto)
        {
            var id = updateAddressDto.Id;

            var address = await _context.Addresses
                .FirstOrDefaultAsync(a => a.Id == id);

            if (address == null) throw new NotFoundExceptions($"Address with {id} not found.");

            // If is enterprise address, can't update
            //if (AddressDto.IsEnterpriseAddress(address, _context.AddressAttributes))
            //    throw new BadRequestException("Address is enterprise, can\'t update. Use update-with-nip enterprise addresses.");

            _mapper.Map(updateAddressDto, address);

            _context.Addresses.Update(address);

            await _context.SaveChangesAsync();

            var addressDto = _mapper.Map<AddressDto>(address);

            var addressDetailsDto = _mapper.Map<AddressDetailsDto>(addressDto);

            return addressDetailsDto;
        }
    }

}
