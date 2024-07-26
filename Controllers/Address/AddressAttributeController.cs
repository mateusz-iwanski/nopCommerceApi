using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers.Address
{
    /// <summary>
    /// Get additional attributes for Address
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

        /// <summary>
        /// Get additional attributes for Address
        /// </summary>
        /// <remarks>
        /// If you want to manage attributes for address go to Administration -> Configuration -> Settings -> Customer settings -> Address form fields -> Custom address attributes
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<AddressAttribute> GetAll()
        {
            var addressAttributeDtos = _addressAttributeService.GetAll();
            return Ok(addressAttributeDtos);
        }
    }
}
