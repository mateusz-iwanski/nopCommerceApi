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
        Address CreateWithNip(CreateAddressDto newAdressDto);
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
        /// Create a new address with NIP as a additional field
        /// </summary>
        public Address CreateWithNip(CreateAddressDto newAdressDto)
        {
            var address = _mapper.Map<Address>(newAdressDto);

            address.CreatedOnUtc = DateTime.Now;

            _context.Addresses.Add(address);
            _context.SaveChanges();

            return address;
        }

    }

}
