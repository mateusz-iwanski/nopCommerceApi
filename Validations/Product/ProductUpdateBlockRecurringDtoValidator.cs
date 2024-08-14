using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Validations
{
    public class ProductUpdateBlockRecurringDtoValidator : BaseValidator<ProductUpdateBlockRecurringDto>
    {
        private readonly IMySettings _settings;

        public ProductUpdateBlockRecurringDtoValidator(IMySettings settings) : base()
        {
            _settings = settings;

            // RecurringProductCyclePeriod (enum) is required
            // compare with appsettings.ini RecurringProductCyclePeriodAvailableId
            RuleFor(x => x.RecurringCyclePeriodId)
                .Must(recurringProductCyclePeriodId =>
                {
                    if (_settings.RecurringProductCyclePeriodAvailableId == recurringProductCyclePeriodId)
                        return true;
                    return false;
                })
                .WithMessage("The recurring product cycle period does not exist.");
        }
    }
}
