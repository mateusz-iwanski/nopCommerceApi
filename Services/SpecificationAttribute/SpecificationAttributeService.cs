using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.SpecyficationAttribute;

namespace nopCommerceApi.Services.SpecificationAttribute
{
    public interface ISpecificationAttributeService
    {
        SpecificationAttributeDto Create(SpecificationAttributeCreateDto specificationAttributeCreateDto);
        IEnumerable<SpecificationAttributeDto> GetAll();
        SpecificationAttributeDto GetById(int id);
        SpecificationAttributeDto GetByName(string name);
        bool Update(int id, SpecificationAttributeUpdateDto specificationAttributeUpdateDto);
    }

    public class SpecificationAttributeService : BaseService, ISpecificationAttributeService
    {
        private readonly NopCommerceContext _context;

        public SpecificationAttributeService(NopCommerceContext context, IMapper mapper, ILogger<SpecificationAttributeService> logger) : base(context, mapper, logger)
        {
            _context = context;
        }

        public IEnumerable<SpecificationAttributeDto> GetAll()
        {
            var specificationAttributes = _context.SpecificationAttributes.ToList();

            return _mapper.Map<IEnumerable<SpecificationAttributeDto>>(specificationAttributes);
        }

        public SpecificationAttributeDto GetById(int id)
        {
            var specificationAttribute = _context.SpecificationAttributes.Find(id);
            if (specificationAttribute == null)
            {
                throw new NotFoundExceptions($"The specification attribute with id {id} was not found.");
            }

            return _mapper.Map<SpecificationAttributeDto>(specificationAttribute);
        }

        public SpecificationAttributeDto Create(SpecificationAttributeCreateDto specificationAttributeCreateDto)
        {
            var specificationAttribute = _mapper.Map<Entities.Usable.SpecificationAttribute>(specificationAttributeCreateDto);

            _context.SpecificationAttributes.Add(specificationAttribute);
            _context.SaveChanges();

            return _mapper.Map<SpecificationAttributeDto>(specificationAttribute);
        }

        public bool Update(int id, SpecificationAttributeUpdateDto specificationAttributeUpdateDto)
        {
            var specificationAttribute = _context.SpecificationAttributes.Find(id);
            specificationAttributeUpdateDto.Id = id;

            if (specificationAttribute == null)
            {
                throw new NotFoundExceptions($"The specification attribute with id {id} was not found.");
            }

            _mapper.Map(specificationAttributeUpdateDto, specificationAttribute);
            _context.SaveChanges();

            return true;
        }

        public SpecificationAttributeDto GetByName(string name)
        {
            var specificationAttribute = _context.SpecificationAttributes.FirstOrDefault(sa => sa.Name == name);
            if (specificationAttribute == null)
            {
                throw new NotFoundExceptions($"The specification attribute with name {name} was not found.");
            }

            return _mapper.Map<SpecificationAttributeDto>(specificationAttribute);
        }

    }
}
