using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;

namespace nopCommerceApi.Seeder
{
    /// <summary>
    /// Add basic customer roles to the database on startup
    /// </summary>
    public class CustomerRolesSeeder
    {
        private readonly NopCommerceContext _context;

        public CustomerRolesSeeder(NopCommerceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Check if basic customer roles exist in the database and add them if they don't
        /// </summary>
        public void SeedBasic()
        {
            if (_context.CustomerRoles.Count() == 0)
            {
                if (_context.CustomerRoles.FirstOrDefault(a => a.Name == "Administrators") == null)
                    _context.CustomerRoles.Add(
                        new CustomerRole { Name = "Administrators", SystemName = "Administrators" }
                    );

                if (_context.CustomerRoles.FirstOrDefault(a => a.Name == "Registered") == null)
                    _context.CustomerRoles.Add(
                        new CustomerRole { Name = "Registered", SystemName = "Registered" }
                    );

                if (_context.CustomerRoles.FirstOrDefault(a => a.Name == "Guests") == null)
                    _context.CustomerRoles.Add(
                        new CustomerRole { Name = "Guests", SystemName = "Guests" }
                    );

                if (_context.CustomerRoles.FirstOrDefault(a => a.Name == "Guests") == null)
                    _context.CustomerRoles.Add(
                        new CustomerRole { Name = "Vendors", SystemName = "Vendors" }
                    );

                _context.SaveChanges();
            }
        }
    }
}
