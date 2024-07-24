using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Controllers.Product
{
    [Route("api/product/template")]
    [ApiController]
    public class ProductTemplateController : ControllerBase
    {
        private readonly IProductTemplateService productTemplateService;

        public ProductTemplateController(IProductTemplateService productTemplateService)
        {
            this.productTemplateService = productTemplateService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var productTemplates = productTemplateService.GetAll();
            return Ok(productTemplates);
        }
    }
}
