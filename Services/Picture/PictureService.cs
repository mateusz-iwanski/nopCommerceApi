using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Picture;

namespace nopCommerceApi.Services.Picture
{
    public interface IPictureService
    {
        Task<PictureDto> CreateAsync(PictureCreateDto pictureCreateDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PictureDto>> GetAllAsync();
        Task<PictureDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(PictureUpdateDto pictureUpdateDto);
        Task<string> ProperNameForPictureFileAsync(int pictureId);
    }

    public class PictureService : BaseService, IPictureService
    {
        private readonly NopCommerceContext _context;

        public PictureService(NopCommerceContext context, IMapper mapper, ILogger<PictureService> logger) : base(context, mapper, logger)
        {
            _context = context;
        }

        public async Task<IEnumerable<PictureDto>> GetAllAsync()
        {
            var pictures = await _context.Pictures.ToListAsync();

            return _mapper.Map<IEnumerable<PictureDto>>(pictures);
        }

        public async Task<PictureDto> GetByIdAsync(int id)
        {
            var picture = await _context.Pictures.FindAsync(id);
            if (picture == null)
            {
                throw new NotFoundExceptions($"The picture with id {id} was not found.");
            }

            return _mapper.Map<PictureDto>(picture);
        }

        public async Task<PictureDto> CreateAsync(PictureCreateDto pictureCreateDto)
        {
            var picture = _mapper.Map<Entities.Usable.Picture>(pictureCreateDto);

            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();

            return _mapper.Map<PictureDto>(picture);
        }

        public async Task<bool> UpdateAsync(PictureUpdateDto pictureUpdateDto)
        {
            var picture = await _context.Pictures.FindAsync(pictureUpdateDto.Id);

            _mapper.Map(pictureUpdateDto, picture);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var picture = await _context.Pictures.FindAsync(id);
            if (picture == null)
            {
                throw new NotFoundExceptions($"The picture with id {id} was not found.");
            }

            _context.Pictures.Remove(picture);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<string> ProperNameForPictureFileAsync(int pictureId)
        {
            var picture = await _context.Pictures.FindAsync(pictureId);
            if (picture == null)
            {
                throw new NotFoundExceptions($"The picture with id {pictureId} was not found.");
            }
            return $"{picture.Id.ToString().PadLeft(7, '0')}_{picture.SeoFilename}.{picture.MimeType.Split('/')[1]}";
        }

    }
}
