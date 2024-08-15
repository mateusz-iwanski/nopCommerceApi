using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using nopCommerceApi.Services.Currency;

namespace nopCommerceApi.Controllers.Currency
{
    /// <summary>
    /// Controller for currency operations
    /// </summary>
    [Route("api/currency")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        /// <summary>
        /// Get all currencies in the system
        /// </summary>
        [HttpGet]
        //[Authorize(Roles = "Admin,User,Viewer")]
        public async Task<ActionResult<IEnumerable<CurrencyDto>>> GetAll()
        {
            var currencyDtos = await _currencyService.GetAllAsync();
            return Ok(currencyDtos);
        }
    }
}
