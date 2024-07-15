using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers.Address
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<CountryDto> GetAll()
        {
            var countryDtos = _countryService.GetAll();
            return Ok(countryDtos);
        }
    }
}
