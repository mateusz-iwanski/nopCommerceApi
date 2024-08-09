using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.ProductVideo;

namespace nopCommerceApi.Services.Product
{
    public interface IProductVideoService
    {
        Task<ProductVideoDto> Create(ProductVideoCreateDto productVideoCreateDto);
        Task<bool> Delete(int id);
        Task<IEnumerable<ProductVideoDto>> GetAll();
        Task<ProductVideoDto> GetById(int id);
        Task<ProductVideoDto> GetByProductId(int productId);
        Task<ProductVideoDto> GetByVideoId(int videoId);
        Task<bool> Update(ProductVideoUpdateDto productVideoUpdateDto);
    }

    public class ProductVideoService : BaseService, IProductVideoService
    {
        private readonly NopCommerceContext _context;

        public ProductVideoService(NopCommerceContext context, IMapper mapper, ILogger<ProductVideoService> logger) : base(context, mapper, logger)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductVideoDto>> GetAll()
        {
            var productVideos = await _context.ProductVideos.ToListAsync();

            var productVideosDto = _mapper.Map<IEnumerable<ProductVideoDto>>(productVideos);

            return productVideosDto;
        }

        public async Task<ProductVideoDto> GetById(int id)
        {
            var productVideo = await _context.ProductVideos.FirstOrDefaultAsync(x => x.Id == id);

            if (productVideo == null) throw new NotFoundExceptions($"Product video with id {id} not found");

            var productVideoDto = _mapper.Map<ProductVideoDto>(productVideo);

            return productVideoDto;
        }

        public async Task<ProductVideoDto> GetByVideoId(int videoId)
        {
            var productVideo = await _context.ProductVideos.FirstOrDefaultAsync(x => x.VideoId == videoId);

            if (productVideo == null) throw new NotFoundExceptions($"Product video with video id {videoId} not found");

            var productVideoDto = _mapper.Map<ProductVideoDto>(productVideo);

            return productVideoDto;
        }
        public async Task<ProductVideoDto> GetByProductId(int productId)
        {
            var productVideo = await _context.ProductVideos.FirstOrDefaultAsync(x => x.ProductId == productId);

            if (productVideo == null) throw new NotFoundExceptions($"Product video with product id {productId} not found");

            var productVideoDto = _mapper.Map<ProductVideoDto>(productVideo);

            return productVideoDto;
        }

        public async Task<ProductVideoDto> Create(ProductVideoCreateDto productVideoCreateDto)
        {
            var productVideo = _mapper.Map<Entities.Usable.ProductVideo>(productVideoCreateDto);

            _context.ProductVideos.Add(productVideo);
            await _context.SaveChangesAsync();

            var productVideoDto = _mapper.Map<ProductVideoDto>(productVideo);

            return productVideoDto;
        }

        public async Task<bool> Update(ProductVideoUpdateDto productVideoUpdateDto)
        {
            var id = productVideoUpdateDto.Id;

            var productVideo = await _context.ProductVideos.FirstOrDefaultAsync(x => x.Id == id);

            if (productVideo == null) throw new NotFoundExceptions($"Product video with id {id} not found");

            productVideo = _mapper.Map(productVideoUpdateDto, productVideo);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var productVideo = await _context.ProductVideos.FirstOrDefaultAsync(x => x.Id == id);

            if (productVideo == null) throw new NotFoundExceptions($"Product video with id {id} not found");

            _context.ProductVideos.Remove(productVideo);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
