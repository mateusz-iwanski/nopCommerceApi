using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.User
{
    /// <summary>
    /// User login Data Transfer Object for API
    /// </summary>
    public class ApiUserLoginDto
    {
        /// <summary>
        /// User email 
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
