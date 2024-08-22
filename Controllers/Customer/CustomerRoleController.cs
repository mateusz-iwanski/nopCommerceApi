using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models;
using nopCommerceApi.Services.Customer;

namespace nopCommerceApi.Controllers.Customer
{
    [Route("api/customer/role")]
    [ApiController]
    public class CustomerRoleController : ControllerBase
    {
        private readonly ICustomerRoleService _customerRoleService;

        public CustomerRoleController(ICustomerRoleService customerRoleService)
        {
            _customerRoleService = customerRoleService;
        }

        /// <summary>
        /// Get all nopCommerce customer roles
        /// </summary>
        /// <remarks>
        /// The customer roles in nopCommerce enable you to form groups of your web store users. \
        /// You can create various groups, such as store admins, shoppers, vendors, and others. \
        /// \
        /// If you don't need this option just leave this field empty. \
        /// In order to use this functionality, you have to disable the following \
        /// setting: Configuration > Settings > Catalog > Ignore ACL rules (sitewide).
        /// </remarks>
        [HttpGet]
        //[Authorize(ApiUserRoles = "Admin,User,Viewer")]
        public async Task<ActionResult<CustomerRole>> GetAll()
        {
            var customerRoleDtos = await _customerRoleService.GetAllAsync();
            return Ok(customerRoleDtos);
        }
    }
}
