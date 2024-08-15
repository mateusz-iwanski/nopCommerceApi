using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.SpecificationAttribute;
using nopCommerceApi.Models.TierPrice;

namespace nopCommerceApi.Validations.TierPrice
{
    public class TierPriceBaseDtoValidator<T> : BaseValidator<T> where T : TierPriceDto
    {
        protected readonly NopCommerceContext context;

        public TierPriceBaseDtoValidator(NopCommerceContext _context)
        {
            context = _context;

            // check if cutomerroleid exists
            RuleFor(x => x.CustomerRoleId)
                .Must(customerRoleId =>
                {
                    return context.CustomerRoles.Any(cr => cr.Id == customerRoleId || customerRoleId == null);
                })
                .WithMessage("The customer role id is not exists.");

            // check if product exists
            RuleFor(x => x.ProductId)
                .Must(productId =>
                {
                    return context.Products.Any(p => p.Id == productId);
                })
                .WithMessage("The product id is not exists.");

            // check if store exists
            RuleFor(x => x.StoreId)
                .Must(storeId =>
                {
                    return context.Stores.Any(s => s.Id == storeId || storeId == 0);
                })
                .WithMessage("The store id is not exists.");

            // check if price is greater than 0
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("The price must be greater than 0.");

            // check if quantity is greater or equal 0
            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The quantity must be greater or equal to 0.");

        }

    }
}
