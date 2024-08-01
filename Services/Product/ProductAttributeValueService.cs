using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.ProductAttributeValue;

namespace nopCommerceApi.Services.Product
{
    public interface IProductAttributeValueService
    {
        ProductAttributeValue Create(ProductAttributeValueCreateDto productAttributeValueCreateDto);
        bool Delete(int id);
        IEnumerable<ProductAttributeValueDto> GetAll();
        ProductAttributeValueDto GetById(int id);
        bool Update(int id, ProductAttributeValueUpdateDto productAttributeValueUpdateDto);
    }

    public class ProductAttributeValueService : BaseService, IProductAttributeValueService
    {
        public ProductAttributeValueService(NopCommerceContext context, IMapper mapper, ILogger<ProductService> logger) : base(context, mapper, logger) { }

        public IEnumerable<ProductAttributeValueDto> GetAll()
        {
            var productAttributeValues = _context.ProductAttributeValues.ToList();
            var productAttributeValuesDto = _mapper.Map<IEnumerable<ProductAttributeValueDto>>(productAttributeValues);

            return productAttributeValuesDto;
        }

        public ProductAttributeValueDto GetById(int id)
        {
            var productsAttributeValue = _context.ProductAttributeValues.FirstOrDefault(p => p.Id == id);

            if (productsAttributeValue == null) throw new NotFoundExceptions($"Product attribute value with id {id} not found");

            var productAttributeValueDto = _mapper.Map<ProductAttributeValueDto>(productsAttributeValue);

            return productAttributeValueDto;
        }

        public ProductAttributeValue Create(ProductAttributeValueCreateDto productAttributeValueCreateDto)
        {
            var productAttributeValue = _mapper.Map<ProductAttributeValue>(productAttributeValueCreateDto);

            _context.ProductAttributeValues.Add(productAttributeValue);
            _context.SaveChanges();

            return productAttributeValue;
        }

        public bool Update(int id, ProductAttributeValueUpdateDto productAttributeValueUpdateDto)
        {
            var productAttributeValue = _context.ProductAttributeValues.FirstOrDefault(p => p.Id == id);

            if (productAttributeValue == null) throw new NotFoundExceptions($"Product attribute value with id {id} not found");

            productAttributeValueUpdateDto.Id = id;

            _mapper.Map(productAttributeValueUpdateDto, productAttributeValue);

            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var productAttributeValue = _context.ProductAttributeValues.FirstOrDefault(p => p.Id == id);

            if (productAttributeValue == null) throw new NotFoundExceptions($"Product attribute value with id {id} not found");

            _context.ProductAttributeValues.Remove(productAttributeValue);
            _context.SaveChanges();

            return true;
        }
    }
}
