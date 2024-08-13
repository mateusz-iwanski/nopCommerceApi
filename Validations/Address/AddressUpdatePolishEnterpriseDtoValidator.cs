using FluentValidation;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;
using System.Reflection.Metadata;
using System.Xml;

namespace nopCommerceApi.Validations.Address
{
    public class AddressUpdatePolishEnterpriseDtoValidator : BaseValidator<AddressUpdatePolishEnterpriseDto>
    {
        private readonly NopCommerceContext _context;

        /// <summary>
        /// Validates the address DTO.
        /// </summary>
        public AddressUpdatePolishEnterpriseDtoValidator(NopCommerceContext context)
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

            // Validate nip format
            RuleFor(x => x.Nip)
                .MaximumLength(12)
                .Matches(@"^((PL)?[0-9]{10})$")
                .WithMessage("The NIP format is invalid. Properly format is with/without prefix \"PL\" and 10 digits. Can't be empty");

            // Validate if the NIP already exists in the database, exclude updated address
            RuleFor(x => new { x.Nip, x.Id } )
                .Must(obj =>
                {
                    var addresses = _context.Addresses.ToList();
                    var filteredAddresses = addresses.Where(addr => AddressDto.GetValueFromCustomAttribute(addr.CustomAttributes) == obj.Nip && addr.Id != obj.Id).ToList();

                    return filteredAddresses.Count == 0 ? true : false;
                })
                .WithMessage("The NIP already exists in the database.");

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

