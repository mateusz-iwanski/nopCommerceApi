using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.User;
using nopCommerceApi.Services.User;

namespace nopCommerceApi.Controllers.User
{
    /// <summary>
    /// It's a controller class for account related operations
    /// 
    /// Account controller is responsible for handling the incoming 
    /// HTTP requests for the account related operations. 
    /// Every operations On this controller will be store in json file. 
    /// This controller will not use entities for storing data.
    /// </summary>
    [Route("api/api-user-account")]
    [ApiController]
    public class ApiUserAccountController : ControllerBase
    {
        private readonly IApiUserAccountService _accountService;

        public ApiUserAccountController(IApiUserAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Register API user        
        /// </summary>
        /// <remarks>
        /// API user registration is only allowed for the admin role.
        /// </remarks>
        [HttpPost("register")]
        //[Authorize(Roles = "Admin")]
        public ActionResult RegisterUser([FromBody] ApiUserRegisterDto registerUserDto)
        {
            _accountService.RegisterUser(registerUserDto);
            return Ok();
        }

        /// <summary>
        /// Login API user
        /// </summary>
        [HttpPost("login")]
        public ActionResult Login([FromBody] ApiUserLoginDto loginDto)
        {
            string token = _accountService.GenerateJwt(loginDto);
            return Ok(token);
        }
    }
}
