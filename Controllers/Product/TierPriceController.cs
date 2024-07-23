using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Services.Product;
using nopCommerceApi.Models.Product;
using nopCommerceApi.Exceptions;

namespace nopCommerceApi.Controllers.Product
{
    /// <summary>
    /// Tier pricing is a promotional tool that allows a store owner to price items differently for higher quantities.
    /// You can also use it as B2B/B2C prices, every customer can be assigned to a customer role and have a different price.
    /// </summary>
    /// 
    [Route("api/tierprice")]
    [ApiController]
    public class TierPriceController : ControllerBase
    {
        private readonly ITierPriceService _tierPriceService;

        public TierPriceController(ITierPriceService tierPriceService)
        {
            _tierPriceService = tierPriceService;
        }

        [HttpGet]
        /// <summary>
        /// Retrieves all tier prices available in the system.
        /// </summary>
        //[Authorize(Roles = "Admin,User,Viewer")]
        public IActionResult GetAll()
        {
            var tierPriceDtos = _tierPriceService.GetAll();
            return Ok(tierPriceDtos);
        }

        [HttpGet("details")]
        //[Authorize(Roles = "Admin,User,Viewer")]
        public IActionResult GetAllDetails()
        {
            var tierPriceDtos = _tierPriceService.GetAllDetails();
            return Ok(tierPriceDtos);
        }

        [HttpGet("{id}")]   
        public IActionResult GetById(int id)
        {
            var tierPriceDto = _tierPriceService.GetById(id);

            if (tierPriceDto == null) return NotFound();

            return Ok(tierPriceDto);
        }

        /// <summary>
        /// Creates a new tier price.
        /// </summary>
        /// <param name="tierPriceDto">The tier price data transfer object containing all necessary information.</param>
        /// <returns>The created tier price object.</returns>
        [HttpPost]
        public IActionResult Create(TierPriceCreateDto tierPriceDto)
        {
            var tierPrice = _tierPriceService.Create(tierPriceDto);
            return Ok(tierPrice);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TierPriceUpdateDto tierPriceDto)
        {
            var tierPrice = _tierPriceService.Update(id, tierPriceDto);
            return Ok(tierPrice);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var tierPrice = _tierPriceService.Delete(id);

            if (tierPrice == null) return NotFound();

            return Ok(tierPrice);
        }
    }
}
