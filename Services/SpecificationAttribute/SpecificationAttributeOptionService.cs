using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models.SpecificationAttribute;
using nopCommerceApi.Models.SpecificationAttributeOption;

namespace nopCommerceApi.Services.SpecificationAttribute
{
    public class SpecificationAttributeOptionService : BaseService
    {
        private readonly NopCommerceContext _context;

        public SpecificationAttributeOptionService(NopCommerceContext context, IMapper mapper, ILogger<SpecificationAttributeOptionService> logger) : base(context, mapper, logger)
        {
            _context = context;
        }

        // get all specification attribute options
        public async Task<List<SpecificationAttributeOptionDto>> GetAllAsync()
        {
            var specificationAttributeOptions = await _context.SpecificationAttributeOptions.ToListAsync();
            return _mapper.Map<List<SpecificationAttributeOptionDto>>(specificationAttributeOptions);
        }

        // get specification attribute option by id
        public async Task<SpecificationAttributeOptionDto> GetByIdAsync(int id)
        {
            var specificationAttributeOption = await _context.SpecificationAttributeOptions.FindAsync(id);

            if (specificationAttributeOption == null)
            {
                throw new KeyNotFoundException("The specification attribute option not found.");
            }

            return _mapper.Map<SpecificationAttributeOptionDto>(specificationAttributeOption);
        }

        // create a specification attribute option
        public async Task<SpecificationAttributeOptionDto> CreateAsync(SpecificationAttributeOptionCreateDto specificationAttributeOptionCreateDto)
        {
            var specificationAttributeOption = _mapper.Map<SpecificationAttributeOption>(specificationAttributeOptionCreateDto);

            _context.SpecificationAttributeOptions.Add(specificationAttributeOption);
            await _context.SaveChangesAsync();

            return _mapper.Map<SpecificationAttributeOptionDto>(specificationAttributeOption);
        }

        // update a specification attribute option
        public async Task<SpecificationAttributeOptionDto> UpdateAsync(SpecificationAttributeOptionUpdateDto specificationAttributeOptionUpdateDto)
        {
            var id = specificationAttributeOptionUpdateDto.Id;

            var specificationAttributeOption = await _context.SpecificationAttributeOptions.FindAsync(id);

            if (specificationAttributeOption == null)
            {
                throw new KeyNotFoundException("The specification attribute option not found.");
            }

            _mapper.Map(specificationAttributeOptionUpdateDto, specificationAttributeOption);
            await _context.SaveChangesAsync();

            return _mapper.Map<SpecificationAttributeOptionDto>(specificationAttributeOption);
        }
        
        // delete a specification attribute option
        public async Task DeleteAsync(int id)
        {
            var specificationAttributeOption = await _context.SpecificationAttributeOptions.FindAsync(id);

            if (specificationAttributeOption == null)
            {
                throw new KeyNotFoundException("The specification attribute option not found.");
            }

            _context.SpecificationAttributeOptions.Remove(specificationAttributeOption);
            await _context.SaveChangesAsync();
        }

        // get all specification attribute options by specification attribute id
        public async Task<List<SpecificationAttributeOptionDto>> GetAllBySpecificationAttributeIdAsync(int specificationAttributeId)
        {
            var specificationAttributeOptions = await _context.SpecificationAttributeOptions.Where(sao => sao.SpecificationAttributeId == specificationAttributeId).ToListAsync();
            return _mapper.Map<List<SpecificationAttributeOptionDto>>(specificationAttributeOptions);
        }

    }
}
