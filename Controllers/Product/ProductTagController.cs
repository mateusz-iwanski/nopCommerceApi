using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Product;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Controllers.Product
{
    [Route("api/product/tag")]
    [ApiController]
    public class ProductTagController : ControllerBase
    {
        private readonly IProductTagService _productTagService;

        public ProductTagController(IProductTagService productService)
        {
            _productTagService = productService;
        }

        // GET: api/product/tag
        [HttpGet]
        public IEnumerable<ProductTagDto> GetAll()
        {
            var productsTagto = _productTagService.GetAll();
            return productsTagto;
        }

        // GET: api/product/tag/details
        [HttpGet("details")]
        public IEnumerable<ProductTagDto> GetAllDetails()
        {
            var productsTagto = _productTagService.GetAllDteils();
            return productsTagto;
        }


        // GET: api/product/tag/by-name/tag_name
        [HttpGet("by-name/{name}")]
        public IEnumerable<ProductTagDto> GetByTag(string name)
        {
            var productsDto = _productTagService.GetByTag(name);
            return productsDto;
        }

        // GET: api/product/tag/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var productDto = _productTagService.GetById(id);

            return Ok(productDto);
        }

        // POST: api/product/tag
        [HttpPost]
        public IActionResult Create([FromBody] ProductTagCreateDto productTagDto)
        {
            var productTag = _productTagService.Create(productTagDto);
            return Created($"api/product/{productTag.Id}", productTagDto);
        }

        // PUT: api/product/tag/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductTagUpdateDto productTagDto)
        {
            _productTagService.Update(id, productTagDto);
            return Ok($"Update product by id: {id}");
        }

        // DELETE: api/product/tag/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productTag = _productTagService.Delete(id);
            return Ok(productTag);
        }

    }
}
