using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Validations
{
    public class ProductUpdateGiftCardDtoValidator : BaseValidator<ProductUpdateGiftCardDto>
    {
        private readonly IMySettings _settings;

        public ProductUpdateGiftCardDtoValidator(IMySettings settings) : base()
        {
            _settings = settings;

            RuleFor(x => x.GiftCardTypeId)
                .Must(giftCardTypeId =>
                {
                    if (giftCardTypeId == null) return true;

                    if (_settings.GiftCardTypeAvailableId.Split(",").Select(x => int.Parse(x))
                         .Contains(giftCardTypeId))
                        return true;
                    return false;
                })
                .WithMessage("The gift card does not exist.");
        }
    }
}
