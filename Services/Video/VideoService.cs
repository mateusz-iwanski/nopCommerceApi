using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Video;
using nopCommerceApi.Services.Category;

namespace nopCommerceApi.Services.Video
{
    public interface IVideoService
    {
        Task<VideoDto> Create(VideoCreateDto createVideoDto);
        Task<bool> Delete(int id);
        Task<IEnumerable<VideoDto>> GetAll();
        Task<VideoDto> GetById(int id);
        Task<VideoDto> GetByUrl(string url);
        Task<VideoDto> Update(VideoUpdateDto updateVideoDto);
    }

    public class VideoService : BaseService, IVideoService
    {
        public VideoService(NopCommerceContext context, IMapper mapper, ILogger<CategoryService> logger) : base(context, mapper, logger)
        {
        }

        // get all
        public async Task<IEnumerable<VideoDto>> GetAll()
        {
            var videos = await _context.Videos
                .AsNoTracking()
                .ToListAsync();
            var videoDtos = _mapper.Map<List<VideoDto>>(videos);

            return videoDtos;
        }

        // get by id
        public async Task<VideoDto> GetById(int id)
        {
            var video = await _context.Videos
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id == id);

            if (video == null) throw new NotFoundExceptions($"Video with id {id} not found");

            var videoDto = _mapper.Map<VideoDto>(video);

            return videoDto;
        }

        //get by url
        public async Task<VideoDto> GetByUrl(string url)
        {
            var video = await _context.Videos
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.VideoUrl == url);

            if (video == null) throw new NotFoundExceptions($"Video with url {url} not found");

            var videoDto = _mapper.Map<VideoDto>(video);

            return videoDto;
        }

        // update
        public async Task<VideoDto> Update(VideoUpdateDto updateVideoDto)
        {
            var video = await _context.Videos.FirstOrDefaultAsync(v => v.Id == updateVideoDto.Id);

            _mapper.Map(updateVideoDto, video);

            await _context.SaveChangesAsync();

            var videoDto = _mapper.Map<VideoDto>(video);

            return videoDto;
        }

        // create
        public async Task<VideoDto> Create(VideoCreateDto createVideoDto)
        {
            var video = _mapper.Map<Entities.Usable.Video>(createVideoDto);

            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            var videoDto = _mapper.Map<VideoDto>(video);

            return videoDto;
        }

        // delete
        public async Task<bool> Delete(int id)
        {
            var video = await _context.Videos.FirstOrDefaultAsync(v => v.Id == id);

            if (video == null) throw new NotFoundExceptions($"Video with id {id} not found");

            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
