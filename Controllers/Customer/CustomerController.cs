using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Customer;
using nopCommerceApi.Services.Customer;

namespace nopCommerceApi.Controllers.Customer
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public record Password(string password);

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customer
        /// <summary>
        /// Get all nopCommerce customers
        /// </summary>
        /// <remarks>
        /// Response with active customers and those without system accounts.
        /// </remarks>
        [HttpGet]
        //[Authorize(ApiUserRoles = "Admin,User,Viewer")]
        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _customerService.GetAllAsync();
            return customers;
        }

        // get by id
        // GET: api/customer/{id}
        /// <summary>
        /// Get nopCommerce customer by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return customer;
        }

        // POST: api/customer/add-base-pl
        // Has tests
        /// <summary>
        /// Create nopCommerce customer for Poland.
        /// </summary>
        /// <remarks>
        /// Default nopCommerce customer role is Registered.
        /// </remarks>
        [HttpPost("pl")]
        public async Task<IActionResult> CreateBasePL([FromBody] CustomerPLCreateBaseDto createCustomerDto)
        {
            var customer = await _customerService.CreateBasePLAsync(createCustomerDto);
            return Created($"api/customer/{customer.Id}", customer);
        }

        // POST: api/customer/connect-with/address/{customerGuid}/{shippingAddressId}
        // Has tests
        /// <summary>
        /// Link the address to the nopCommerce customer. 
        /// </summary>
        /// <remarks>
        /// Connect to address only active customers and those without system accounts.
        /// </remarks>
        [HttpPost("connect/address/{customerGuid}/{shippingAddressId}")]
        public async Task<IActionResult> ConnectToAddress(Guid customerGuid, int shippingAddressId)
        {
            await _customerService.ConnectToAddressAsync(customerGuid, shippingAddressId);

            return Created();
        }

        /// <summary>
        /// Update customer PL
        /// </summary>
        /// <remarks>
        /// Update only active customers and those without system accounts. \
        /// Update without password, password can be updated by separate endpoint.
        /// </remarks>
        [HttpPut("update/pl")]
        public async Task<IActionResult> UpdateBasePL(CustomerPLUpdateDto updateCustomerDto)
        {
            var customerDto = await _customerService.UpdatePLAsync(updateCustomerDto);

            return Ok(customerDto);
        }

        /// <summary>
        /// Update customer password
        /// </summary>
        /// <remarks>
        /// Update password only active customers and those without system accounts. \
        /// The password does not update by default in nopCOMmerce, it adds a new one while leaving the old one
        /// </remarks>
        [HttpPut("update/password/{customerGuid}")]
        public async Task<IActionResult> UpdatePassword(Guid customerGuid, [FromBody] Password newPassword )
        {
            var result = await _customerService.UpdatePasswordAsync(customerGuid, newPassword.password);
            if (!result)
            {
                throw new BadRequestException("Password update failed");
            }

            return Ok(result);
        }

    }
}
