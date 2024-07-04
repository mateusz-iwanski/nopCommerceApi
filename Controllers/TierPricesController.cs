﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers
{
    [Route("api/tierprices")]
    public class TierPricesController : ControllerBase
    {
        private readonly ITierPriceService _tierPriceService;
        
        public TierPricesController(ITierPriceService tierPriceService)
        {
            _tierPriceService = tierPriceService;
        }

        [HttpGet]
        public ActionResult<TierPrice> GetAll()
        {
            var tierPriceDtos = _tierPriceService.GetAll();
            return Ok(tierPriceDtos);
        }
    }
}