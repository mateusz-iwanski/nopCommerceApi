using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductSpecificationAttributeMapping;

namespace nopCommerceApi.Validations.ProductSpecificationAttributeMapping
{
    public class ProductSpecificationAttributeMappingCreateDtoValidator : ProductSpecificationAttributeMappingBaseDtoValidator<ProductSpecificationAttributeMappingCreateDto>
    {
        public ProductSpecificationAttributeMappingCreateDtoValidator(NopCommerceContext context) : base(context)
        {
            // check if product id and specification attribute option id combination exists
            RuleFor(x => new { x.ProductId, x.SpecificationAttributeOptionId, x.Id })
                .Must(x => _context.ProductSpecificationAttributeMappings.FirstOrDefault(
                    psam => x.ProductId == psam.ProductId && x.SpecificationAttributeOptionId == psam.SpecificationAttributeOptionId) == null
                    )
                .WithMessage("Product id and specification attribute option id combination already exists");
        }
    }
}
