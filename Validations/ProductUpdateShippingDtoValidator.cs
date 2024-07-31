using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Validations
{
    public class ProductUpdateShippingDtoValidator : BaseValidator<ProductUpdateShippingDto>
    {
        private readonly NopCommerceContext _context;
        public ProductUpdateShippingDtoValidator(NopCommerceContext context) : base()
        {
            _context = context;

            // check that delivery date exists
            RuleFor(x => x.DeliveryDateId)
                .Must(
                deliveryDateId => _context.DeliveryDates.Any(c => c.Id == deliveryDateId) 
                || deliveryDateId == 0
                )
                .WithMessage("The delivery date does not exist.");
        }
    }
}
