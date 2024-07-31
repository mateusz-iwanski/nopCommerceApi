using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Validations
{
    public class ProductUpdateBlockShippingDtoValidator : BaseValidator<ProductUpdateBlockShippingDto>
    {
        private readonly NopCommerceContext _context;
        public ProductUpdateBlockShippingDtoValidator(NopCommerceContext context) : base()
        {
            _context = context;

            // check that delivery date exists
            RuleFor(x => x.DeliveryDateId)
                .Must(
                deliveryDateId => _context.DeliveryDates.Any(c => c.Id == deliveryDateId) 
                || deliveryDateId == 0
                )
                .WithMessage("The delivery date does not exist.");

            RuleFor(x => x.Weight)
                .GreaterThanOrEqualTo(0).WithMessage("Weight must be greater or equal 0.");

            RuleFor(x => x.Length)
                .GreaterThanOrEqualTo(0).WithMessage("Length must be greater or equal 0.");

            RuleFor(x => x.Width)
                .GreaterThanOrEqualTo(0).WithMessage("Width must be greater or equal 0.");

            RuleFor(x => x.Height)
                .GreaterThanOrEqualTo(0).WithMessage("Height must be greater or equal 0.");
        }
    }
}
