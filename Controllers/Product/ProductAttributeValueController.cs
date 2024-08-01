using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using nopCommerceApi.Models.ProductAttributeValue;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Controllers.Product
{
    [Route("api/product/attribute")]
    [ApiController]
    public class ProductAttributeValueController : ControllerBase
    {
        private readonly IProductAttributeValueService _productAttributeValueService;

        public ProductAttributeValueController(IProductAttributeValueService productAttributeValueService)
        {
            _productAttributeValueService = productAttributeValueService;
        }

        /// <summary>
        /// Get all product attribute values
        /// </summary>
        [HttpGet("value")]
        public IEnumerable<ProductAttributeValueDto> GetAll()
        {
            var productAttributeValues = _productAttributeValueService.GetAll();

            return productAttributeValues;
        }

        /// <summary>
        /// Get product attribute values by id
        /// </summary>
        /// <remarks>
        /// #### ProductAttributeValue - Element of product attribute 
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// </remarks>
        [HttpGet("value/{id}")]
        public IActionResult GetById(int id)
        {
            var productAttributeValue = _productAttributeValueService.GetById(id);

            return Ok(productAttributeValue);
        }

        /// <summary>
        /// Add product attribute values by id
        /// </summary>
        [HttpPost("value/add")]
        public IActionResult Create([FromBody] ProductAttributeValueCreateDto productAttributeValueCreateDto)
        {
            var productAttributeValue = _productAttributeValueService.Create(productAttributeValueCreateDto);

            return Ok(productAttributeValue);
        }

        /// <summary>
        /// Update product attribute values by id
        /// </summary>
        [HttpPut("value/update/{id}")]
        public IActionResult Update(int id, [FromBody] ProductAttributeValueUpdateDto productAttributeValueUpdateDto)
        {
            var updated = _productAttributeValueService.Update(id, productAttributeValueUpdateDto);

            return Ok($"Update product attribute value by id: {id}");
        }

        /// <summary>
        /// Delete product attribute values by id
        /// </summary>
        [HttpDelete("value/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _productAttributeValueService.Delete(id);

            return Ok($"Delete product attribute value by id: {id}");
        }
    }
}
