using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using nopCommerceApi.Services;
using Microsoft.AspNetCore.Authorization;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Controllers
{
    [Route("api/tierprices")]
    [ApiController]
    public class TierPricesController : ControllerBase
    {
        private readonly ITierPriceService _tierPriceService;
        
        public TierPricesController(ITierPriceService tierPriceService)
        {
            _tierPriceService = tierPriceService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<TierPrice> GetAll()
        {
            var tierPriceDtos = _tierPriceService.GetAll();
            return Ok(tierPriceDtos);
        }
    }
}
