using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttribute;
using nopCommerceApi.Models.ProductCategory;

namespace nopCommerceApi.Validations.ProductCategory
{
    public class ProductCategoryMappingBaseValidator<T> : BaseValidator<T> where T : ProductCategoryMappingDto
    {
        protected readonly IMySettings _settings;
        protected readonly NopCommerceContext _context;

        public ProductCategoryMappingBaseValidator(NopCommerceContext context, IMySettings settings)
        {
            _context = context;
            _settings = settings;

            // chaeck if category exists
            RuleFor(x => x.CategoryId)
                .Must(categoryId => _context.Categories.Any(c => c.Id == categoryId))
                .WithMessage("The category does not exist.");

            // chaeck if product exists
            RuleFor(x => x.ProductId)
                .Must(productId => _context.Products.Any(c => c.Id == productId))
                .WithMessage("The product does not exist.");
        }   
    }
}
