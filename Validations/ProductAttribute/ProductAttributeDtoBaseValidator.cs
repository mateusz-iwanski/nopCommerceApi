using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttribute;

namespace nopCommerceApi.Validations.ProductAttribute
{    
    public class ProductAttributeDtoBaseValidator<T> : BaseValidator<T> where T : ProductAttributeDto
    {
        protected readonly NopCommerceContext _context;
        
        public ProductAttributeDtoBaseValidator(NopCommerceContext context)
        {
            _context = context;
        }
    }
}
