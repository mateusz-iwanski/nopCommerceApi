using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.Product;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Controllers.Product
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public IEnumerable<ProductDto> GetAll()
        {
            var productsDto = _productService.GetAll();
            return productsDto;
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var productDto = _productService.GetById(id);

            return Ok(productDto);
        }

        // POST: api/product
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok("Create a product");
        }

        // PUT: api/product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok($"Update product by id: {id}");
        }

        // DELETE: api/product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Delete product by id: {id}");
        }
    }
}
