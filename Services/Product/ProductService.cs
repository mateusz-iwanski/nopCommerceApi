using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.NotUsable;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> GetById(int id);
        Task<Entities.Usable.Product> CreateMinimal(ProductCreateMinimalDto productDto);
        Task<bool> Delete(int id);
        Task<bool> UpdateBlockInformation(int id, ProductUpdateBlockInformationDto productDto);
        Task<bool> UpdateBlockSeo(int id, ProductUpdateBlockSeoDto productDto);
        Task<bool> UpdateBlockRating(int id, ProductUpdateBlockRatingDto productDto);
        Task<bool> UpdateBlockReviews(int id, ProductUpdateBlockReviewsDto productDto);
        Task<bool> UpdateBlockGiftCard(int id, ProductUpdateBlockGiftCardDto productDto);
        Task<bool> UpdateBlockDownload(int id, ProductUpdateBlockDownloadDto productDto);
        Task<bool> UpdateBlockRecurring(int id, ProductUpdateBlockRecurringDto productDto);
        Task<bool> UpdateBlockRentalPrice(int id, ProductUpdateBlockRentalPriceDto productDto);
        Task<bool> UpdateBlockShipping(int id, ProductUpdateBlockShippingDto productDto);
        Task<bool> UpdateBlockInventory(int id, ProductUpdateBlockInventoryDto productDto);
        Task<bool> UpdateBlockAttribute(int id, ProductUpdateBlockAttributeDto productDto);
        Task<bool> UpdateBlockPrice(int id, ProductUpdateBlockPriceDto productDto);
        Task<bool> UnAssociateCategory(int productId, int categoryId);
        Task<bool> AssociateCategory(int productId, int categoryId);
    }

    public class ProductService : BaseService, IProductService
    {
        public ProductService(NopCommerceContext context, IMapper mapper, ILogger<ProductService> logger) : base(context, mapper, logger) { }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return productDtos;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var products = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (products == null) throw new NotFoundExceptions($"Product with id {id} not found");

            var productDto = _mapper.Map<ProductDto>(products);

            return productDto;
        }

        public async Task<Entities.Usable.Product> CreateMinimal(ProductCreateMinimalDto productDto)
        {
            var product = _mapper.Map<Entities.Usable.Product>(productDto);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBlockInformation(int id, ProductUpdateBlockInformationDto productDto)
        {
            productDto.Id = id;

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBlockSeo(int id, ProductUpdateBlockSeoDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBlockRating(int id, ProductUpdateBlockRatingDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBlockReviews(int id, ProductUpdateBlockReviewsDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBlockGiftCard(int id, ProductUpdateBlockGiftCardDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBlockDownload(int id, ProductUpdateBlockDownloadDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBlockRecurring(int id, ProductUpdateBlockRecurringDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBlockRentalPrice(int id, ProductUpdateBlockRentalPriceDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBlockShipping(int id, ProductUpdateBlockShippingDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBlockInventory(int id, ProductUpdateBlockInventoryDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBlockAttribute(int id, ProductUpdateBlockAttributeDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBlockPrice(int id, ProductUpdateBlockPriceDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AssociateCategory(int productId, int categoryId)
        {
            var product = await _context.Products
                .Include(p => p.ProductCategoryMappings)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null) throw new NotFoundExceptions($"Product with id {productId} not found");

            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null) throw new NotFoundExceptions($"Category with id {categoryId} not found");

            // Check if the mapping already exists
            if (product.ProductCategoryMappings.Any(pcm => pcm.CategoryId == categoryId))
            {
                throw new BadRequestException($"Product with id {productId} is already associated with category id {categoryId}");
            }

            product.ProductCategoryMappings.Add(new ProductCategoryMapping { ProductId = productId, CategoryId = categoryId });

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UnAssociateCategory(int productId, int categoryId)
        {
            var product = await _context.Products
                .Include(p => p.ProductCategoryMappings)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null) throw new NotFoundExceptions($"Product with id {productId} not found");

            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null) throw new NotFoundExceptions($"Category with id {categoryId} not found");

            // Check if the mapping exists
            if (!product.ProductCategoryMappings.Any(pcm => pcm.CategoryId == categoryId))
            {
                throw new BadRequestException($"Product with id {productId} is not associated with category id {categoryId}");
            }

            var productCategoryMapping = product.ProductCategoryMappings.FirstOrDefault(pcm => pcm.CategoryId == categoryId);

            product.ProductCategoryMappings.Remove(productCategoryMapping);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
