using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models.ProductAttribute;
using nopCommerceApi.Services.Product;

namespace nopCommerceApi.Controllers.Product
{    
    [Route("api/product/attribute")]
    [ApiController]
    public class ProductAttributeController : ControllerBase
    {
        private readonly IProductAttributeService _productAttributeService;
        private readonly IProductAttributeValueService _productAttributeValueService;

        public ProductAttributeController(IProductAttributeService productAttributeService, IProductAttributeValueService productAttributeValueService)
        {
            _productAttributeService = productAttributeService;
            _productAttributeValueService = productAttributeValueService;
        }

        #region attribute

        /// <summary>
        /// Get all product attributes
        /// </summary>
        /// <remarks>
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// </remarks>
        [HttpGet]
        public IActionResult GetAll()
        {
            var productAttributes = _productAttributeService.GetAll();

            return Ok(productAttributes);
        }

        /// <summary>
        /// Get product attribute by id        
        /// </summary>
        /// <remarks>
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// </remarks>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var productAttribute = _productAttributeService.GetById(id);

            return Ok(productAttribute);
        }

        /// <summary>
        /// Add product attribute 
        /// </summary>
        /// <remarks>
        /// #### In one action add product attribute and product attribute mapping which is associated with.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// </remarks>

        [HttpPost("add")]
        public IActionResult Create([FromBody] ProductAttributeWithMappingCreateDto productAttributeWithMappingCreateDto)
        {

            (ProductAttribute productAttribute, ProductProductAttributeMapping productProductAttributeMapping) = _productAttributeService.Create(productAttributeWithMappingCreateDto);

            return Created($"api/product/attribute/{productAttribute.Id}", null);

        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <remarks>
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// </remarks>
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] ProductAttributeUpdateDto productAttributeUpdateDto)
        {
            var productAttribute = _productAttributeService.Update(id, productAttributeUpdateDto);

            return Ok(productAttribute);
        }

        #endregion

        #region Value

        /// <summary>
        /// Get all product attribute values
        /// </summary>
        /// <remarks>
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// </remarks>
        [HttpGet("value")]
        public IEnumerable<ProductAttributeValueDto> GetAllValue()
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
        public IActionResult GetByIdValue(int id)
        {
            var productAttributeValue = _productAttributeValueService.GetById(id);

            return Ok(productAttributeValue);
        }

        /// <summary>
        /// Add product attribute values and associate with attribute
        /// </summary>
        /// <remarks>
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// </remarks>
        [HttpPost("value/add-to-attribute/{attributeId}")]
        public IActionResult CreateValue(int attributeId, [FromBody] ProductAttributeValueDtoCreate productAttributeValueCreateDto)
        {            
            var productAttributeValue = _productAttributeValueService.Create(attributeId, productAttributeValueCreateDto);

            return Ok(productAttributeValue);
        }

        /// <summary>
        /// Update product attribute values by id
        /// </summary>
        /// <remarks>
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// </remarks>
        [HttpPut("value/update/{id}")]
        public IActionResult UpdateValue(int id, [FromBody] ProductAttributeValueUpdateDto productAttributeValueUpdateDto)
        {
            var updated = _productAttributeValueService.Update(id, productAttributeValueUpdateDto);

            return Ok($"Update product attribute value by id: {id}");
        }

        /// <summary>
        /// Delete product attribute values by id       
        /// </summary>
        /// <remarks>
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// </remarks>
        [HttpDelete("value/delete/{id}")]
        public IActionResult DeleteValue(int id)
        {
            var deleted = _productAttributeValueService.Delete(id);

            return Ok($"Delete product attribute value by id: {id}");
        }

        #endregion
    }
}
