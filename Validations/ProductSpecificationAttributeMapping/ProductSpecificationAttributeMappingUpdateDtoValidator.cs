using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductSpecificationAttributeMapping;

namespace nopCommerceApi.Validations.ProductSpecificationAttributeMapping
{
    public class ProductSpecificationAttributeMappingUpdateDtoValidator : ProductSpecificationAttributeMappingBaseDtoValidator<ProductSpecificationAttributeMappingUpdateDto>
    {
        public ProductSpecificationAttributeMappingUpdateDtoValidator(NopCommerceContext context) : base(context)
        {
            // check id exists
            RuleFor(x => x.Id)
                .Must(x => _context.ProductSpecificationAttributeMappings.Find(x) != null)
                .WithMessage("Product specification attribute mapping id does not exist");

            // check if product id and specification attribute option id combination exists, exclude the current mapping
            RuleFor(x => new { x.ProductId, x.SpecificationAttributeOptionId, x.Id})
                .Must(x => _context.ProductSpecificationAttributeMappings.FirstOrDefault(
                    psam => x.ProductId == psam.ProductId && x.SpecificationAttributeOptionId == psam.SpecificationAttributeOptionId && x.Id != psam.Id) == null
                    )
                .WithMessage("Product id and specification attribute option id combination already exists");
        }
    }
}
