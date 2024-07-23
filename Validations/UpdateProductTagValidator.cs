using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Validations
{
    public class UpdateProductTagValidator : BaseValidator<ProductTagUpdateDto>
    {
        public UpdateProductTagValidator(NopCommerceContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(400)
                .WithMessage("Name must not exceed 400 characters");
        }
    }
}
