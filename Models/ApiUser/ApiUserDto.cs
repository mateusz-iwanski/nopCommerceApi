using nopCommerceApi.Exceptions;
using nopCommerceApi.Services;
using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.User
{
    /// <summary>
    /// Dto class which represents the user.
    /// </summary>
    /// <remarks>
    /// Object has character entities which are used to store user information.
    /// Data is stored in json format not in Database.
    /// </remarks>


    public class ApiUserDto : BaseDto
    {
        private ApiUserRoles _role;

        /// <summary>
        /// Name of the user
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Email of the user
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Password hash of the user (min. length 6)
        /// </summary>
        [Required]
        [MinLength(6)]
        public string PasswordHash { get; set; }

        /// <summary>
        /// User role
        /// </summary>
        [Required]
        public ApiUserRoles Role 
        {
            get => _role;
            set => _role = value;
        }

        public ApiUserDto(){ return; }

        public ApiUserDto(string name, string email, string passwordHash, string roleName)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            SetRoleByName(roleName);
        }

        public ApiUserDto(string name, string email, string passwordHash, int role)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Role = (ApiUserRoles)role;
        }

        private void SetRoleByName(string roleName)
        {
            if (Enum.TryParse<ApiUserRoles>(roleName, out ApiUserRoles role))
            {
                _role = role;
            }
            else
            {
                throw new NotFoundExceptions("Invalid role name");
            }
        }
    }
    
}
