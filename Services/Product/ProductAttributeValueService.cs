using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.ProductAttributeValue;
using System;

namespace nopCommerceApi.Services.Product
{
    public interface IProductAttributeValueService
    {
        Task<ProductAttributeValueDto> CreateAsync(int attributeId, ProductAttributeValueDtoCreate productAttributeValueCreateDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ProductAttributeValueDto>> GetAllAsync();
        Task<ProductAttributeValueDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(ProductAttributeValueUpdateDto productAttributeValueUpdateDto);
    }

    public class ProductAttributeValueService : BaseService, IProductAttributeValueService
    {
        public ProductAttributeValueService(NopCommerceContext context, IMapper mapper, ILogger<ProductService> logger) : base(context, mapper, logger) { }

        public async Task<IEnumerable<ProductAttributeValueDto>> GetAllAsync()
        {
            var productAttributeValues = await _context.ProductAttributeValues
                .AsNoTracking()
                .ToListAsync();
            var productAttributeValuesDto = _mapper.Map<IEnumerable<ProductAttributeValueDto>>(productAttributeValues);

            return productAttributeValuesDto;
        }

        public async Task<ProductAttributeValueDto> GetByIdAsync(int id)
        {
            var productsAttributeValue = await _context.ProductAttributeValues
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (productsAttributeValue == null) throw new NotFoundExceptions($"Product attribute value with id {id} not found");

            var productAttributeValueDto = _mapper.Map<ProductAttributeValueDto>(productsAttributeValue);

            return productAttributeValueDto;
        }

        public async Task<ProductAttributeValueDto> CreateAsync(int attributeId, ProductAttributeValueDtoCreate productAttributeValueCreateDto)
        {
            // get product attribute mapping by attribute id
            var productProductAttributeMappings = _context.ProductProductAttributeMappings.FirstOrDefault(p => p.ProductAttributeId == attributeId);

            if (productProductAttributeMappings == null) throw new NotFoundExceptions($"Product attribute mapping with product attribute id {attributeId} not found");

            productAttributeValueCreateDto.ProductAttributeMappingId = productProductAttributeMappings.Id;

            var productAttributeValue = _mapper.Map<ProductAttributeValue>(productAttributeValueCreateDto);

            _context.ProductAttributeValues.Add(productAttributeValue);
            await _context.SaveChangesAsync();

            var productAttributeValueDto = _mapper.Map<ProductAttributeValueDto>(productAttributeValue);

            return productAttributeValueDto;
        }

        public async Task<bool> UpdateAsync(ProductAttributeValueUpdateDto productAttributeValueUpdateDto)
        {
            var productAttributeValue = await _context.ProductAttributeValues.FirstOrDefaultAsync(p => p.Id == productAttributeValueUpdateDto.Id);

            // ProductAttributeMappingId can't be updated
            productAttributeValueUpdateDto.ProductAttributeMappingId = productAttributeValue.ProductAttributeMappingId;

            _mapper.Map(productAttributeValueUpdateDto, productAttributeValue);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var productAttributeValue = await _context.ProductAttributeValues.FirstOrDefaultAsync(p => p.Id == id);

            if (productAttributeValue == null) throw new NotFoundExceptions($"Product attribute value with id {id} not found");

            _context.ProductAttributeValues.Remove(productAttributeValue);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
