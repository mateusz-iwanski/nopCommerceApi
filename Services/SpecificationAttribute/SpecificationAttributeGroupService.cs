using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.SpecyficationAttributeGroup;

namespace nopCommerceApi.Services.SpecificationAttribute
{
    public interface ISpecificationAttributeGroupService
    {
        Task<SpecificationAttributeGroupDto> CreateAsync(SpecificationAttributeGroupCreateDto specificationAttributeGroupCreateDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<SpecificationAttributeGroupDto>> GetAllAsync();
        Task<SpecificationAttributeGroupDto> GetByIdAsync(int id);
        Task<SpecificationAttributeGroupDto> GetByNameAsync(string name);
        Task<bool> UpdateAsync(SpecificationAttributeGroupUpdateDto specificationAttributeGroupUpdateDto);
    }

    public class SpecificationAttributeGroupService : BaseService, ISpecificationAttributeGroupService
    {
        private readonly NopCommerceContext _context;

        public SpecificationAttributeGroupService(NopCommerceContext context, IMapper mapper, ILogger<ISpecificationAttributeGroupService> logger) : base(context, mapper, logger)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpecificationAttributeGroupDto>> GetAllAsync()
        {
            var specificationAttributeGroups = await _context.SpecificationAttributeGroups.ToListAsync();

            return _mapper.Map<IEnumerable<SpecificationAttributeGroupDto>>(specificationAttributeGroups);
        }

        public async Task<SpecificationAttributeGroupDto> GetByIdAsync(int id)
        {
            var specificationAttributeGroup = await _context.SpecificationAttributeGroups.FindAsync(id);
            if (specificationAttributeGroup == null)
            {
                throw new NotFoundExceptions($"The specification attribute group with id {id} was not found.");
            }

            return _mapper.Map<SpecificationAttributeGroupDto>(specificationAttributeGroup);
        }

        public async Task<SpecificationAttributeGroupDto> CreateAsync(SpecificationAttributeGroupCreateDto specificationAttributeGroupCreateDto)
        {
            var specificationAttributeGroup = _mapper.Map<Entities.Usable.SpecificationAttributeGroup>(specificationAttributeGroupCreateDto);

            _context.SpecificationAttributeGroups.Add(specificationAttributeGroup);
            await _context.SaveChangesAsync();

            return _mapper.Map<SpecificationAttributeGroupDto>(specificationAttributeGroup);
        }

        public async Task<bool> UpdateAsync(SpecificationAttributeGroupUpdateDto specificationAttributeGroupUpdateDto)
        {
            var specificationAttributeGroup = await _context.SpecificationAttributeGroups.FindAsync(specificationAttributeGroupUpdateDto.Id);

            if (specificationAttributeGroup == null)
            {
                throw new NotFoundExceptions($"The specification attribute group with id {specificationAttributeGroupUpdateDto.Id} was not found.");
            }

            _mapper.Map(specificationAttributeGroupUpdateDto, specificationAttributeGroup);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var specificationAttributeGroup = await _context.SpecificationAttributeGroups.FindAsync(id);
            if (specificationAttributeGroup == null)
            {
                throw new NotFoundExceptions($"The specification attribute group with id {id} was not found.");
            }

            _context.SpecificationAttributeGroups.Remove(specificationAttributeGroup);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<SpecificationAttributeGroupDto> GetByNameAsync(string name)
        {
            var specificationAttributeGroup = await _context.SpecificationAttributeGroups.FirstOrDefaultAsync(x => x.Name == name);
            if (specificationAttributeGroup == null)
            {
                throw new NotFoundExceptions($"The specification attribute group with name {name} was not found.");
            }

            return _mapper.Map<SpecificationAttributeGroupDto>(specificationAttributeGroup);
        }
    }
}
