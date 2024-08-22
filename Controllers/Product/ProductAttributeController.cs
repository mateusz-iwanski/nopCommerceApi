using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models.ProductAttribute;
using nopCommerceApi.Models.ProductAttributeMapping;
using nopCommerceApi.Models.ProductAttributeValue;
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
        public async Task<IActionResult> GetAll()
        {
            var productAttributes = await _productAttributeService.GetAllAsync();

            return Ok(productAttributes);
        }

        /// <summary>
        /// Get product attribute by id        
        /// </summary>
        /// <remarks>
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productAttribute = await _productAttributeService.GetByIdAsync(id);

            return Ok(productAttribute);
        }

        /// <summary>
        /// Add product attribute 
        /// </summary>
        /// <remarks>
        /// #### In one action add product attribute and product attribute mapping which is associated with.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// </remarks>

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductAttributeWithMappingCreateDto productAttributeWithMappingCreateDto)
        {

            (ProductAttribute productAttribute, ProductProductAttributeMapping productProductAttributeMapping) = await _productAttributeService.CreateAsync(productAttributeWithMappingCreateDto);

            return Created($"api/product/attribute/{productAttribute.Id}", null);

        }

        /// <summary>
        /// Update product attribute
        /// </summary>
        /// <remarks>
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductAttributeUpdateDto productAttributeUpdateDto)
        {
            var productAttribute = await _productAttributeService.UpdateAsync(productAttributeUpdateDto);

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
        public async Task<IEnumerable<ProductAttributeValueDto>> GetAllValue()
        {
            var productAttributeValues = await _productAttributeValueService.GetAllAsync();

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
        public async Task<IActionResult> GetByIdValue(int id)
        {
            var productAttributeValue = await _productAttributeValueService.GetByIdAsync(id);

            return Ok(productAttributeValue);
        }

        /// <summary>
        /// Add product attribute values and associate with attribute
        /// </summary>
        /// <remarks>
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// #### In one action create product attribute values and associate with product attribute mapping.
        /// #### Product attribute mapping associate product with product attribute.
        /// </remarks>
        [HttpPost("value/add-to-attribute/{attributeId}")]
        public async Task<IActionResult> CreateValue(int attributeId, [FromBody] ProductAttributeValueDtoCreate productAttributeValueCreateDto)
        {            
            var productAttributeValue = await _productAttributeValueService.CreateAsync(attributeId, productAttributeValueCreateDto);

            // return created product attribute value path
            return Created($"api/product/attribute/value/{productAttributeValue.Id}", null);
        }

        /// <summary>
        /// Update product attribute values by id
        /// </summary>
        /// <remarks>
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// #### ProductAttributeMappingId can't be updated, if you want to update it, you need to delete and create new one.
        /// </remarks>
        [HttpPut("value/")]
        public async Task<IActionResult> UpdateValue([FromBody] ProductAttributeValueUpdateDto productAttributeValueUpdateDto)
        {
            var updated = await _productAttributeValueService.UpdateAsync(productAttributeValueUpdateDto);

            return Ok(updated);
        }

        /// <summary>
        /// Delete product attribute values by id       
        /// </summary>
        /// <remarks>
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
        /// </remarks>
        [HttpDelete("value/{id}")]
        public async Task<IActionResult> DeleteValue(int id)
        {
            var deleted = await _productAttributeValueService.DeleteAsync(id);

            return Ok();
        }

        #endregion
    }
}
