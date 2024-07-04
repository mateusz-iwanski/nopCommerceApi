using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers
{
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<DetailsAddressDto> GetAll()
        {
            var adressesDtos = _addressService.GetAll();
         
            return Ok(adressesDtos);
        }

        /// <summary>
        /// Add address with the NIP value as a custom attribute for Poland.
        /// 
        /// Default nopCommerce not have this feature.
        /// CustomAttribute will look like this:
        /// 
        /// <Attributes>
        ///     <AddressAttribute ID="1">
        ///         <AddressAttributeValue>
        ///             <Value>NIP NUMBER</Value>
        ///          </AddressAttributeValue>
        ///     </AddressAttribute>
        /// </Attributes>      
        /// 
        /// AddressAttribute ID="1" - 
        /// 
        /// </summary>
        [HttpPost("add-with-nip")]
        public ActionResult CreateWithNip([FromBody] CreatePolishEnterpriseAddressDto createAddressDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var address = _addressService.CreateWithNip(createAddressDto);

            return Created($"/api/address/{address.Id}", null);
        }
    }
}
