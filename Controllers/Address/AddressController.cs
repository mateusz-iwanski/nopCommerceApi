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
    /// <summary>
    /// Cotrnoller for address operations
    /// </summary>
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
        /// <summary>
        /// Get all addresses with details
        /// </summary>
        [HttpGet]
        //[Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<AddressDetailsDto> GetAll()
        {
            var adressesDtos = _addressService.GetAll();

            return Ok(adressesDtos);
        }

        // Has tests
        /// <summary>
        /// Get address with details by ID  
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<AddressDetailsDto> GetById([FromRoute] int id)
        {
            var address = _addressService.GetById(id);

            return Ok(address);
        }

        // Has tests
        /// <summary>
        /// Add address with the NIP value as a custom attribute for Poland.
        /// </summary>
        /// <remarks>
        /// Default nopCommerce not have this feature.
        /// </remarks> 
        [HttpPost("add-with-nip")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult CreateWithNipPl([FromBody] AddressCreatePolishEnterpriseDto createAddressDto)
        {
            var address = _addressService.CreateWithNip(createAddressDto);

            return Created($"/api/address/{address.Id}", address);
        }

        // Has tests
        /// <summary>
        /// Update address for Polish enterprises with NIP
        /// </summary>
        /// <remarks>
        /// If you don't want to update certain fields, don't add them to your requests. \
        /// If you do not add some of a fields to the request, this fields will not be updated.
        /// </remarks>
        [Authorize(Roles = "Admin,User")]
        [HttpPut("update-with-nip/{id}")]
        public ActionResult UpdateWithNip(int id, [FromBody] AddressUpdatePolishEnterpriseDto updateAddressDto)
        {
            updateAddressDto.Id = id;

            _addressService.UpdateWithNip(id, updateAddressDto);
            
            return Ok(updateAddressDto);
        }

        // Has test
        /// <summary>
        /// Creating address for individual person
        /// </summary>
        [HttpPost("add")]
        //[Authorize(Roles = "Admin,User")]
        public ActionResult Create([FromBody] AddressCreateDto createAddressDto)
        {
            var address = _addressService.Create(createAddressDto);

            return Created($"/api/address/{address.Id}", address);
        }

        // Has test
        /// <summary>
        /// Delete address by ID
        /// </summary>
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Delete(int id)
        {
            _addressService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Update address by ID (without NIP)
        /// </summary>
        /// <remarks>
        /// If you don't want to update certain fields, don't add them to your requests.
        /// If you do not add some of a fields to the request, this fields will not be updated.
        /// </remarks>
        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Update(int id, [FromBody] AddressUpdateDto updateAddressDto)
        {
            _addressService.Update(id, updateAddressDto);

            return Ok(updateAddressDto);
        }
    }
}
