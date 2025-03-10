﻿using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models.ProductAvailabilityRange;
using nopCommerceApi.Services.Product;
using System.Collections.Concurrent;

namespace nopCommerceApi.Controllers.Product
{

    /// <summary>
    /// Represents a product availability range
    /// </summary>
    /// <remarks>
    /// Delivery dates are time ranges displaying approximate delivery time to a customer. 
    /// The delivery dates can be applied to products and displayed on the product details pages.
    /// Go to Configuration → Shipping → Dates and ranges.The two following panels will be displayed in the Dates and ranges window:
    /// </remarks>
    [Route("api/product/availabilityrange")]
    [ApiController]
    public class ProductAvailabilityRangeController : ControllerBase
    {
        public IProductAvailabilityRangeService _productAvailabilityRangeService;

        public ProductAvailabilityRangeController(IProductAvailabilityRangeService productAvailabilityRangeService)
        {
            _productAvailabilityRangeService = productAvailabilityRangeService;
        }

        // GET: api/product/availabilityrange
        /// <summary>
        /// Retrieves all product availability ranges.
        /// </summary>
        /// <returns>A collection of product availability ranges.</returns>
        [HttpGet]
        public async Task<IEnumerable<ProductAvailabilityRangeDto>> GetAll()
        {
            var productAvailabilityRangeServices = await _productAvailabilityRangeService.GetAllAsync();
            return productAvailabilityRangeServices;
        }

        /// <summary>
        /// Retrieves a product availability range by its ID.
        /// </summary>
        /// <param name="id">The ID of the product availability range.</param>
        /// <returns>The product availability range with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productAvailabilityRange = await _productAvailabilityRangeService.GetByIdAsync(id);

            return Ok(productAvailabilityRange);
        }

        // POST: api/product/availabilityrange
        /// <summary>
        /// Creates a new product availability range.
        /// </summary>
        /// <param name="productAvailabilityRange">The product availability range to create.</param>
        /// <returns>The created product availability range.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductAvailabilityRangeCreateDto productAvailabilityRange)
        {
            var productTag = await _productAvailabilityRangeService.CreateAsync(productAvailabilityRange);

            return Created($"api/product/availabilityrange/{productTag.Id}", productTag);
        }

        // PUT: api/product/availabilityrange/delete/5
        /// <summary>
        /// Deletes a product availability range by its ID.
        /// </summary>
        /// <param name="id">The ID of the product availability range to delete.</param>
        /// <returns>An HTTP 200 OK response if the deletion is successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productAvailabilityRangeService.DeleteAsync(id);
            return Ok();
        }
    }
}
