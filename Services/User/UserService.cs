using Newtonsoft.Json;
using nopCommerceApi.Config;
using nopCommerceApi.Models.User;
using System.Collections.Generic;

namespace nopCommerceApi.Services.User
{
    public interface IUserService {}

    public class UserService : IUserService
    {
        private readonly IMySettings _settings;
        public UserService(IMySettings settings) 
        { 
            _settings = settings;
        }

        public static List<UserDto> GetUsersFromJson(string filePath)
        {            

            if (!File.Exists(filePath))
                return null;

            string jsonContent = File.ReadAllText(filePath);
            var users = JsonConvert.DeserializeObject<List<UserDto>>(jsonContent);
            
            return users;
        }
    }
}
