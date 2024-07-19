﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers.Address
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/addressattribute")]
    [ApiController]
    public class AddressAttributeController : ControllerBase
    {
        private readonly IAddressAttributeService _addressAttributeService;

        public AddressAttributeController(IAddressAttributeService addressAttributeService)
        {
            _addressAttributeService = addressAttributeService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<AddressAttribute> GetAll()
        {
            var addressAttributeDtos = _addressAttributeService.GetAll();
            return Ok(addressAttributeDtos);
        }
    }
}
