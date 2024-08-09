using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.ProductSpecificationAttributeMapping;

namespace nopCommerceApi.Services.Product
{
    public interface IProductSpecificationAttributeMappingService
    {
        Task<ProductSpecificationAttributeMappingDto> CreateAsync(ProductSpecificationAttributeMappingCreateDto productSpecificationAttributeMappingCreateDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ProductSpecificationAttributeMappingDto>> GetAllAsync();
        Task<ProductSpecificationAttributeMappingDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductSpecificationAttributeMappingDto>> GetByProductIdAsync(int productId);
        Task<bool> UpdateAsync(ProductSpecificationAttributeMappingUpdateDto productSpecificationAttributeMappingUpdateDto);
    }

    public class ProductSpecificationAttributeMappingService : BaseService, IProductSpecificationAttributeMappingService
    {
        private readonly NopCommerceContext _context;

        public ProductSpecificationAttributeMappingService(NopCommerceContext context, IMapper mapper, ILogger<ProductSpecificationAttributeMappingService> logger) : base(context, mapper, logger)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductSpecificationAttributeMappingDto>> GetAllAsync()
        {
            var productSpecificationAttributeMappings = await _context.ProductSpecificationAttributeMappings.ToListAsync();

            return _mapper.Map<IEnumerable<ProductSpecificationAttributeMappingDto>>(productSpecificationAttributeMappings);
        }

        public async Task<ProductSpecificationAttributeMappingDto> GetByIdAsync(int id)
        {
            var productSpecificationAttributeMapping = await _context.ProductSpecificationAttributeMappings.FindAsync(id);
            if (productSpecificationAttributeMapping == null)
            {
                throw new NotFoundExceptions($"The product specification attribute mapping with id {id} was not found.");
            }

            return _mapper.Map<ProductSpecificationAttributeMappingDto>(productSpecificationAttributeMapping);
        }

        public async Task<ProductSpecificationAttributeMappingDto> CreateAsync(ProductSpecificationAttributeMappingCreateDto productSpecificationAttributeMappingCreateDto)
        {
            var productSpecificationAttributeMapping = _mapper.Map<Entities.Usable.ProductSpecificationAttributeMapping>(productSpecificationAttributeMappingCreateDto);

            _context.ProductSpecificationAttributeMappings.Add(productSpecificationAttributeMapping);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductSpecificationAttributeMappingDto>(productSpecificationAttributeMapping);
        }

        public async Task<bool> UpdateAsync(ProductSpecificationAttributeMappingUpdateDto productSpecificationAttributeMappingUpdateDto)
        {
            var productSpecificationAttributeMapping = await _context.ProductSpecificationAttributeMappings.FindAsync(productSpecificationAttributeMappingUpdateDto.Id);

            if (productSpecificationAttributeMapping == null)
            {
                throw new NotFoundExceptions($"The product specification attribute mapping with id {productSpecificationAttributeMappingUpdateDto.Id} was not found.");
            }

            _mapper.Map(productSpecificationAttributeMappingUpdateDto, productSpecificationAttributeMapping);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var productSpecificationAttributeMapping = await _context.ProductSpecificationAttributeMappings.FindAsync(id);

            if (productSpecificationAttributeMapping == null)
            {
                throw new NotFoundExceptions($"The product specification attribute mapping with id {id} was not found.");
            }

            _context.ProductSpecificationAttributeMappings.Remove(productSpecificationAttributeMapping);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProductSpecificationAttributeMappingDto>> GetByProductIdAsync(int productId)
        {
            var productSpecificationAttributeMappings = await _context.ProductSpecificationAttributeMappings.Where(x => x.ProductId == productId).ToListAsync();

            return _mapper.Map<IEnumerable<ProductSpecificationAttributeMappingDto>>(productSpecificationAttributeMappings);
        }
    }
}
