using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers
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
        [Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<CurrencyDto> GetAll()
        {
            var currencyDtos = _currencyService.GetAll();
            return Ok(currencyDtos);
        }
    }
}
