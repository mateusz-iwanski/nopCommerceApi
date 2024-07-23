using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Services.Product
{
    public interface IProductTagService
    {
        ProductTag Create(ProductTagCreateDto productTagDto);
        bool? Delete(int id);
        IEnumerable<ProductTagDto> GetAll();
        IEnumerable<ProductTagDetailsDto> GetAllDteils();
        ProductTagDto GetById(int id);
        IEnumerable<ProductTagDto> GetByTag(string tagName);
        bool? Update(int id, [FromBody] ProductTagUpdateDto productTagDto);
    }

    public class ProductTagService : BaseService, IProductTagService
    {
        public ProductTagService(NopCommerceContext context, IMapper mapper, ILogger<ProductTagService> logger)
            : base(context, mapper, logger) { }

        public IEnumerable<ProductTagDto> GetAll()
        {
            var productTags = _context.ProductTags.ToList();
            var productTagDtos = _mapper.Map<List<ProductTagDto>>(productTags);

            return productTagDtos;
        }

        public IEnumerable<ProductTagDetailsDto> GetAllDteils()
        {
            var productTags = _context.ProductTags.ToList();
            var productTagDtos = _mapper.Map<List<ProductTagDetailsDto>>(productTags);

            return productTagDtos;
        }

        public IEnumerable<ProductTagDto> GetByTag(string tagName)
        {
            var productTags = _context.ProductTags.Where(p => p.Name.Contains(tagName)).ToList();
            var productTagDtos = _mapper.Map<List<ProductTagDto>>(productTags);

            return productTagDtos;
        }

        public ProductTagDto GetById(int id)
        {
            var productTag = _context.ProductTags.FirstOrDefault(p => p.Id == id);

            var productTagDto = productTag != null ? _mapper.Map<ProductTagDto>(productTag) : throw new NotFoundExceptions($"ProductTag with id {id} not found");

            return productTagDto;
        }

        public ProductTag Create(ProductTagCreateDto productTagDto)
        {
            var productTag = _mapper.Map<ProductTag>(productTagDto);

            _context.ProductTags.Add(productTag);
            _context.SaveChanges();

            return productTag;
        }

        public bool? Update(int id, [FromBody] ProductTagUpdateDto productTagDto)
        {
            var productTag = _context.ProductTags.FirstOrDefault(p => p.Id == id);

            if (productTag == null) return null;

            productTag.Name = productTagDto.Name;

            _context.SaveChanges();

            return true;
        }

        public bool? Delete(int id)
        {
            var productTag = _context.ProductTags.FirstOrDefault(p => p.Id == id);

            if (productTag == null) return null;

            _context.ProductTags.Remove(productTag);
            _context.SaveChanges();

            return true;
        }
    }
}
