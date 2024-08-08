using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Picture;

namespace nopCommerceApi.Services.Picture
{
    public interface IPictureService
    {
        PictureDto Create(PictureCreateDto pictureCreateDto);
        bool Delete(int id);
        IEnumerable<PictureDto> GetAll();
        PictureDto GetById(int id);
        bool Update(int id, PictureUpdateDto pictureUpdateDto);
        string ProperNameForPictureFile(int pictureId);
    }

    public class PictureService : BaseService, IPictureService
    {
        private readonly NopCommerceContext _context;

        public PictureService(NopCommerceContext context, IMapper mapper, ILogger<PictureService> logger) : base(context, mapper, logger)
        {
            _context = context;
        }

        public IEnumerable<PictureDto> GetAll()
        {
            var pictures = _context.Pictures.ToList();

            return _mapper.Map<IEnumerable<PictureDto>>(pictures);
        }

        public PictureDto GetById(int id)
        {
            var picture = _context.Pictures.Find(id);
            if (picture == null)
            {
                throw new NotFoundExceptions($"The picture with id {id} was not found.");
            }

            return _mapper.Map<PictureDto>(picture);
        }

        public PictureDto Create(PictureCreateDto pictureCreateDto)
        {
            var picture = _mapper.Map<Entities.Usable.Picture>(pictureCreateDto);

            _context.Pictures.Add(picture);
            _context.SaveChanges();

            return _mapper.Map<PictureDto>(picture);
        }

        public bool Update(int id, PictureUpdateDto pictureUpdateDto)
        {
            var picture = _context.Pictures.Find(id);
            pictureUpdateDto.Id = id;

            if (picture == null)
            {
                throw new NotFoundExceptions($"The picture with id {id} was not found.");
            }

            _mapper.Map(pictureUpdateDto, picture);
            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var picture = _context.Pictures.Find(id);
            if (picture == null)
            {
                throw new NotFoundExceptions($"The picture with id {id} was not found.");
            }

            _context.Pictures.Remove(picture);
            _context.SaveChanges();

            return true;
        }

        public string ProperNameForPictureFile(int pictureId)
        {
            var picture = _context.Pictures.Find(pictureId);
            if (picture == null)
            {
                throw new NotFoundExceptions($"The picture with id {pictureId} was not found.");
            }
            return $"{picture.Id.ToString().PadLeft(7, '0')}_{picture.SeoFilename}.{picture.MimeType.Split('/')[1]}";
        }

    }
}
