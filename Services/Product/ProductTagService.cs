using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.ProductTag;

namespace nopCommerceApi.Services.Product
{
    public interface IProductTagService
    {
        Task<ProductTag> CreateAsync(ProductTagCreateDto productTagDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ProductTagDto>> GetAllAsync();
        Task<IEnumerable<ProductTagDetailsDto>> GetAllDetailsAsync();
        Task<ProductTagDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductTagDto>> GetByTagAsync(string tagName);
        Task<bool> UpdateAsync([FromBody] ProductTagUpdateDto productTagDto);
    }

    public class ProductTagService : BaseService, IProductTagService
    {
        public ProductTagService(NopCommerceContext context, IMapper mapper, ILogger<ProductTagService> logger)
            : base(context, mapper, logger) { }

        public async Task<IEnumerable<ProductTagDto>> GetAllAsync()
        {
            var productTags = await _context.ProductTags
                .AsNoTracking()
                .ToListAsync();

            var productTagDtos = _mapper.Map<List<ProductTagDto>>(productTags);

            return productTagDtos;
        }

        public async Task<IEnumerable<ProductTagDetailsDto>> GetAllDetailsAsync()
        {
            var productTags = await _context.ProductTags
                .AsNoTracking()
                .ToListAsync();

            var productTagDtos = _mapper.Map<List<ProductTagDetailsDto>>(productTags);

            return productTagDtos;
        }

        public async Task<IEnumerable<ProductTagDto>> GetByTagAsync(string tagName)
        {
            var productTags = await _context.ProductTags
                .AsNoTracking()
                .Where(p => p.Name.Contains(tagName)).ToListAsync();

            var productTagDtos = _mapper.Map<List<ProductTagDto>>(productTags);

            return productTagDtos;
        }

        public async Task<ProductTagDto> GetByIdAsync(int id)
        {
            var productTag = await _context.ProductTags
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            var productTagDto = productTag != null ? _mapper.Map<ProductTagDto>(productTag) : throw new NotFoundExceptions($"ProductTag with id {id} not found");

            return productTagDto;
        }

        public async Task<ProductTag> CreateAsync(ProductTagCreateDto productTagDto)
        {
            var productTag = _mapper.Map<ProductTag>(productTagDto);

            _context.ProductTags.Add(productTag);
            await _context.SaveChangesAsync();

            return productTag;
        }

        public async Task<bool> UpdateAsync([FromBody] ProductTagUpdateDto productTagDto)
        {
            var productTag = await _context.ProductTags.FirstOrDefaultAsync(p => p.Id == productTagDto.Id);

            productTag.Name = productTagDto.Name;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var productTag = await _context.ProductTags.FirstOrDefaultAsync(p => p.Id == id);

            if (productTag == null) throw new NotFoundExceptions($"Product Tag with {id} not found.");

            _context.ProductTags.Remove(productTag);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
