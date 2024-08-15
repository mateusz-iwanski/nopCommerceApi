using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductTag;

namespace nopCommerceApi.Validations.ProductTag
{
    public class ProductTagUpdateValidator : ProductTagBaseValidator<ProductTagUpdateDto>
    {
        public ProductTagUpdateValidator(NopCommerceContext context) : base(context)
        {
            // check if id exists
            RuleFor(x => x.Id)
                .Must((id) => _context.ProductTags.Find(id) != null)
                .WithMessage("The id does not exist.");
        }
    }
}
