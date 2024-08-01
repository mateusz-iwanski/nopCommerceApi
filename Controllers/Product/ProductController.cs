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
        /// Update block information for product
        /// </summary>
        /// <remarks>
        /// Note: Look out on boolean and datetime fields, if you not include them in the request, 
        /// boolean will set on false and datetime on default value (null).
        /// </remarks>
        [HttpPut("update/block/information/{id}")]
        public IActionResult UpdateBlockInformation(int id, [FromBody] ProductUpdateBlockInformationDto productDto)
        {
            _productService.UpdateBlockInformation(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block SEO for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/seo/{id}")]
        public IActionResult UpdateBlockSeo(int id, [FromBody] ProductUpdateBlockSeoDto productDto)
        {
            _productService.UpdateBlockSeo(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block rating for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// Look on Configuration → Settings → Catalog settings or for more details.        
        /// </remarks>
        [HttpPut("update/block/rating/{id}")]
        public IActionResult UpdateBlockRating(int id, [FromBody] ProductUpdateBlockRatingDto productDto)
        {
            _productService.UpdateBlockRating(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block reviews for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/reviews/{id}")]
        public IActionResult UpdateBlockReviews(int id, [FromBody] ProductUpdateBlockReviewsDto productDto)
        {
            _productService.UpdateBlockReviews(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block gift card for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>

        [HttpPut("update/block/giftcard/{id}")]
        public IActionResult UpdateBlockGiftCard(int id, [FromBody] ProductUpdateBlockGiftCardDto productDto)
        {
            _productService.UpdateBlockGiftCard(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block download for product 
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/download/{id}")]
        public IActionResult UpdateBlockDownload(int id, [FromBody] ProductUpdateBlockDownloadDto productDto)
        {
            _productService.UpdateBlockDownload(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block recurring for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/recurring/{id}")]
        public IActionResult UpdateBlockRecurring(int id, [FromBody] ProductUpdateBlockRecurringDto productDto)
        {
            _productService.UpdateBlockRecurring(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block rental price for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/rental/{id}")]
        public IActionResult UpdateBlockRentalPrice(int id, [FromBody] ProductUpdateBlockRentalPriceDto productDto)
        {
            _productService.UpdateBlockRentalPrice(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block shipping for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/shipping/{id}")]
        public IActionResult UpdateBlockShipping(int id, [FromBody] ProductUpdateBlockShippingDto productDto)
        {
            _productService.UpdateBlockShipping(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block inventory for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/inventory/{id}")]
        public IActionResult UpdateBlockInventory(int id, [FromBody] ProductUpdateBlockInventoryDto productDto)
        {
            _productService.UpdateBlockInventory(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block attribute for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/attribute/{id}")]
        public IActionResult UpdateBlockAttribute(int id, [FromBody] ProductUpdateBlockAttributeDto productDto)
        {
            _productService.UpdateBlockAttribute(id, productDto);
            return Ok($"Update product by id: {id}");
        }


        /// <summary>
        /// Update block price for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/price/{id}")]
        public IActionResult UpdateBlockPrice(int id, [FromBody] ProductUpdateBlockPriceDto productDto)
        {
            _productService.UpdateBlockPrice(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok($"Delete product by id: {id}");
        }

        /// <summary>
        /// Associate category to product
        /// </summary>
        [HttpPost("{productId}link/category{categoryId}")]
        public IActionResult AssociateCategory(int productId, int categoryId)
        {
            _productService.AssociateCategory(productId, categoryId);
            return Ok($"Associate category to product by id: {productId}");
        }

        /// <summary>
        /// Unassociate category to product
        /// </summary>
        [HttpDelete( "{productId}unlink/category{categoryId}")]
        public IActionResult UnAssociateCategory(int productId, int categoryId)
        {
            _productService.UnAssociateCategory(productId, categoryId);
            return Ok($"Unassociate category {categoryId} from product by id: {productId}");
        }
    }
}
