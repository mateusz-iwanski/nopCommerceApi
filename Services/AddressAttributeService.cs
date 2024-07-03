using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;

namespace nopCommerceApi.Services
{
    public interface IAddressAttributeService
    {
        void Create(AddressAttributeDto addressAttributeDto);
        void Delete(int id);
        IEnumerable<AddressAttributeDto> GetAll();
        AddressAttributeDto GetById(int id);
        void Update(int id, AddressAttributeDto addressAttributeDto);
    }

    public class AddressAttributeService : IAddressAttributeService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        public AddressAttributeService(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<AddressAttributeDto> GetAll()
        {
            var addressAttributes = _context.AddressAttributes.ToList();
            var addressAttributeDtos = _mapper.Map<List<AddressAttributeDto>>(addressAttributes);

            return addressAttributeDtos;
        }

        public AddressAttributeDto GetById(int id)
        {
            var addressAttribute = _context.AddressAttributes.Find(id);
            var addressAttributeDto = _mapper.Map<AddressAttributeDto>(addressAttribute);

            return addressAttributeDto;
        }

        public void Create(AddressAttributeDto addressAttributeDto)
        {
            var addressAttribute = _mapper.Map<AddressAttribute>(addressAttributeDto);
            _context.AddressAttributes.Add(addressAttribute);
            _context.SaveChanges();
        }

        public void Update(int id, AddressAttributeDto addressAttributeDto)
        {
            var addressAttribute = _context.AddressAttributes.Find(id);
            _mapper.Map(addressAttributeDto, addressAttribute);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var addressAttribute = _context.AddressAttributes.Find(id);
            _context.AddressAttributes.Remove(addressAttribute);
            _context.SaveChanges();
        }
    }
}
