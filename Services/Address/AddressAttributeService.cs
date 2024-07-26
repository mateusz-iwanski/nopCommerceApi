using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Address;

namespace nopCommerceApi.Services
{
    public interface IAddressAttributeService
    {
        IEnumerable<AddressAttributeDto> GetAll();
    }

    public class AddressAttributeService : BaseService, IAddressAttributeService
    {

        public AddressAttributeService(
            NopCommerceContext context, IMapper mapper, ILogger<AddressAttributeService> logger
            ) : base(context, mapper, logger)
        {
        }

        public IEnumerable<AddressAttributeDto> GetAll()
        {

            var addressAttributes = _context.AddressAttributes.ToList();
            var addressAttributeDtos = _mapper.Map<List<AddressAttributeDto>>(addressAttributes);

            return addressAttributeDtos;
        }
    }
}
