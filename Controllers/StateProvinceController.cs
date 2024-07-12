using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers
{
    [Route("api/state-province")]
    [ApiController]
    public class StateProvinceController : ControllerBase
    {
        private readonly IStateProvinceService _stateProvinceService;

        public StateProvinceController(IStateProvinceService stateProvince)
        {
            _stateProvinceService = stateProvince;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<StateProvince> GetAll()
        {
            var stateProvinceDtos = _stateProvinceService.GetAll();
            return Ok(stateProvinceDtos);
        }
    }
}
