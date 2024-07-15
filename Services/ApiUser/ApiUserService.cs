using Newtonsoft.Json;
using nopCommerceApi.Config;
using nopCommerceApi.Models.User;
using System.Collections.Generic;

namespace nopCommerceApi.Services.User
{
    public interface IUserService {}

    public class ApiUserService : IUserService
    {
        private readonly IMySettings _settings;
        public ApiUserService(IMySettings settings) 
        { 
            _settings = settings;
        }

        public static List<ApiUserDto> GetUsersFromJson(string filePath)
        {            

            if (!File.Exists(filePath))
                return null;

            string jsonContent = File.ReadAllText(filePath);
            var users = JsonConvert.DeserializeObject<List<ApiUserDto>>(jsonContent);
            
            return users;
        }
    }
}
