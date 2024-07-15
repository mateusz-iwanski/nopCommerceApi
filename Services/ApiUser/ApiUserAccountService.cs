using Config.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.User;
using System.Drawing.Printing;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;

namespace nopCommerceApi.Services.User
{
    public interface IAccountService
    {
        void RegisterUser(RegisterApiUserDto registerUserDto);
        string GenerateJwt(LoginApiUserDto loginDto);
    }

    /// <summary>
    /// Service for maintaining the list of authorization users
    /// </summary>
    public class ApiUserAccountService : IAccountService
    {
        private readonly NopCommerceContext _context;
        private readonly IMySettings _settings;
        private readonly IPasswordHasher<ApiUserDto> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public ApiUserAccountService(NopCommerceContext nopCommerceContext, IMySettings mySettings, IPasswordHasher<ApiUserDto> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _context = nopCommerceContext;
            _settings = mySettings; 
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        /// <summary>
        /// Saving the user from DTO to the json file
        /// </summary>
        public void RegisterUser(RegisterApiUserDto registerUserDto)
        {
            // Create a new user
            var user = new ApiUserDto(name: registerUserDto.Name, email: registerUserDto.Email, passwordHash: registerUserDto.PasswordHash, roleName: registerUserDto.Role);

            // Hash the password and set to user
            var hashedPassword = _passwordHasher.HashPassword(user, user.PasswordHash);
            user.PasswordHash = hashedPassword;

            var users = ApiUserService.GetUsersFromJson(_settings.UsersFilePath);

            if (users != null)
            {

                if (users.Any(u => u.Email == user.Email))
                {
                    throw new BadRequestException("Email should be unique");
                }
                users.Add(user);
                File.WriteAllText(
                    _settings.UsersFilePath,
                    JsonConvert.SerializeObject(users, Formatting.Indented)
                    );
            }
            else
            {
                // Append JSON string to the end of the file
                File.WriteAllText(
                    _settings.UsersFilePath,
                    JsonConvert.SerializeObject(new List<ApiUserDto>() { user }, Formatting.Indented)
                    );
            }
        }

        /// <summary>
        /// JWT generation for the user authentication
        /// </summary>
        public string GenerateJwt(LoginApiUserDto loginDto)
        {
            var users = ApiUserService.GetUsersFromJson(_settings.UsersFilePath);

            if (users == null) throw new NotFoundExceptions("No users found");

            var user = users.FirstOrDefault(u => u.Email == loginDto.Email);    

            if (user == null) throw new BadRequestException("Invalid username or passowrd");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
            
            if (result == PasswordVerificationResult.Failed) throw new BadRequestException("Invalid username or passowrd");

            // data for JWT token            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_authenticationSettings.JwtExpireDays));

            // create JWT token
            var token = new JwtSecurityToken(
                _authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);  
        }
    }
}
