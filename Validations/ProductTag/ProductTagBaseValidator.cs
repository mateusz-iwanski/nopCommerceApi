using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductTag;
using nopCommerceApi.Models.ProductVideo;

namespace nopCommerceApi.Validations.ProductTag
{
    public class ProductTagBaseValidator<T> : BaseValidator<T> where T : ProductTagDto
    {
        protected readonly NopCommerceContext _context;

        public ProductTagBaseValidator(NopCommerceContext context)
        {
            _context = context;
        }
    }
}
