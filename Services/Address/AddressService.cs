﻿using AutoMapper;
using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Validations;
using System.Text.Json;

namespace nopCommerceApi.Services
{
    public interface IAddressService
    {
        IEnumerable<AddressDetailsDto> GetAll();
        Address CreateWithNip(AddressCreatePolishEnterpriseDto newAdressDto);
        bool UpdateWithNip(int id, AddressUpdatePolishEnterpriseDto updateAddressDto);
        Address Create(AddressCreateDto addressDto);
        bool Delete(int id);
        bool Update(int id, AddressUpdateDto updateAddressDto);
        AddressDetailsDto GetById(int id);
    }

    public class AddressService : BaseService, IAddressService
    {
        public AddressService(NopCommerceContext context, IMapper mapper, ILogger<AddressAttributeService> logger
            ) : base(context, mapper, logger)
        {
        }

        public IEnumerable<AddressDetailsDto> GetAll()
        {
            var detailsAddresses = _context.Addresses
               .Include(a => a.Country)
               .Include(a => a.StateProvince).ThenInclude(c => c.Country)
               .ToList();
            var addressDtos = _mapper.Map<List<AddressDetailsDto>>(detailsAddresses);

            return addressDtos;
        }

        public AddressDetailsDto GetById(int id) {             
            var address = _context.Addresses
                .Include(a => a.Country)
                .Include(a => a.StateProvince).ThenInclude(c => c.Country)
                .FirstOrDefault(a => a.Id == id);
            
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
        public Address CreateWithNip(AddressCreatePolishEnterpriseDto newAdressDto)
        {
            var address = _mapper.Map<Address>(newAdressDto);
            
            var addressAttribute = _context.AddressAttributes
                .FirstOrDefault(c => c.Name == "NIP" && c.AttributeControlTypeId == 4);

            // If the additional attribute does not exist, create it
            // NopCommerce default doesn't have NIP field in address

            // TODO: Add AddressAttribute to the seeder
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
        /// </summary>
        /// <remarks>
        /// Nip has to be always set in the request body.
        /// In function check if the nip already exists in the database excluding the updated object from the check.
        /// If property not set in the request body, it will not be updated.
        /// Cant set empty string on: Company, City, Email, Address1, PhoneNumber. If you don't want to update, just remove from body.
        /// </remarks>
        public bool UpdateWithNip(int id, AddressUpdatePolishEnterpriseDto updateAddressDto)
        {
            var address = _context.Addresses
                .Include(a => a.Country)
                .Include(a => a.StateProvince)
                .FirstOrDefault(a => a.Id == id);

            var addressAttribute = _context.AddressAttributes
                .FirstOrDefault(c => c.Name == "NIP" && c.AttributeControlTypeId == 4);

            if (address == null) throw new NotFoundExceptions($"Address with {id} not found.");

            // Only update this fields which are not null

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
            // but exclude the updated object from the check
            if (!string.IsNullOrEmpty(updateAddressDto.Nip))
            {
                var addresses = _context.Addresses.ToList();

                var filteredAddresses = addresses.Where(addr => AddressDto.GetValueFromCustomAttribute(addr.CustomAttributes) == updateAddressDto.Nip).ToList();
                // Exclude the updated object from the check
                filteredAddresses = filteredAddresses.Where(addr => addr.Id != updateAddressDto.Id).ToList();

                address.CustomAttributes = filteredAddresses.Count == 0 ?
                    $"<Attributes><AddressAttribute ID=\"{addressAttribute.Id}\"><AddressAttributeValue><Value>{updateAddressDto.Nip}</Value></AddressAttributeValue></AddressAttribute></Attributes>"
                    : throw new BadRequestException("NIP already exists in the database, it should be unique.");
            }

            _context.SaveChanges();

            return true;
        }

        public Address Create(AddressCreateDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            _context.Addresses.Add(address);
            _context.SaveChanges();

            return address;
        }

        public bool Delete(int id)
        {
            var address = _context.Addresses.FirstOrDefault(a => a.Id == id);

            if (address == null) throw new NotFoundExceptions($"Address with {id} not found.");

            _context.Addresses.Remove(address);
            _context.SaveChanges();

            return true;
        }

        public bool Update(int id, AddressUpdateDto updateAddressDto)
        {
            var address = _context.Addresses.FirstOrDefault(a => a.Id == id);

            if (address == null) throw new NotFoundExceptions($"Address with {id} not found.");

            // If is enterprise address, can't update
            if (AddressDto.IsEnterpriseAddress(address, _context.AddressAttributes))
                throw new BadRequestException("Address is enterprise, can\'t update. Use update-with-nip enterprise addresses.");


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
            address.CountryId = updateAddressDto.CountryId;

            _context.SaveChanges();

            return true;
        }
    }

}
