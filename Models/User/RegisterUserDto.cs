using nopCommerceApi.Exceptions;
using nopCommerceApi.Services;
using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.User
{
    /// <summary>
    /// Dto class for registering a new user
    /// </summary>
    public class RegisterUserDto
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(6)]
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
