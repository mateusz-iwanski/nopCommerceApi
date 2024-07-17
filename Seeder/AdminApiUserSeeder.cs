using nopCommerceApi.Entities;
using nopCommerceApi.Models.User;
using nopCommerceApi.Services.User;

namespace nopCommerceApi.Seeder
{
    /// <summary>
    /// Create a default administrator user when you start the application when it doesn't exist
    /// 
    /// It creates in users.json file
    /// </summary>
    public class AdminApiUserSeeder
    {
        private readonly NopCommerceContext _context;
        private readonly IApiUserAccountService _apiUserAccountService;

        public AdminApiUserSeeder(NopCommerceContext context, IApiUserAccountService apiUserAccountService)
        {
            _context = context;
            _apiUserAccountService = apiUserAccountService;
        }

        public void Seed()
        {
            _apiUserAccountService.RegisterUser(
                new RegisterApiUserDto
                {
                        Name = "Admin",
                        Email = "admin@admin.com",
                        PasswordHash = "admin",
                        Role = "Admin"
                });
        }
    }
}
