using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttribute;
using nopCommerceApi.Models.ProductCategory;
using nopCommerceApi.Validations.ProductAttribute;

namespace nopCommerceApi.Validations.ProductCategory
{
    public class ProductCategoryMappingCreateValidator : ProductCategoryMappingBaseValidator<ProductCategoryMappingCreateDto>
    {
        public ProductCategoryMappingCreateValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
            // category id and product id should be unique
            RuleFor(x => new { x.CategoryId, x.ProductId })
                .Must(x => !_context.ProductCategoryMappings.Any(c => c.CategoryId == x.CategoryId && c.ProductId == x.ProductId))
                .WithMessage("The product category mapping already exists.");
        }
    }
}
