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
        Entities.Usable.Product Create(ProductCreateDto productDto);
        Entities.Usable.Product CreateMinimal(ProductCreateMinimalDto productDto);
        bool UpdateInformation(int id, ProductUpdateInformationDto productDto);
        bool UpdateSeo(int id, ProductUpdateSeoDto productDto);
        bool UpdateRating(int id, ProductUpdateRatingDto productDto);
        bool UpdateReviews(int id, ProductUpdateReviewsDto productDto);
        bool UpdateGiftCard(int id, ProductUpdateGiftCardDto productDto);
        bool Update(int id, ProductUpdateDto productDto);        
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

        public Entities.Usable.Product Create(ProductCreateDto productDto)
        {
            var product = _mapper.Map<Entities.Usable.Product>(productDto);

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public Entities.Usable.Product CreateMinimal(ProductCreateMinimalDto productDto)
        {
            var product = _mapper.Map<Entities.Usable.Product>(productDto);

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public bool UpdateInformation(int id, ProductUpdateInformationDto productDto)
        {
            productDto.Id = id;

            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateSeo(int id, ProductUpdateSeoDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateRating(int id, ProductUpdateRatingDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateReviews(int id, ProductUpdateReviewsDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool UpdateGiftCard(int id, ProductUpdateGiftCardDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");

            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }

        public bool Update(int id, ProductUpdateDto productDto)
        {
            productDto.Id = id;

            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) throw new NotFoundExceptions($"Product with id {id} not found");
            
            _mapper.Map(productDto, product);

            _context.SaveChanges();

            return true;
        }
    }
}
