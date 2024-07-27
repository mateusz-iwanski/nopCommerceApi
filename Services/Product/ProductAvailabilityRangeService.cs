using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Services.Product
{
    public interface IProductAvailabilityRangeService
    {
        ProductAvailabilityRange Create(ProductAvailabilityRangeCreateDto productAvailabilityRangeDto);
        IEnumerable<ProductAvailabilityRangeDto> GetAll();
        ProductAvailabilityRangeDto GetById(int id);
        bool Delete(int id);
    }

    public class ProductAvailabilityRangeService : BaseService, IProductAvailabilityRangeService
    {
        public ProductAvailabilityRangeService(NopCommerceContext context, IMapper mapper, ILogger<ProductAvailabilityRangeService> logger) 
            : base(context, mapper, logger) 
        { 
        }

        public IEnumerable<ProductAvailabilityRangeDto> GetAll()
        {
            var productAvailabilityRanges = _context.ProductAvailabilityRanges.ToList();
            var productAvailabilityRangeDtos = _mapper.Map<List<ProductAvailabilityRangeDto>>(productAvailabilityRanges);

            return productAvailabilityRangeDtos;
        }

        public ProductAvailabilityRangeDto GetById(int id)
        {
            var productAvailabilityRanges = _context.ProductAvailabilityRanges.FirstOrDefault(p => p.Id == id);

            var productAvailabilityRangeDto = productAvailabilityRanges != null ? _mapper.Map<ProductAvailabilityRangeDto>(productAvailabilityRanges) : throw new NotFoundExceptions($"ProductAvailabilityRange with id {id} not found");

            return productAvailabilityRangeDto;
        }

        public ProductAvailabilityRange Create(ProductAvailabilityRangeCreateDto productAvailabilityRangeDto)
        {
            var productAvailabilityRange = _mapper.Map<ProductAvailabilityRange>(productAvailabilityRangeDto);

            productAvailabilityRange.DisplayOrder = GetLastDisplayOrder() + 1;

            _context.ProductAvailabilityRanges.Add(productAvailabilityRange);
            _context.SaveChanges();

            return productAvailabilityRange;
        }

        public bool Delete(int id)
        {
            var productAvailabilityRange = _context.ProductAvailabilityRanges.FirstOrDefault(p => p.Id == id);

            if (productAvailabilityRange == null)
            {
                throw new NotFoundExceptions($"ProductAvailabilityRange with id {id} not found");
            }

            _context.ProductAvailabilityRanges.Remove(productAvailabilityRange);
            _context.SaveChanges();

            return true;
        }   

        private int GetLastDisplayOrder()
        {
            var lastDisplayOrder = _context.ProductAvailabilityRanges.Max(x => x.DisplayOrder);
            if (lastDisplayOrder != null)
            {
                return lastDisplayOrder;
            }
            else return 0;
        }
    }
}
