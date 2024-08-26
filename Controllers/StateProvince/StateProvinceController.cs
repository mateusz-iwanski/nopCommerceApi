using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models;
using nopCommerceApi.Services.StateProvince;

namespace nopCommerceApi.Controllers.StateProvince
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
        //[Authorize(Roles = "Admin,User,Viewer")]
        public async Task<ActionResult<IEnumerable<Entities.Usable.StateProvince>>> GetAll()
        {
            var stateProvinceDtos = await _stateProvinceService.GetAllAsync();
            return Ok(stateProvinceDtos);
        }
    }
}
