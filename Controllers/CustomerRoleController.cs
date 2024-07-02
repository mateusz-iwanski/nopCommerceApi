using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using nopCommerceApi.Services;


namespace nopCommerceApi.Controllers
{
    [Route("api/customerrole")]
    public class CustomerRoleController : ControllerBase
    {
        private readonly ICustomerRoleService _customerRoleService;

        public CustomerRoleController(ICustomerRoleService customerRoleService)
        {
            _customerRoleService = customerRoleService;
        }

        [HttpGet]
        public ActionResult<CustomerRole> GetAll()
        {
            var customerRoleDtos = _customerRoleService.GetAll();   
            return Ok(customerRoleDtos);
        }
    }
}
