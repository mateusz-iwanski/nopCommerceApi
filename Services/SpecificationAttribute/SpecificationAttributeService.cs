using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.SpecyficationAttribute;

namespace nopCommerceApi.Services.SpecificationAttribute
{
    public interface ISpecificationAttributeService
    {
        Task<SpecificationAttributeDto> CreateAsync(SpecificationAttributeCreateDto specificationAttributeCreateDto);
        Task<IEnumerable<SpecificationAttributeDto>> GetAllAsync();
        Task<SpecificationAttributeDto> GetByIdAsync(int id);
        Task<SpecificationAttributeDto> GetByNameAsync(string name);
        Task<bool> UpdateAsync(SpecificationAttributeUpdateDto specificationAttributeUpdateDto);
        Task<bool> DeleteAsync(int id);
    }

    public class SpecificationAttributeService : BaseService, ISpecificationAttributeService
    {
        private readonly NopCommerceContext _context;

        public SpecificationAttributeService(NopCommerceContext context, IMapper mapper, ILogger<SpecificationAttributeService> logger) : base(context, mapper, logger)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpecificationAttributeDto>> GetAllAsync()
        {
            var specificationAttributes = await _context.SpecificationAttributes.ToListAsync();

            return _mapper.Map<IEnumerable<SpecificationAttributeDto>>(specificationAttributes);
        }

        public async Task<SpecificationAttributeDto> GetByIdAsync(int id)
        {
            var specificationAttribute = await _context.SpecificationAttributes.FindAsync(id);
            if (specificationAttribute == null)
            {
                throw new NotFoundExceptions($"The specification attribute with id {id} was not found.");
            }

            return _mapper.Map<SpecificationAttributeDto>(specificationAttribute);
        }

        public async Task<SpecificationAttributeDto> CreateAsync(SpecificationAttributeCreateDto specificationAttributeCreateDto)
        {
            var specificationAttribute = _mapper.Map<Entities.Usable.SpecificationAttribute>(specificationAttributeCreateDto);

            _context.SpecificationAttributes.Add(specificationAttribute);
            await _context.SaveChangesAsync();

            return _mapper.Map<SpecificationAttributeDto>(specificationAttribute);
        }

        public async Task<bool> UpdateAsync(SpecificationAttributeUpdateDto specificationAttributeUpdateDto)
        {
            var specificationAttribute = await _context.SpecificationAttributes.FindAsync(specificationAttributeUpdateDto.Id);
            specificationAttributeUpdateDto.Id = specificationAttributeUpdateDto.Id;

            if (specificationAttribute == null)
            {
                throw new NotFoundExceptions($"The specification attribute with id {specificationAttributeUpdateDto.Id} was not found.");
            }

            _mapper.Map(specificationAttributeUpdateDto, specificationAttribute);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<SpecificationAttributeDto> GetByNameAsync(string name)
        {
            var specificationAttribute = await _context.SpecificationAttributes.FirstOrDefaultAsync(sa => sa.Name == name);
            if (specificationAttribute == null)
            {
                throw new NotFoundExceptions($"The specification attribute with name {name} was not found.");
            }

            return _mapper.Map<SpecificationAttributeDto>(specificationAttribute);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var specificationAttribute = await _context.SpecificationAttributes.FindAsync(id);
            if (specificationAttribute == null)
            {
                throw new NotFoundExceptions($"The specification attribute with id {id} was not found.");
            }

            _context.SpecificationAttributes.Remove(specificationAttribute);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
