using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers
{
    [Route("api/addressattribute")]
    public class AddressAttributeController : ControllerBase
    {
        private readonly IAddressAttributeService _addressAttributeService;

        public AddressAttributeController(IAddressAttributeService addressAttributeService)
        {
            _addressAttributeService = addressAttributeService;
        }

        [HttpGet]
        public ActionResult<AddressAttribute> GetAll()
        {
            var addressAttributeDtos = _addressAttributeService.GetAll();
            return Ok(addressAttributeDtos);
        }
    }
}
