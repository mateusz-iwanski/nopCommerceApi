using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Services.Product
{
    public interface IProductTagService
    {
        ProductTagDto Create(ProductTagDto productTagDto);
        void Delete(int id);
        IEnumerable<ProductTagDto> GetAll();
        ProductTagDto GetById(int id);
        IEnumerable<ProductTagDto> GetByTag(int tagId);
        ProductTagDto Update(int id, ProductTagDto productTagDto);
    }

    public class ProductTagService : BaseService, IProductTagService
    {
        public ProductTagService(NopCommerceContext context, IMapper mapper, ILogger logger)
            : base(context, mapper, logger) { }

        public IEnumerable<ProductTagDto> GetAll()
        {
            var productTags = _context.ProductTags.ToList();
            var productTagDtos = _mapper.Map<List<ProductTagDto>>(productTags);

            return productTagDtos;
        }

        public IEnumerable<ProductTagDto> GetByTag(int tagId)
        {
            var productTags = _context.ProductTags.Where(p => p.Id == tagId).ToList();
            var productTagDtos = _mapper.Map<List<ProductTagDto>>(productTags);

            return productTagDtos;
        }

        public ProductTagDto GetById(int id)
        {
            var productTag = _context.ProductTags.FirstOrDefault(p => p.Id == id);

            var productTagDto = productTag != null ? _mapper.Map<ProductTagDto>(productTag) : throw new NotFoundExceptions($"ProductTag with id {id} not found");

            return productTagDto;
        }

        public ProductTagDto Create(ProductTagDto productTagDto)
        {
            var productTag = _mapper.Map<ProductTag>(productTagDto);

            _context.ProductTags.Add(productTag);
            _context.SaveChanges();

            return productTagDto;
        }

        public ProductTagDto Update(int id, ProductTagDto productTagDto)
        {
            var productTag = _context.ProductTags.FirstOrDefault(p => p.Id == id);

            if (productTag == null)
            {
                throw new NotFoundExceptions($"ProductTag with id {id} not found");
            }

            _mapper.Map(productTagDto, productTag);
            _context.SaveChanges();

            return productTagDto;
        }

        public void Delete(int id)
        {
            var productTag = _context.ProductTags.FirstOrDefault(p => p.Id == id);

            if (productTag == null)
            {
                throw new NotFoundExceptions($"ProductTag with id {id} not found");
            }

            _context.ProductTags.Remove(productTag);
            _context.SaveChanges();
        }
    }
}
