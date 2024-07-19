using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models;

namespace nopCommerceApi.Seeder
{
    /// <summary>
    /// Seed main TaxCategory for Poland
    /// </summary>
    public class TaxCategorySeeder
    {
        private readonly NopCommerceContext _context;
        private readonly string _defaultTaxCategoryNamePL23 = "PL-23% (Podstawowa)";
        private readonly string _defaultTaxCategoryNamePL8 = "PL-8% (Podstawowa)";

        public TaxCategorySeeder(NopCommerceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get last display order number
        /// </summary>
        public int GetLastDisplayOrder()
        {
            var lastTaxCategory = _context.TaxCategories.OrderByDescending(d => d.DisplayOrder).FirstOrDefault();

            if (lastTaxCategory == null)
            {
                return 0;
            }

            return lastTaxCategory.DisplayOrder;
        }

        public void SeedPL()
        {
            if (_context.Database.CanConnect())
            {
                var standardPL23 = _context.TaxCategories.FirstOrDefault(c => c.Name == _defaultTaxCategoryNamePL23);
                var standardPL8 = _context.TaxCategories.FirstOrDefault(c => c.Name == _defaultTaxCategoryNamePL8);

                if (standardPL23 == null)
                {
                    var taxCategory = new TaxCategory
                    {
                        Name = _defaultTaxCategoryNamePL23,
                        DisplayOrder = GetLastDisplayOrder() == 0 ? 0 : GetLastDisplayOrder() + 1

                    };
                    _context.TaxCategories.Add(taxCategory);
                    _context.SaveChanges();
                }

                if (standardPL8 == null)
                {
                    var taxCategory = new TaxCategory
                    {
                        Name = _defaultTaxCategoryNamePL8,
                        DisplayOrder = GetLastDisplayOrder() == 0 ? 0 : GetLastDisplayOrder() + 1

                    };
                    _context.TaxCategories.Add(taxCategory);
                    _context.SaveChanges();
                }

            }
        }

    }
}
