using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Validations
{
    public class ProductUpdateBlockRentalPriceDtoValidatior : BaseValidator<ProductUpdateBlockRentalPriceDto>
    {
        private readonly IMySettings _settings;

        public ProductUpdateBlockRentalPriceDtoValidatior(IMySettings settings) : base()
        {
            _settings = settings;

            // RentalPricePeriod (enum) is required
            // compare with appsettings.ini RentalPricePeriodAvailableId
            RuleFor(x => x.RentalPricePeriodId)
                .Must(rentalPricePeriodId =>
                {
                    if (_settings.RentalPricePeriodAvailableId == rentalPricePeriodId)
                        return true;
                    return false;
                })
                .WithMessage("The rental price period does not exist.");

        }
    }
}
