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

namespace nopCommerceApi.Services.Product
{
    public interface IProductAttributeService
    {
        (ProductAttribute, ProductProductAttributeMapping) Create(ProductAttributeWithMappingCreateDto productAttributeWithMappingCreateDto);
        IEnumerable<ProductAttributeDto> GetAll();
        ProductAttributeDto GetById(int id);
        bool Update(int id, ProductAttributeUpdateDto productAttributeDtoUpdate);
    }

    public class ProductAttributeService : BaseService, IProductAttributeService
    {
        public ProductAttributeService(NopCommerceContext context, IMapper mapper, ILogger<ProductAttributeService> logger) : base(context, mapper, logger)
        {
        }

        // get all product attributes
        public IEnumerable<ProductAttributeDto> GetAll()
        {
            var productAttributes = _context.ProductAttributes.ToList();

            var productAttributesDto = _mapper.Map<IEnumerable<ProductAttributeDto>>(productAttributes);

            return productAttributesDto;
        }

        // get by id
        public ProductAttributeDto GetById(int id)
        {
            var productAttribute = _context.ProductAttributes.FirstOrDefault(x => x.Id == id);

            if (productAttribute == null) throw new NotFoundExceptions($"Product attribute with id {id} not found");

            var productAttributeDto = _mapper.Map<ProductAttributeDto>(productAttribute);

            return productAttributeDto;
        }

        // create product attribute
        public (ProductAttribute, ProductProductAttributeMapping) Create(ProductAttributeWithMappingCreateDto productAttributeWithMappingCreateDto)
        {


            var productAttribute = new ProductAttribute
            {
                Name = productAttributeWithMappingCreateDto.Name,
                Description = productAttributeWithMappingCreateDto.Description
            };

            _context.ProductAttributes.Add(productAttribute);
            _context.SaveChanges();

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

            _context.SaveChanges();

            return (productAttribute, productProductAttributeMapping);
        }

        // update product attribute
        public bool Update(int id, ProductAttributeUpdateDto productAttributeDtoUpdate)
        {
            var productAttribute = _context.ProductAttributes.FirstOrDefault(x => x.Id == id);

            if (productAttribute == null) throw new NotFoundExceptions($"Product attribute with id {id} not found");

            productAttributeDtoUpdate.Id = id;

            _mapper.Map(productAttributeDtoUpdate, productAttribute);

            _context.SaveChanges();

            return true;
        }



    }
}
