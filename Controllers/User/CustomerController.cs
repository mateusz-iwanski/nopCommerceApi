using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.User;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers.User
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

        [HttpGet]
        [Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<CustomerDto> GetAll()
        {
            var customerDtos = _customerService.GetAll();
            return Ok(customerDtos);
        }
    }
}
