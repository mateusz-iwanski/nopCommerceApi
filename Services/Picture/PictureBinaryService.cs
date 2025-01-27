using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Picture;

namespace nopCommerceApi.Services.Picture
{
    public interface IPictureBinaryService
    {
        Task<PictureBinaryDto> CreateAsync(PictureBinaryCreateDto pictureBinaryCreateDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PictureBinaryDto>> GetAllAsync();
        Task<PictureBinaryDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(PictureBinaryUpdateDto pictureBinaryUpdateDto);
    }

    public class PictureBinaryService : BaseService, IPictureBinaryService
    {
        private readonly NopCommerceContext _context;

        public PictureBinaryService(NopCommerceContext context, IMapper mapper, ILogger<PictureBinaryService> logger) : base(context, mapper, logger)
        {
            _context = context;
        }

        public async Task<IEnumerable<PictureBinaryDto>> GetAllAsync()
        {
            var pictureBinaries = await _context.PictureBinaries.ToListAsync();
            return _mapper.Map<IEnumerable<PictureBinaryDto>>(pictureBinaries);
        }

        public async Task<PictureBinaryDto> GetByIdAsync(int id)
        {
            var pictureBinary = await _context.PictureBinaries.FindAsync(id);
            if (pictureBinary == null)
            {
                throw new NotFoundExceptions($"The picture binary with id {id} was not found.");
            }

            return _mapper.Map<PictureBinaryDto>(pictureBinary);
        }

        public async Task<PictureBinaryDto> CreateAsync(PictureBinaryCreateDto pictureBinaryCreateDto)
        {
            var pictureBinary = _mapper.Map<Entities.Usable.PictureBinary>(pictureBinaryCreateDto);

            _context.PictureBinaries.Add(pictureBinary);
            await _context.SaveChangesAsync();

            return _mapper.Map<PictureBinaryDto>(pictureBinary);
        }

        public async Task<bool> UpdateAsync(PictureBinaryUpdateDto pictureBinaryUpdateDto)
        {
            var pictureBinary = await _context.PictureBinaries.FindAsync(pictureBinaryUpdateDto.Id);
            if (pictureBinary == null)
            {
                throw new NotFoundExceptions($"The picture binary with id {pictureBinaryUpdateDto.Id} was not found.");
            }

            _mapper.Map(pictureBinaryUpdateDto, pictureBinary);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pictureBinary = await _context.PictureBinaries.FindAsync(id);
            if (pictureBinary == null)
            {
                throw new NotFoundExceptions($"The picture binary with id {id} was not found.");
            }

            _context.PictureBinaries.Remove(pictureBinary);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
