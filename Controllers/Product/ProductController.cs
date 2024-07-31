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
        /// Create a new product with minimal information and all rest fields set to default values
        /// </summary>
        /// <remarks>
        /// Only the required properties are included in this DTO, 
        /// rest fields are set up with default values.
        /// Then you need to use update methods to change the default values.
        /// </remarks>
        [HttpPost("add/minimal")]
        public IActionResult CreateMinimal([FromBody] ProductCreateMinimalDto productDto)
        {
            var product = _productService.CreateMinimal(productDto);
            return Created($"api/product/{ product.Id}", product);
        }

        /// <summary>
        /// Update product information by id
        /// </summary>
        /// <remarks>
        /// Note: Look out on boolean and datetime fields, if you not include them in the request, 
        /// boolean will set on false and datetime on default value (null).
        /// </remarks>
        [HttpPost("update/information/{id}")]
        public IActionResult UpdateInformation(int id, [FromBody] ProductUpdateInformationDto productDto)
        {
            _productService.UpdateInformation(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update SEO for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPost("update/seo/{id}")]
        public IActionResult UpdateSeo(int id, [FromBody] ProductUpdateSeoDto productDto)
        {
            _productService.UpdateSeo(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update rating for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// Look on Configuration → Settings → Catalog settings or for more details.        
        /// </remarks>
        [HttpPost("update/rating/{id}")]
        public IActionResult UpdateRating(int id, [FromBody] ProductUpdateRatingDto productDto)
        {
            _productService.UpdateRating(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update reviews for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPost("update/reviews/{id}")]
        public IActionResult UpdateReviews(int id, [FromBody] ProductUpdateReviewsDto productDto)
        {
            _productService.UpdateReviews(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update gift card
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>

        [HttpPost("update/giftcard/{id}")]
        public IActionResult UpdateGiftCard(int id, [FromBody] ProductUpdateGiftCardDto productDto)
        {
            _productService.UpdateGiftCard(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        // PUT: api/product/5
        /// <summary>
        /// Update product by id
        /// </summary>
        /// <remarks>
        /// If you don't want to update certain fields, don't add them to your requests.
        /// If you do not add some of a fields to the request, this fields will not be updated.
        /// </remarks>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductUpdateDto productDto)
        {
            _productService.Update(id, productDto);
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
