using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Services;
using nopCommerceApi.Validations;

namespace nopCommerceApi.Controllers.Address
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        // Has tests
        [HttpGet]
        [Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<AddressDetailsDto> GetAll()
        {
            var adressesDtos = _addressService.GetAll();

            return Ok(adressesDtos);
        }

        // Has tests
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<AddressDetailsDto> GetById([FromRoute] int id)
        {
            var address = _addressService.GetById(id) ?? throw new NotFoundExceptions($"Adress with ID {id} not found.");
            return Ok(address);
        }

        // Has tests
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
        /// AddressAttribute ID="1" 
        /// 
        /// </summary>
        [HttpPost("add-with-nip")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult CreateWithNipPl([FromBody] AddressCreatePolishEnterpriseDto createAddressDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var address = _addressService.CreateWithNip(createAddressDto);

            return Created($"/api/address/{address.Id}", null);
        }

        // Has tests
        /// <summary>
        /// Update address for Polish enterprises
        /// 
        /// Update data without NIP, if you want to update NIP, you have to create a new address with nip for enterprises
        /// </summary>
        [Authorize(Roles = "Admin,User")]
        [HttpPut("update-with-nip/{id}")]
        public ActionResult UpdateWithNip(int id, [FromBody] AddressUpdatePolishEnterpriseDto updateAddressDto)
        {
            updateAddressDto.Id = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var addressUpdated = _addressService.UpdateWithNip(id, updateAddressDto) ?? throw new NotFoundExceptions($"Address with ID {id} not found.");
            }
            catch (AddressException updateException)
            {
                return BadRequest(updateException.Message);
            }

            return Ok(updateAddressDto);
        }

        // Has test
        /// <summary>
        /// Add address for typical user
        /// </summary>
        /// <param name="createAddressDto"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Create([FromBody] AddressCreateDto createAddressDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var address = _addressService.Create(createAddressDto);
                return Created($"/api/address/{address.Id}", null);
            }
            catch (AddressException createException)
            {
                throw new BadRequestException(createException.Message);
            }
        }

        // Has test
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Delete(int id)
        {
            var address = _addressService.Delete(id) ?? throw new NotFoundExceptions($"Address with ID {id} not found.");

            return Ok(address);
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Update(int id, [FromBody] AddressUpdateDto updateAddressDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var address = _addressService.Update(id, updateAddressDto) ?? throw new NotFoundExceptions($"Address with ID {id} not found.");
                return Ok(updateAddressDto);
            }
            catch (AddressException updateException)
            {
                return BadRequest(updateException.Message);
            }
        }
    }
}
