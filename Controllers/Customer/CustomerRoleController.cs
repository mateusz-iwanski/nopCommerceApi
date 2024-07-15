﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using nopCommerceApi.Services.Customer;

namespace nopCommerceApi.Controllers.Customer
{
    [Route("api/customer-role")]
    [ApiController]
    public class CustomerRoleController : ControllerBase
    {
        private readonly ICustomerRoleService _customerRoleService;

        public CustomerRoleController(ICustomerRoleService customerRoleService)
        {
            _customerRoleService = customerRoleService;
        }

        [HttpGet]
        //[Authorize(ApiUserRoles = "Admin,User,Viewer")]
        public ActionResult<CustomerRole> GetAll()
        {
            var customerRoleDtos = _customerRoleService.GetAll();
            return Ok(customerRoleDtos);
        }
    }
}