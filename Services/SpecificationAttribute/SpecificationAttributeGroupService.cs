using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.SpecyficationAttributeGroup;

namespace nopCommerceApi.Services.SpecificationAttribute
{
    public interface ISpecificationAttributeGroupService
    {
        SpecificationAttributeGroupDto Create(SpecificationAttributeGroupCreateDto specificationAttributeGroupCreateDto);
        bool Delete(int id);
        IEnumerable<SpecificationAttributeGroupDto> GetAll();
        SpecificationAttributeGroupDto GetById(int id);
        SpecificationAttributeGroupDto GetByName(string name);
        bool Update(int id, SpecificationAttributeGroupUpdateDto specificationAttributeGroupUpdateDto);
    }

    public class SpecificationAttributeGroupService : BaseService, ISpecificationAttributeGroupService
    {
        private readonly NopCommerceContext _context;

        public SpecificationAttributeGroupService(NopCommerceContext context, IMapper mapper, ILogger<SpecificationAttributeGroupService> logger) : base(context, mapper, logger)
        {
            _context = context;
        }

        public IEnumerable<SpecificationAttributeGroupDto> GetAll()
        {
            var specificationAttributeGroups = _context.SpecificationAttributeGroups.ToList();

            return _mapper.Map<IEnumerable<SpecificationAttributeGroupDto>>(specificationAttributeGroups);
        }

        public SpecificationAttributeGroupDto GetById(int id)
        {
            var specificationAttributeGroup = _context.SpecificationAttributeGroups.Find(id);
            if (specificationAttributeGroup == null)
            {
                throw new NotFoundExceptions($"The specification attribute group with id {id} was not found.");
            }

            return _mapper.Map<SpecificationAttributeGroupDto>(specificationAttributeGroup);
        }

        public SpecificationAttributeGroupDto Create(SpecificationAttributeGroupCreateDto specificationAttributeGroupCreateDto)
        {
            var specificationAttributeGroup = _mapper.Map<Entities.Usable.SpecificationAttributeGroup>(specificationAttributeGroupCreateDto);

            _context.SpecificationAttributeGroups.Add(specificationAttributeGroup);
            _context.SaveChanges();

            return _mapper.Map<SpecificationAttributeGroupDto>(specificationAttributeGroup);
        }

        public bool Update(int id, SpecificationAttributeGroupUpdateDto specificationAttributeGroupUpdateDto)
        {
            var specificationAttributeGroup = _context.SpecificationAttributeGroups.Find(id);
            specificationAttributeGroupUpdateDto.Id = id;

            if (specificationAttributeGroup == null)
            {
                throw new NotFoundExceptions($"The specification attribute group with id {id} was not found.");
            }

            _mapper.Map(specificationAttributeGroupUpdateDto, specificationAttributeGroup);
            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var specificationAttributeGroup = _context.SpecificationAttributeGroups.Find(id);
            if (specificationAttributeGroup == null)
            {
                throw new NotFoundExceptions($"The specification attribute group with id {id} was not found.");
            }

            _context.SpecificationAttributeGroups.Remove(specificationAttributeGroup);
            _context.SaveChanges();

            return true;
        }

        public SpecificationAttributeGroupDto GetByName(string name)
        {
            var specificationAttributeGroup = _context.SpecificationAttributeGroups.FirstOrDefault(x => x.Name == name);
            if (specificationAttributeGroup == null)
            {
                throw new NotFoundExceptions($"The specification attribute group with name {name} was not found.");
            }

            return _mapper.Map<SpecificationAttributeGroupDto>(specificationAttributeGroup);
        }


    }
}
