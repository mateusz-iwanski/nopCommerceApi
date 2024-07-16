﻿using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.Services
{
    public interface ITaxCategoryService
    {
        IEnumerable<TaxCategoryDto> GetAll();
        int GetLastDisplayOrder();
    }

    public class TaxCategoryService : ITaxCategoryService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

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
    }
}
