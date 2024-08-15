using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Controllers.Product
{
    [Route("api/product/template")]
    [ApiController]
    public class ProductTemplateController : ControllerBase
    {
        private readonly IProductTemplateService _productTemplateService;

        public ProductTemplateController(IProductTemplateService productTemplateService)
        {
            _productTemplateService = productTemplateService;
        }

        /// <summary>
        /// Represents a product template.
        /// </summary>
        /// <remarks>
        /// In nopCommerce, you can specify an alternate layout template for a category, manufacturer, \
        /// product, and topic. You can see a list of the existing templates on the System → Templates page.\
        /// Doc: https://docs.nopcommerce.com/en/running-your-store/system-administration/templates.html
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productTemplates = await _productTemplateService.GetAllAsync();
            return Ok(productTemplates);
        }
    }
}
