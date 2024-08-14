using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttributeValue;
using nopCommerceApi.Models.ProductAvailabilityRange;

namespace nopCommerceApi.Validations.ProductAvailabilityRange
{
    public class ProductAvailabilityRangeCreateDtoValidator: BaseValidator<ProductAvailabilityRangeCreateDto>
    {
        private readonly NopCommerceContext _context;
        private readonly IMySettings _settings;

        public ProductAvailabilityRangeCreateDtoValidator(NopCommerceContext context, IMySettings settings)
        {
            _context = context;
            _settings = settings;

            // name should be unique
            RuleFor(x => x.Name)
                .Must((name) => !_context.ProductAvailabilityRanges.Any(p => p.Name == name))
                .WithMessage("The name already exists.");
        }
    }
}
