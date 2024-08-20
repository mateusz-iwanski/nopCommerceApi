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
        //// [Authorize(Roles = "Admin,User,Viewer")]
        public async Task<ActionResult<AddressDetailsDto>> GetAll()
        {
            var adressesDtos = await _addressService.GetAllAsync();

            return Ok(adressesDtos);
        }

        // Has tests
        /// <summary>
        /// Get address with details by ID  
        /// </summary>
        [HttpGet("{id}")]
        // [Authorize(Roles = "Admin,User,Viewer")]
        public async Task<ActionResult<AddressDetailsDto>> GetById([FromRoute] int id)
        {
            var address = await _addressService.GetByIdAsync(id);

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
        // [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> CreateWithNipPl([FromBody] AddressCreatePolishEnterpriseDto createAddressDto)
        {
            var address = await _addressService.CreateWithNipAsync(createAddressDto);

            return Created($"/api/address/{address.Id}", address);
        }

        // Has tests
        /// <summary>
        /// Update address for Polish enterprises with NIP
        /// </summary>
        // [Authorize(Roles = "Admin,User")]
        [HttpPut("update-with-nip")]
        public async Task<ActionResult> UpdateWithNip([FromBody] AddressUpdatePolishEnterpriseDto updateAddressDto)
        {
            var addressDto = await _addressService.UpdateWithNipAsync(updateAddressDto);

            return Ok(addressDto);
        }

        // Has test
        /// <summary>
        /// Creating address for individual person
        /// </summary>
        [HttpPost("add")]
        //// [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Create([FromBody] AddressCreateDto createAddressDto)
        {
            var address = await _addressService.CreateAsync(createAddressDto);

            return Created($"/api/address/{address.Id}", address);
        }

        // Has test
        /// <summary>
        /// Delete address by ID
        /// </summary>
        [HttpDelete("{id}")]
        // [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Delete(int id)
        {
            await _addressService.DeleteAsync(id);
            return Ok();
        }

        /// <summary>
        /// Update address by ID (without NIP)
        /// </summary>
        [HttpPut]
        // [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Update([FromBody] AddressUpdateDto updateAddressDto)
        {
            await _addressService.UpdateAsync(updateAddressDto);

            return Ok(updateAddressDto);
        }
    }
}
