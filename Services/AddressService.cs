using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.Services
{
    public interface IAddressService
    {
        IEnumerable<AddressDto> GetAll();
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
        public IEnumerable<AddressDto> GetAll()
        {
            var addresses = _context.Addresses
               .Include(a => a.Country)
               .Include(a => a.StateProvince).ThenInclude(c => c.Country)
               .ToList();
            var addressDtos = _mapper.Map<List<AddressDto>>(addresses);

            return addressDtos;
        }
    }

}
