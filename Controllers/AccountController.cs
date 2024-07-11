using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.User;
using nopCommerceApi.Services.User;

namespace nopCommerceApi.Controllers
{
    /// <summary>
    /// It's a controller class for account related operations
    /// 
    /// Account controller is responsible for handling the incoming 
    /// HTTP requests for the account related operations. 
    /// Every operations On this controller will be store in json file. 
    /// This controller will not use entities for storing data.
    /// </summary>
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {
            _accountService.RegisterUser(registerUserDto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto loginDto)
        {
            string token = _accountService.GenerateJwt(loginDto);
            return Ok(token);
        }
    }
}
