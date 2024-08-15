using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.TierPrice;

namespace nopCommerceApi.Validations.TierPrice
{
    public class TierPriceCreateDtoValidator : TierPriceBaseDtoValidator<TierPriceCreateDto>
    {
        public TierPriceCreateDtoValidator(NopCommerceContext context) : base(context)
        {
            // check if CustomerRoleId, ProductId, StoreId, StartDateTimeUtc, EndDateTimeUtc exists in database
            RuleFor(x => x)
                .Must(tierPrice =>
                {
                    return !context.TierPrices.Any(tp => 
                        tp.CustomerRoleId == tierPrice.CustomerRoleId && 
                        tp.ProductId == tierPrice.ProductId && 
                        tp.StoreId == tierPrice.StoreId && 
                        tp.StartDateTimeUtc == tierPrice.StartDateTimeUtc && 
                        tp.EndDateTimeUtc == tierPrice.EndDateTimeUtc);
                })
                .WithMessage("The tier price already exists.");

        }
    }
}
