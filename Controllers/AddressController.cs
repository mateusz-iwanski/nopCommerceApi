using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Services;
using nopCommerceApi.Validations;

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

        [HttpGet("{id}")]
        public ActionResult<DetailsAddressDto> GetById([FromRoute] int id)
        {
            var address = _addressService.GetById(id) ?? throw new NotFoundExceptions($"Adress with ID {id} not found.");
            return Ok(address);
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
        /// AddressAttribute ID="1" 
        /// 
        /// </summary>
        [HttpPost("add-with-nip")]
        public ActionResult CreateWithNipPl([FromBody] CreatePolishEnterpriseAddressDto createAddressDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var address = _addressService.CreateWithNip(createAddressDto);

            return Created($"/api/address/{address.Id}", null);
        }

        /// <summary>
        /// Update address for Polish enterprises
        /// 
        /// Update data without NIP, if you want to update NIP, you have to create a new address with nip for enterprises
        /// </summary>
        [HttpPut("update-with-nip/{id}")]
        public ActionResult UpdateWithNip(int id, [FromBody] UpdatePolishEnterpriseAddressDto updateAddressDto)
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

        /// <summary>
        /// Add address for typical user
        /// </summary>
        /// <param name="createAddressDto"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public ActionResult Create([FromBody] CreateAddressDto createAddressDto)
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

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var address = _addressService.Delete(id) ?? throw new NotFoundExceptions($"Address with ID {id} not found.");
            
            return Ok(address);
        }

        [HttpPut("update/{id}")]
        public ActionResult Update(int id, [FromBody] UpdateAddressDto updateAddressDto)
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
