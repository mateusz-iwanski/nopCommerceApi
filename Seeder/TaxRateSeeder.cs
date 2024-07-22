using nopCommerceApi.Entities;
using nopCommerceApi.Entities.NotUsable;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Services;

namespace nopCommerceApi.Seeder
{
    /// <summary>
    /// Add default tax rates to the database on startup
    /// </summary>
    public class TaxRateSeeder
    {
        private readonly NopCommerceContext _context;
        private readonly ITaxCategoryService _taxCategoryService;

        public TaxRateSeeder(NopCommerceContext context, ITaxCategoryService taxCategoryService)
        {
            _context = context;
            _taxCategoryService = taxCategoryService;
        }

        public void Seed()
        {
            var country = _context.Countries.FirstOrDefault(c => c.Name == "Poland");
            var countryId = country?.Id ?? throw new BadRequestException("Country \"Poland\" not exist. Add to database.");

            var taxCategory23 = _context.TaxCategories.FirstOrDefault(tc => tc.Name == "PL-23% (Podstawowa)");
            var taxCategory23Id = taxCategory23?.Id ?? throw new BadRequestException("Default tax category \"PL-23% (Podstawowa) not exists\", use TaxCategorySeeder.");
            if (!_context.TaxRates.Any(tr => tr.TaxCategoryId == taxCategory23Id && tr.CountryId == countryId))
            {
                var taxRate23 = new TaxRate
                {
                    StoreId = 0,
                    TaxCategoryId = taxCategory23Id,
                    CountryId = countryId,
                    StateProvinceId = 0,
                    Percentage = 23,
                };
                _context.TaxRates.Add(taxRate23);
                _context.SaveChanges();
            }


            var taxCategory8 = _context.TaxCategories.FirstOrDefault(tc => tc.Name == "PL-8% (Podstawowa)");
            var taxCategory8Id = taxCategory8?.Id ?? throw new BadRequestException("Default tax category \"PL-8% (Podstawowa) not exists\", use TaxCategorySeeder.");
            if (!_context.TaxRates.Any(tr => tr.TaxCategoryId == taxCategory8Id && tr.CountryId == countryId))
            {
                var taxRate23 = new TaxRate
                {
                    StoreId = 0,
                    TaxCategoryId = taxCategory8Id,
                    CountryId = countryId,
                    StateProvinceId = 0,
                    Percentage = 23,
                };
                _context.TaxRates.Add(taxRate23);
                _context.SaveChanges();
            }

        }
    }
}
