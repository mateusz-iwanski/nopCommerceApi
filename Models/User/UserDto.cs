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

    public class UserDto : BaseDto
    {
        private Roles _role;
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(6)]
        public string PasswordHash { get; set; }
        public Roles Role 
        {
            get => _role;
            set => _role = value;
        }

        public UserDto(){ return; }

        public UserDto(string name, string email, string passwordHash, string roleName)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            SetRoleByName(roleName);
        }

        public UserDto(string name, string email, string passwordHash, int role)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Role = (Roles)role;
        }

        private void SetRoleByName(string roleName)
        {
            if (Enum.TryParse<Roles>(roleName, out Roles role))
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
