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
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var productsDto = await _productService.GetAll();
            return productsDto;
        }

        // GET: api/product/5
        /// <summary>
        /// Get product by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productDto = await _productService.GetById(id);

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
        public async Task<IActionResult> CreateMinimal([FromBody] ProductCreateMinimalDto productDto)
        {
            var product = await _productService.CreateMinimal(productDto);
            return Ok(product);
        }

        /// <summary>
        /// Update block information for product
        /// </summary>
        /// <remarks>
        /// Note: Look out on boolean and datetime fields, if you not include them in the request, 
        /// boolean will set on false and datetime on default value (null).
        /// </remarks>
        [HttpPut("update/block/information/{id}")]
        public async Task<IActionResult> UpdateBlockInformation(int id, [FromBody] ProductUpdateBlockInformationDto productDto)
        {
            await _productService.UpdateBlockInformation(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block SEO for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/seo/{id}")]
        public async Task<IActionResult> UpdateBlockSeo(int id, [FromBody] ProductUpdateBlockSeoDto productDto)
        {
            await _productService.UpdateBlockSeo(id, productDto);
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
        public async Task<IActionResult> UpdateBlockRating(int id, [FromBody] ProductUpdateBlockRatingDto productDto)
        {
            await _productService.UpdateBlockRating(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block reviews for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/reviews/{id}")]
        public async Task<IActionResult> UpdateBlockReviews(int id, [FromBody] ProductUpdateBlockReviewsDto productDto)
        {
            await _productService.UpdateBlockReviews(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block gift card for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>

        [HttpPut("update/block/giftcard/{id}")]
        public async Task<IActionResult> UpdateBlockGiftCard(int id, [FromBody] ProductUpdateBlockGiftCardDto productDto)
        {
            await _productService.UpdateBlockGiftCard(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block download for product 
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/download/{id}")]
        public async Task<IActionResult> UpdateBlockDownload(int id, [FromBody] ProductUpdateBlockDownloadDto productDto)
        {
            await _productService.UpdateBlockDownload(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block recurring for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/recurring/{id}")]
        public async Task<IActionResult> UpdateBlockRecurring(int id, [FromBody] ProductUpdateBlockRecurringDto productDto)
        {
            await _productService.UpdateBlockRecurring(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block rental price for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/rental/{id}")]
        public async Task<IActionResult> UpdateBlockRentalPrice(int id, [FromBody] ProductUpdateBlockRentalPriceDto productDto)
        {
            await _productService.UpdateBlockRentalPrice(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block shipping for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/shipping/{id}")]
        public async Task<IActionResult> UpdateBlockShipping(int id, [FromBody] ProductUpdateBlockShippingDto productDto)
        {
            await _productService.UpdateBlockShipping(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block inventory for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/inventory/{id}")]
        public async Task<IActionResult> UpdateBlockInventory(int id, [FromBody] ProductUpdateBlockInventoryDto productDto)
        {
            await _productService.UpdateBlockInventory(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Update block attribute for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/attribute/{id}")]
        public async Task<IActionResult> UpdateBlockAttribute(int id, [FromBody] ProductUpdateBlockAttributeDto productDto)
        {
            await _productService.UpdateBlockAttribute(id, productDto);
            return Ok($"Update product by id: {id}");
        }


        /// <summary>
        /// Update block price for product
        /// </summary>
        /// <remarks>
        /// Note: If you do not include some fields in the request, they will be updated to default values.
        /// </remarks>
        [HttpPut("update/block/price/{id}")]
        public async Task<IActionResult> UpdateBlockPrice(int id, [FromBody] ProductUpdateBlockPriceDto productDto)
        {
            await _productService.UpdateBlockPrice(id, productDto);
            return Ok($"Update product by id: {id}");
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Ok($"Delete product by id: {id}");
        }

        /// <summary>
        /// Associate category to product
        /// </summary>
        [HttpPost("{productId}/link/category/{categoryId}")]
        public async Task<IActionResult> AssociateCategory(int productId, int categoryId)
        {
            await _productService.AssociateCategory(productId, categoryId);
            return Ok($"Associate category to product by id: {productId}");
        }

        /// <summary>
        /// Unassociate category to product
        /// </summary>
        [HttpDelete("{productId}/unlink/category/{categoryId}")]
        public async Task<IActionResult> UnAssociateCategory(int productId, int categoryId)
        {
            await _productService.UnAssociateCategory(productId, categoryId);
            return Ok($"Unassociate category {categoryId} from product by id: {productId}");
        }
    }
}
