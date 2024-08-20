using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.AddressAttribute;

namespace nopCommerceApi.Services
{
    public interface IAddressAttributeService
    {
        Task<IEnumerable<AddressAttributeDto>> GetAllAsync();
    }

    public class AddressAttributeService : BaseService, IAddressAttributeService
    {

        public AddressAttributeService(
            NopCommerceContext context, IMapper mapper, ILogger<AddressAttributeService> logger
            ) : base(context, mapper, logger)
        {
        }

        public async Task<IEnumerable<AddressAttributeDto>> GetAllAsync()
        {
            var addressAttributes = await _context.AddressAttributes.ToListAsync();
            var addressAttributeDtos = _mapper.Map<List<AddressAttributeDto>>(addressAttributes);

            return addressAttributeDtos;
        }
    }
}
