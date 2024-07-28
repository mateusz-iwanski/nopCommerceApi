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
        /// <summary>
        /// Get all products
        /// </summary>
        [HttpGet]
        public IEnumerable<ProductDto> GetAll()
        {
            var productsDto = _productService.GetAll();
            return productsDto;
        }

        // GET: api/product/5
        /// <summary>
        /// Get product by id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var productDto = _productService.GetById(id);

            return Ok(productDto);
        }

        // POST: api/product
        /// <summary>
        /// Create a new product
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] ProductCreateDto productDto)
        {
            var product = _productService.Create(productDto);
            return Created($"api/product/{ product.Id}", product);
        }

        /// <summary>
        /// Create a new product with minimal information
        /// </summary>
        /// <remarks>
        /// Only the required properties are included in this DTO, 
        /// rest fields set up with default values.
        /// </remarks>
        [HttpPost("minimal")]
        public IActionResult CreateMinimal([FromBody] ProductCreateMinimalDto productDto)
        {
            var product = _productService.CreateMinimal(productDto);
            return Created($"api/product/{ product.Id}", product);
        }

        // PUT: api/product/5
        /// <summary>
        /// Update product by id
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] string value)
        {
            return Ok($"Update product by id: {id}");
        }

        // DELETE: api/product/5
        /// <summary>
        /// Delete product by id
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Delete product by id: {id}");
        }
    }
}
