using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers.Address
{
    /// <summary>
    /// State Province Controller
    /// </summary>
    [Route("api/state-province")]
    [ApiController]
    public class StateProvinceController : ControllerBase
    {
        private readonly IStateProvinceService _stateProvinceService;

        public StateProvinceController(IStateProvinceService stateProvince)
        {
            _stateProvinceService = stateProvince;
        }

        /// <summary>
        /// Get all state province
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<StateProvince> GetAll()
        {
            var stateProvinceDtos = _stateProvinceService.GetAll();
            return Ok(stateProvinceDtos);
        }
    }
}
