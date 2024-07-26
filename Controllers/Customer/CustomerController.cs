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
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customer
        /// <summary>
        /// Get all nopCommerce customers
        /// </summary>
        [HttpGet]
        //[Authorize(ApiUserRoles = "Admin,User,Viewer")]
        public IEnumerable<CustomerDto> GetAll()
        {
            var customers = _customerService.GetAll();
            return customers;
        }

        // POST: api/customer/add-base-pl
        // Has tests
        /// <summary>
        /// Create nopCommerce customer for Poland.
        /// </summary>
        /// <remarks>
        /// Default nopCommerce customer role is Registered.
        /// </remarks>
        [HttpPost("add-base-pl")]
        public IActionResult CreateBasePL([FromBody] CustomerCreateBaseDto createCustomerDto)
        {
            var customer = _customerService.CreateBasePL(createCustomerDto);
            return Ok(customer);
        }

        // POST: api/customer/connect-with/address/{customerGuid}/{shippingAddressId}
        // Has tests
        /// <summary>
        /// Link the address to the nopCommerce customer
        /// </summary>
        [HttpPost("connect-with/address/{customerGuid}/{shippingAddressId}")]
        public IActionResult ConnectToAddress(Guid customerGuid, int shippingAddressId)
        {
            if(!_customerService.ConnectToAddress(customerGuid, shippingAddressId))
                throw new BadRequestException("Customer or address not found.");
            return Created();
        }
    }
}
