using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.User;
using nopCommerceApi.Services.User;
using System.Runtime;

namespace nopCommerceApi.Seeder
{
    /// <summary>
    /// Create a default administrator user when you start the application when it doesn't exist
    /// 
    /// It creates in users.json file
    /// </summary>
    public class AdminApiUserSeeder
    {
        private readonly string _adminName = "Admin";
        private readonly string _adminEmail = "admin@admin.com";
        private readonly string _adminPassword = "admin";
        private readonly string _adminRole = "Admin";


        private readonly NopCommerceContext _context;
        private readonly IApiUserAccountService _apiUserAccountService;
        private readonly IMySettings _settings;

        public AdminApiUserSeeder(NopCommerceContext context, IApiUserAccountService apiUserAccountService, IMySettings mySettings)
        {
            _context = context;
            _apiUserAccountService = apiUserAccountService;
            _settings = mySettings;
        }

        private void registerAdminUser()
        {
            _apiUserAccountService.RegisterUser(
                new RegisterApiUserDto
                {
                    Name = _adminName,
                    Email = _adminEmail,
                    PasswordHash = _adminPassword,
                    Role = _adminRole
                });
        }

        public void Seed()
        {
            var users = ApiUserService.GetUsersFromJson(_settings.UsersFilePath);

            if (users != null)
            {
                if (!users.Any(u => u.Email == _adminEmail))
                {
                    registerAdminUser();
                }
            }
        }
    }
}
