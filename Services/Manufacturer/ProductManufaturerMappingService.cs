using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.ProductManufacturer;

namespace nopCommerceApi.Services.Manufacturer
{
    public interface IProductManufaturerMappingService
    {
        Task<ProductManufacturerMappingDto> CreateAsync(ProductManufacturerMappingCreateDto productManufacturerMappingCreateDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ProductManufacturerMappingDto>> GetAllAsync();
        Task<ProductManufacturerMappingDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductManufacturerMappingDto>> GetByManufacturerId(int manufacturerId);
        Task<IEnumerable<ProductManufacturerMappingDto>> GetByProductId(int productId);
    }

    public class ProductManufaturerMappingService : BaseService, IProductManufaturerMappingService
    {
        public ProductManufaturerMappingService(
            NopCommerceContext context, IMapper mapper, ILogger<ProductManufaturerMappingService> logger)
            : base(context, mapper, logger) { }

        // create product manufacturer mapping asynchronously
        public async Task<ProductManufacturerMappingDto> CreateAsync(ProductManufacturerMappingCreateDto productManufacturerMappingCreateDto)
        {
            var productManufacturerMapping = _mapper.Map<ProductManufacturerMapping>(productManufacturerMappingCreateDto);

            await _context.ProductManufacturerMappings.AddAsync(productManufacturerMapping);
            await _context.SaveChangesAsync();

            var productManufacturerMappingDto = _mapper.Map<ProductManufacturerMappingDto>(productManufacturerMapping);

            return productManufacturerMappingDto;
        }

        // get all product manufacturer mappings asynchronously
        public async Task<IEnumerable<ProductManufacturerMappingDto>> GetAllAsync()
        {
            var productManufacturerMappings = await _context.ProductManufacturerMappings.ToListAsync();
            var productManufacturerMappingDtos = _mapper.Map<List<ProductManufacturerMappingDto>>(productManufacturerMappings);

            return productManufacturerMappingDtos;
        }

        // get by id asynchronously
        public async Task<ProductManufacturerMappingDto> GetByIdAsync(int id)
        {
            var productManufacturerMapping = await _context.ProductManufacturerMappings.FirstOrDefaultAsync(c => c.Id == id);

            if (productManufacturerMapping == null) throw new NotFoundExceptions($"Product manufacturer mapping with id {id} not found");

            var productManufacturerMappingDto = _mapper.Map<ProductManufacturerMappingDto>(productManufacturerMapping);

            return productManufacturerMappingDto;
        }

        // delete product manufacturer mapping asynchronously
        public async Task<bool> DeleteAsync(int id)
        {
            var productManufacturerMapping = await _context.ProductManufacturerMappings.FirstOrDefaultAsync(c => c.Id == id);

            if (productManufacturerMapping == null) throw new NotFoundExceptions($"Product manufacturer mapping with id {id} not found");

            _context.ProductManufacturerMappings.Remove(productManufacturerMapping);
            await _context.SaveChangesAsync();

            return true;
        }

        // get all product associate with manufacturer
        public async Task<IEnumerable<ProductManufacturerMappingDto>> GetByManufacturerId(int manufacturerId)
        {
            var productManufacturerMappings = await _context.ProductManufacturerMappings.Where(c => c.ManufacturerId == manufacturerId).ToListAsync();
            var productManufacturerMappingDtos = _mapper.Map<List<ProductManufacturerMappingDto>>(productManufacturerMappings);

            return productManufacturerMappingDtos;
        }

        // get all manufacturer associate with product
        public async Task<IEnumerable<ProductManufacturerMappingDto>> GetByProductId(int productId)
        {
            var productManufacturerMappings = await _context.ProductManufacturerMappings.Where(c => c.ProductId == productId).ToListAsync();
            var productManufacturerMappingDtos = _mapper.Map<List<ProductManufacturerMappingDto>>(productManufacturerMappings);

            return productManufacturerMappingDtos;
        }
        
    }
}
