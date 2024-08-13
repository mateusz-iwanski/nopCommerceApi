using FluentValidation;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;

namespace nopCommerceApi.Validations.Address
{
    public class AddressCreateDtoValidator : BaseValidator<AddressCreateDto>
    {
        private readonly NopCommerceContext _context;

        public AddressCreateDtoValidator(NopCommerceContext context)
        {
            _context = context;

            // Validate if the country exists
            RuleFor(x => x.CountryId)
                .NotEmpty()
                .Must((country, cancellation) =>
                {
                    return _context.Countries.Any(c => c.Id == country.CountryId);
                })
                .WithMessage("The country does not exist.");

            // check state province exists
            RuleFor(x => x.StateProvinceId)
                .Must((stateProvince, cancellation) =>
                {
                    return stateProvince.StateProvinceId == null || _context.StateProvinces.Any(sp => sp.Id == stateProvince.StateProvinceId);
                })
                .WithMessage("The state province does not exist.");
        }
    }
}
