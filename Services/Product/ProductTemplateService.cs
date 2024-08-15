using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductTemplate;

namespace nopCommerceApi.Services.Product
{
    public interface IProductTemplateService
    {
        Task<IEnumerable<ProductTemplateDto>> GetAllAsync();
    }

    public class ProductTemplateService : BaseService, IProductTemplateService
    {
        public ProductTemplateService(NopCommerceContext context, IMapper mapper, ILogger<ProductService> logger) : base(context, mapper, logger) { }

        public async Task<IEnumerable<ProductTemplateDto>> GetAllAsync()
        {
            var productTemplates = await _context.ProductTemplates
                .AsNoTracking()
                .ToListAsync();

            var productTemplateDtos = _mapper.Map<List<ProductTemplateDto>>(productTemplates);

            return productTemplateDtos;
        }
    }
}
