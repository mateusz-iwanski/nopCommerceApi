using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Services.Product
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto GetById(int id);
    }

    public class ProductService : BaseService, IProductService
    {
        public ProductService(NopCommerceContext context, IMapper mapper, ILogger<ProductService> logger) : base (context, mapper, logger) { }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = _context.Products.ToList();
            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return productDtos;
        }

        public ProductDto GetById(int id)
        {
            var products = _context.Products.FirstOrDefault(p => p.Id == id);
            
            var productDto = products != null ? _mapper.Map<ProductDto>(products) : throw new NotFoundExceptions($"Product with id {id} not found");

            return productDto;
        }
    }
}
