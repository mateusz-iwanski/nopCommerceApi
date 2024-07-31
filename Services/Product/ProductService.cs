using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Services.Product
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto GetById(int id);
        Entities.Usable.Product CreateMinimal(ProductCreateMinimalDto productDto);
        bool UpdateBlockInformation(int id, ProductUpdateBlockInformationDto productDto);
        bool UpdateBlockSeo(int id, ProductUpdateBlockSeoDto productDto);
        bool UpdateBlockRating(int id, ProductUpdateBlockRatingDto productDto);
        bool UpdateBlockReviews(int id, ProductUpdateBlockReviewsDto productDto);
        bool UpdateBlockGiftCard(int id, ProductUpdateBlockGiftCardDto productDto);
        bool UpdateBlockDownload(int id, ProductUpdateBlockDownloadDto productDto);
        bool UpdateBlockRecurring(int id, ProductUpdateBlockRecurringDto productDto);
        bool UpdateBlockRentalPrice(int id, ProductUpdateBlockRentalPriceDto productDto);
        bool UpdateBlockShipping(int id, ProductUpdateBlockShippingDto productDto);
        bool UpdateBlockInventory(int id, ProductUpdateBlockInventoryDto productDto);
        bool UpdateBlockAttribute(int id, ProductUpdateBlockAttributeDto productDto);
        bool UpdateBlockPrice(int id, ProductUpdateBlockPriceDto productDto);
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

            if (products == null) throw new NotFoundExceptions($"Product with id {id} not found");

            var productDto = _mapper.Map<ProductDto>(products);

            return productDto;
        }

        public Entities.Usable.Product CreateMinimal(ProductCreateMinimalDto productDto)
        {
            var product = _mapper.Map<Entities.Usable.Product>(productDto);

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public bool UpdateBlockInformation(int id, ProductUpdateBlockInformationDto productDto)
        {
            productDto.Id = id;

            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateBlockSeo(int id, ProductUpdateBlockSeoDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateBlockRating(int id, ProductUpdateBlockRatingDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateBlockReviews(int id, ProductUpdateBlockReviewsDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateBlockGiftCard(int id, ProductUpdateBlockGiftCardDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateBlockDownload(int id, ProductUpdateBlockDownloadDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateBlockRecurring(int id, ProductUpdateBlockRecurringDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateBlockRentalPrice(int id, ProductUpdateBlockRentalPriceDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateBlockShipping(int id, ProductUpdateBlockShippingDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateBlockInventory(int id, ProductUpdateBlockInventoryDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateBlockAttribute(int id, ProductUpdateBlockAttributeDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateBlockPrice(int id, ProductUpdateBlockPriceDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

    }
}
