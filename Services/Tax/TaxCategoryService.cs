using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.Services
{
    public interface ITaxCategoryService
    {
        IEnumerable<TaxCategoryDto> GetAll();
        int GetLastDisplayOrder();
        void AddDefaultTaxCategoryPL23();
        void AddDefaultTaxCategoryPL8();
    }

    public class TaxCategoryService : ITaxCategoryService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        private readonly string _defaultTaxCategoryNamePl23 = "PL-23% (Podstawowa)";
        private readonly string _defaultTaxCategoryNamePl8 = "PL-8% (Podstawowa)";

        public TaxCategoryService(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<TaxCategoryDto> GetAll()
        {
            var taxCategories = _context.TaxCategories.ToList();
            var taxCategoryDtos = _mapper.Map<List<TaxCategoryDto>>(taxCategories);

            return taxCategoryDtos;
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

        /// <summary>
        /// For Polish customers, add default tax category 23%
        /// </summary>
        public void AddDefaultTaxCategoryPL23()
        {
            var standardPl = _context.TaxCategories.FirstOrDefault(c => c.Name == _defaultTaxCategoryNamePl23);
            if (standardPl == null)
            {
                var taxCategoryDto = new TaxCategoryDto
                {
                    Name = _defaultTaxCategoryNamePl23,                    
                    DisplayOrder = GetLastDisplayOrder() == 0 ? 0 : GetLastDisplayOrder() + 1
                };

                var taxCategory = _mapper.Map<TaxCategory>(taxCategoryDto);

                _context.TaxCategories.Add(taxCategory);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// For Polish customers, add default tax category 8%
        /// </summary>
        public void AddDefaultTaxCategoryPL8()
        {
            var standardPl = _context.TaxCategories.FirstOrDefault(c => c.Name == _defaultTaxCategoryNamePl8);
            if (standardPl == null)
            {
                var taxCategoryDto = new TaxCategoryDto
                {
                    Name = _defaultTaxCategoryNamePl8,
                    DisplayOrder = GetLastDisplayOrder() == 0 ? 0 : GetLastDisplayOrder() + 1
                };

                var taxCategory = _mapper.Map<TaxCategory>(taxCategoryDto);

                _context.TaxCategories.Add(taxCategory);
                _context.SaveChanges();
            }
        }
    }
}
