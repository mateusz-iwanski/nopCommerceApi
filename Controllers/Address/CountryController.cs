using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers.Address
{
    /// <summary>
    /// Controller for country operations
    /// </summary>
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// Get all countries 
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<CountryDto> GetAll()
        {
            var countryDtos = _countryService.GetAll();
            return Ok(countryDtos);
        }
    }
}
