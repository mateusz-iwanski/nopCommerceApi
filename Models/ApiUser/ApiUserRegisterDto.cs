using nopCommerceApi.Exceptions;
using nopCommerceApi.Services;
using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.User
{
    /// <summary>
    /// Dto class for registering a new user
    /// </summary>
    public class ApiUserRegisterDto : BaseDto
    {
        /// <summary>
        /// Register name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Register email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Register password (min. length 6)
        /// </summary>
        [Required]
        [MinLength(6)]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Register role
        /// </summary>
        [Required]
        public string Role { get; set; }
    }
}
