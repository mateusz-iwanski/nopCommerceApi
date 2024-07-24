using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Services.Product
{
    public interface IProductTemplateService
    {
        IEnumerable<ProductTemplateDto> GetAll();
    }

    public class ProductTemplateService : BaseService, IProductTemplateService
    {
        public ProductTemplateService(NopCommerceContext context, IMapper mapper, ILogger<ProductService> logger) : base(context, mapper, logger) { }

        public IEnumerable<ProductTemplateDto> GetAll()
        {
            var productTemplates = _context.ProductTemplates.ToList();
            var productTemplateDtos = _mapper.Map<List<ProductTemplateDto>>(productTemplates);

            return productTemplateDtos;
        }
    }
}
