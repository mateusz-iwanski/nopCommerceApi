using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttribute;
using nopCommerceApi.Exceptions;
using System.Linq;
using nopCommerceApi.Entities.Usable;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using nopCommerceApi.Models.ProductAttributeMapping;

namespace nopCommerceApi.Services.Product
{
    public interface IProductAttributeService
    {
        Task<(ProductAttribute, ProductProductAttributeMapping)> CreateAsync(ProductAttributeWithMappingCreateDto productAttributeWithMappingCreateDto);
        Task<IEnumerable<ProductAttributeDto>> GetAllAsync();
        Task<ProductAttributeDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(ProductAttributeUpdateDto productAttributeDtoUpdate);
    }

    public class ProductAttributeService : BaseService, IProductAttributeService
    {
        public ProductAttributeService(NopCommerceContext context, IMapper mapper, ILogger<ProductAttributeService> logger) : base(context, mapper, logger)
        {
        }

        public async Task<IEnumerable<ProductAttributeDto>> GetAllAsync()
        {
            var productAttributes = await _context.ProductAttributes
                .AsNoTracking()
                .ToListAsync();

            var productAttributesDto = _mapper.Map<IEnumerable<ProductAttributeDto>>(productAttributes);

            return productAttributesDto;
        }

        public async Task<ProductAttributeDto> GetByIdAsync(int id)
        {
            var productAttribute = await _context.ProductAttributes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (productAttribute == null) throw new NotFoundExceptions($"Product attribute with id {id} not found");

            var productAttributeDto = _mapper.Map<ProductAttributeDto>(productAttribute);

            return productAttributeDto;
        }

        public async Task<(ProductAttribute, ProductProductAttributeMapping)> CreateAsync(ProductAttributeWithMappingCreateDto productAttributeWithMappingCreateDto)
        {
            var productAttribute = new ProductAttribute
            {
                Name = productAttributeWithMappingCreateDto.Name,
                Description = productAttributeWithMappingCreateDto.Description
            };

            _context.ProductAttributes.Add(productAttribute);
            await _context.SaveChangesAsync();

            int id = productAttribute.Id;

            var productProductAttributeMapping = new ProductProductAttributeMapping
            {
                ProductAttributeId = productAttribute.Id,
                ProductId = productAttributeWithMappingCreateDto.ProductId,
                TextPrompt = productAttributeWithMappingCreateDto.TextPrompt,
                IsRequired = productAttributeWithMappingCreateDto.IsRequired,
                AttributeControlTypeId = productAttributeWithMappingCreateDto.AttributeControlTypeId,
                DisplayOrder = productAttributeWithMappingCreateDto.DisplayOrder,
                ValidationMinLength = productAttributeWithMappingCreateDto.ValidationMinLength,
                ValidationMaxLength = productAttributeWithMappingCreateDto.ValidationMaxLength,
                ValidationFileAllowedExtensions = productAttributeWithMappingCreateDto.ValidationFileAllowedExtensions,
                ValidationFileMaximumSize = productAttributeWithMappingCreateDto.ValidationFileMaximumSize,
                DefaultValue = productAttributeWithMappingCreateDto.DefaultValue,
                ConditionAttributeXml = productAttributeWithMappingCreateDto.ConditionAttributeXml,
            };

            _context.ProductProductAttributeMappings.Add(productProductAttributeMapping);

            await _context.SaveChangesAsync();

            return (productAttribute, productProductAttributeMapping);
        }

        public async Task<bool> UpdateAsync(ProductAttributeUpdateDto productAttributeDtoUpdate)
        {
            var productAttribute = await _context.ProductAttributes.FirstOrDefaultAsync(x => x.Id == productAttributeDtoUpdate.Id);

            _mapper.Map(productAttributeDtoUpdate, productAttribute);

            _context.ProductAttributes.Update(productAttribute);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
