using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.TierPrice;
using nopCommerceApi.Services.TierPrice;

namespace nopCommerceApi.Controllers.TierPrice
{
    /// <summary>
    /// Tier pricing is a promotional tool that allows a store owner to price items differently for higher quantities.
    /// You can also use it as B2B/B2C prices, every customer can be assigned to a customer role and have a different price.
    /// </summary>    
    [Route("api/tierprice")]
    [ApiController]
    public class TierPriceController : ControllerBase
    {
        private readonly ITierPriceService _tierPriceService;

        public TierPriceController(ITierPriceService tierPriceService)
        {
            _tierPriceService = tierPriceService;
        }

        /// <summary>
        /// Get all tier prices available in the system.
        /// </summary>
        /// <remarks>
        /// Tier pricing is a promotional tool that allows a store owner to price items differently for higher quantities. \
        /// You can also use it as B2B/B2C prices, every customer can be assigned to a customer role and have a different price.
        /// </remarks>
        [HttpGet]        
        //[Authorize(Roles = "Admin,User,Viewer")]
        public async Task<IActionResult> GetAll()
        {
            var tierPriceDtos = await _tierPriceService.GetAllAsync();
            return Ok(tierPriceDtos);
        }

        /// <summary>
        /// Get all tier prices available in the system with details.
        /// </summary>
        [HttpGet("details")]        
        //[Authorize(Roles = "Admin,User,Viewer")]
        public async Task<IActionResult> GetAllDetails()
        {
            var tierPriceDtos = await _tierPriceService.GetAllDetailsAsync();
            return Ok(tierPriceDtos);
        }

        /// <summary>
        /// Get a tier price by its id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tierPriceDto = await _tierPriceService.GetByIdAsync(id);

            if (tierPriceDto == null) return NotFound();

            return Ok(tierPriceDto);
        }

        /// <summary>
        /// Creates a new tier price.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(TierPriceCreateDto tierPriceDto)
        {
            var tierPrice = await _tierPriceService.CreateAsync(tierPriceDto);
            return Created($"api/tierprice/{tierPrice.Id}", tierPrice);
        }

        /// <summary>
        /// Updates a tier price.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(TierPriceUpdateDto tierPriceDto)
        {
            var tierPrice = await _tierPriceService.UpdateAsync(tierPriceDto);
            return Ok(tierPrice);
        }

        /// <summary>
        /// Deletes a tier price.
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var tierPrice = await _tierPriceService.DeleteAsync(id);

            if (tierPrice == null) return NotFound();

            return Ok(tierPrice);
        }
    }
}
