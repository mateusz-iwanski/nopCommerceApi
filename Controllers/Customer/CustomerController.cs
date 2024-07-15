using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        //[Authorize(Roles = "Admin,User,Viewer")]
        public IEnumerable<CustomerDto> GetAll()
        {
            var customers = _customerService.GetAll();
            return customers;
        }
    }
}
