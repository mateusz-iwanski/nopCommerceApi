using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models.Product;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Controllers.Product
{
    public class ProductTagController : ControllerBase
    {
        private readonly IProductTagService _productService;

        public ProductTagController(IProductTagService productService)
        {
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public IEnumerable<ProductTagDto> GetAll()
        {
            var productsDto = _productService.GetAll();
            return productsDto;
        }
        
        [HttpGet]
        public IEnumerable<ProductTagDto> GetByTag(int tagId)
        {
            var productsDto = _productService.GetByTag(tagId);
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
