using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductCategory;

namespace nopCommerceApi.Validations.ProductCategory
{
    public class ProductCategoryMappingUpdateValidator : ProductCategoryMappingBaseValidator<ProductCategoryMappingUpdateDto>
    {
        public ProductCategoryMappingUpdateValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
            // check category id and product id not exists in ProductCategoryMapping but exclude the current mapping
            RuleFor(x => new { x.CategoryId, x.ProductId, x.Id })
                .Must(x => !_context.ProductCategoryMappings.Any(c => c.CategoryId == x.CategoryId && c.ProductId == x.ProductId && c.Id != x.Id))
                .WithMessage("The product category mapping already exists.");
        }
    }
}