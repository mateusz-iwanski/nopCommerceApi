using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.ProductPicture;

namespace nopCommerceApi.Services.Product
{
    public interface IProductPictureMappingService
    {
        Task<ProductPictureMappingDto> Create(ProductPictureMappingCreateDto ProductPictureMappingCreateDto);
        Task<bool> Delete(int id);
        Task<IEnumerable<ProductPictureMappingDto>> GetAll();
        Task<ProductPictureMappingDto> GetById(int id);
        Task<bool> Update(ProductPictureMappingUpdateDto ProductPictureMappingUpdateDto);
        Task<IEnumerable<ProductPictureMappingDto>> GetByProductId(int productId);
    }

    public class ProductPictureMappingService : BaseService, IProductPictureMappingService
    {
        private readonly NopCommerceContext _context;

        public ProductPictureMappingService(NopCommerceContext context, IMapper mapper, ILogger<ProductPictureMappingService> logger) : base(context, mapper, logger)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductPictureMappingDto>> GetAll()
        {
            var productPictures = await _context.ProductPictureMappings
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<ProductPictureMappingDto>>(productPictures);
        }

        public async Task<ProductPictureMappingDto> GetById(int id)
        {
            var productPicture = await _context.ProductPictureMappings
                .FindAsync(id);

            if (productPicture == null)
            {
                throw new NotFoundExceptions($"The product picture with id {id} was not found.");
            }

            return _mapper.Map<ProductPictureMappingDto>(productPicture);
        }

        public async Task<ProductPictureMappingDto> Create(ProductPictureMappingCreateDto ProductPictureMappingCreateDto)
        {
            var productPicture = _mapper.Map<Entities.Usable.ProductPictureMapping>(ProductPictureMappingCreateDto);

            _context.ProductPictureMappings.Add(productPicture);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductPictureMappingDto>(productPicture);
        }

        public async Task<bool> Update(ProductPictureMappingUpdateDto ProductPictureMappingUpdateDto)
        {
            var productPicture = await _context.ProductPictureMappings.FindAsync(ProductPictureMappingUpdateDto.Id);

            if (productPicture == null)
            {
                throw new NotFoundExceptions($"The product picture with id {ProductPictureMappingUpdateDto.Id} was not found.");
            }

            _mapper.Map(ProductPictureMappingUpdateDto, productPicture);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var productPicture = await _context.ProductPictureMappings.FindAsync(id);

            if (productPicture == null)
            {
                throw new NotFoundExceptions($"The product picture with id {id} was not found.");
            }

            _context.ProductPictureMappings.Remove(productPicture);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProductPictureMappingDto>> GetByProductId(int productId)
        {
            var productPictures = await _context.ProductPictureMappings
                .AsNoTracking()
                .Where(x => x.ProductId == productId).ToListAsync();

            return _mapper.Map<IEnumerable<ProductPictureMappingDto>>(productPictures);
        }
    }
}
