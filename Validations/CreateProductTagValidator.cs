using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Validations
{
    public class CreateProductTagValidator : BaseValidator<ProductTagCreateDto>
    {
        private readonly NopCommerceContext _context;

        public CreateProductTagValidator(NopCommerceContext context)
        {
            _context = context;

            RuleFor(x => x.Name)                
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(400)
                .WithMessage("Name must not exceed 400 characters");
            ;
        }
    }
}
