using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers
{
    public class StateProvinceController : ControllerBase
    {
        private readonly IStateProvinceService _stateProvinceService;

        public StateProvinceController(IStateProvinceService stateProvince)
        {
            _stateProvinceService = stateProvince;
        }

        [HttpGet]
        public ActionResult<StateProvince> GetAll()
        {
            var stateProvinceDtos = _stateProvinceService.GetAll();
            return Ok(stateProvinceDtos);
        }
    }
}
