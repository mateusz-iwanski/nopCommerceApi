using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Country;
using nopCommerceApi.Services.Country;

namespace nopCommerceApi.Controllers.Country
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
        //[Authorize(Roles = "Admin,User,Viewer")]
        public async Task<ActionResult<CountryDto>> GetAll()
        {
            var countryDtos = await _countryService.GetAllAsync();
            return Ok(countryDtos);
        }
    }
}
