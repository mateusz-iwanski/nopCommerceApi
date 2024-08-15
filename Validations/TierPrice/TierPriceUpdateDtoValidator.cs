using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.TierPrice;

namespace nopCommerceApi.Validations.TierPrice
{
    public class TierPriceUpdateDtoValidator : TierPriceBaseDtoValidator<TierPriceUpdateDto>
    {
        public TierPriceUpdateDtoValidator(NopCommerceContext context) : base(context)
        {
            // check if id exists in database
            RuleFor(x => x.Id)
                .Must(id =>
                {
                    return context.TierPrices.Any(tp => tp.Id == id);
                })
                .WithMessage("The tier price is not exists.");

            // check if CustomerRoleId, ProductId, StoreId, StartDateTimeUtc, EndDateTimeUtc exists in database
            // exclude updated object
            RuleFor(x => x)
                .Must(tierPrice =>
                {
                    return !context.TierPrices.Any(tp =>
                        tp.CustomerRoleId == tierPrice.CustomerRoleId &&
                        tp.ProductId == tierPrice.ProductId &&
                        tp.StoreId == tierPrice.StoreId &&
                        tp.StartDateTimeUtc == tierPrice.StartDateTimeUtc &&
                        tp.EndDateTimeUtc == tierPrice.EndDateTimeUtc &&
                        tp.Id != tierPrice.Id
                        );
                })
                .WithMessage("The tier price already exists.");
        }
    }
}
