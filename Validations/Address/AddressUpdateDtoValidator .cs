using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models.Address;
using System.Reflection;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Validations.Address
{
    public class AddressUpdateDtoValidator : BaseValidator<AddressUpdateDto>
    {
        private readonly NopCommerceContext _context;

        public AddressUpdateDtoValidator(NopCommerceContext context)
        {
            _context = context;

            // check id exists
            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(id =>
                {
                    return _context.Addresses.Any(a => a.Id == id);
                })
                .WithMessage("The address with the given id does not exist.");

            // Check if the country exists
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

            // If is enterprise address, can't update
            RuleFor(x => x.Id)
                .Must(id =>
                {
                    var address = _context.Addresses.Find(id);
                    return !AddressDto.IsEnterpriseAddress(address, _context.AddressAttributes);
                })
                .WithMessage("Address is enterprise, can not update. Use update-with-nip enterprise addresses.");
        }

    }
}