using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Manufacturer;
using nopCommerceApi.Services.Category;

namespace nopCommerceApi.Services.Manufacturer
{
    public interface IManufacturerService
    {
        Task<ManufacturerDto> CreateAsync(ManufacturerCreateDto manufacturerCreateDto);
        Task<IEnumerable<ManufacturerDto>> GetAllAsync();
        Task<ManufacturerDto> UpdateAsync(ManufacturerUpdateDto manufacturerUpdateDto);
        Task<ManufacturerDto> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }

    public class ManufacturerService : BaseService, IManufacturerService
    {
        public ManufacturerService(NopCommerceContext context, IMapper mapper, ILogger<ManufacturerService> logger) : base(context, mapper, logger) { }

        // get all manufacturers asynchronously
        public async Task<IEnumerable<ManufacturerDto>> GetAllAsync()
        {
            var manufacturers = await _context.Manufacturers.ToListAsync();
            var manufacturerDtos = _mapper.Map<List<ManufacturerDto>>(manufacturers);

            return manufacturerDtos;
        }

        // get by id asynchronously
        public async Task<ManufacturerDto> GetByIdAsync(int id)
        {
            var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(c => c.Id == id);

            if (manufacturer == null) throw new NotFoundExceptions($"Manufacturer with id {id} not found");

            var manufacturerDto = _mapper.Map<ManufacturerDto>(manufacturer);

            return manufacturerDto;
        }

        // update manufacturer asynchronously
        public async Task<ManufacturerDto> UpdateAsync(ManufacturerUpdateDto manufacturerUpdateDto)
        {
            var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(c => c.Id == manufacturerUpdateDto.Id);

            manufacturerUpdateDto.CreatedOnUtc = manufacturer.CreatedOnUtc;

            _mapper.Map(manufacturerUpdateDto, manufacturer);

            await _context.SaveChangesAsync();

            var manufacturerDto = _mapper.Map<ManufacturerDto>(manufacturer);

            return manufacturerDto;
        }

        // add manufacturer asynchronously
        public async Task<ManufacturerDto> CreateAsync(ManufacturerCreateDto manufacturerCreateDto)
        {
            var manufacturer = _mapper.Map<Entities.Usable.Manufacturer>(manufacturerCreateDto);

            _context.Manufacturers.Add(manufacturer);

            await _context.SaveChangesAsync();

            var manufacturerDto = _mapper.Map<ManufacturerDto>(manufacturer);

            return manufacturerDto;
        }

        // delete manufacturer asynchronously
        public async Task<bool> DeleteAsync(int id)
        {
            var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(c => c.Id == id);

            if (manufacturer == null) throw new NotFoundExceptions($"Manufacturer with id {id} not found");

            _context.Manufacturers.Remove(manufacturer);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
