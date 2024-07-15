using nopCommerceApi.Exceptions;
using nopCommerceApi.Services;
using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.User
{
    /// <summary>
    /// Dto class which represents the user.
    /// 
    /// Object has character entities which are used to store user information.
    /// Data is stored in json format not in Database.
    /// </summary>

    public class ApiUserDto : BaseDto
    {
        private ApiUserRoles _role;
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(6)]
        public string PasswordHash { get; set; }
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
