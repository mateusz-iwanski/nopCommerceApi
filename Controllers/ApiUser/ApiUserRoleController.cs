using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Models.User;

namespace nopCommerceApi.Controllers.User
{
    /// <summary>
    /// Role controller is only responsible to get all roles
    /// 
    /// Role is an enum which contains all the roles that are available in the system.
    /// We can't add/update/delete roles from the API. It's a fixed set of roles.
    /// </summary>
    [Route("api/api-user-role")]
    [ApiController]
    public class ApiUserRoleController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAll()
        {
            // return all roles as list in table
            var roles = Enum.GetValues(typeof(ApiUserRoles))
                           .Cast<ApiUserRoles>()
                           .Select(role => new
                           {
                               Name = role.ToString(),
                               Value = (int)role
                           });
            return Ok(roles);
        }
    }
}
