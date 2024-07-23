using FluentValidation;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using nopCommerceApi.Models.Address;
using System.Reflection.Metadata;
using System.Xml;

namespace nopCommerceApi.Validations
{
    public class CreatePolishEnterpriseAddressDtoValidator : BaseValidator<AddressCreatePolishEnterpriseDto>
    {
        private readonly NopCommerceContext _context;

        /// <summary>
        /// Validates the address DTO.
        /// </summary>
        public CreatePolishEnterpriseAddressDtoValidator(NopCommerceContext context)
        {
            _context = context;

            // Validate nip format
            RuleFor(x => x.Nip)
                .NotEmpty()
                .MaximumLength(12)
                .Matches(@"^((PL)?[0-9]{10})$")
                .WithMessage("The NIP format is invalid. Properly format is with/without prefix \"PL\" and 10 digits.");

            // Validate if the NIP already exists in the database
            RuleFor(x => x.Nip)
                .Must(nip =>
                {
                    var addresses = _context.Addresses.ToList();
                    var filteredAddresses = addresses.Where(addr => AddressDto.GetValueFromCustomAttribute(addr.CustomAttributes) == nip).ToList();

                    return filteredAddresses.Count == 0 ? true : false;
                })
                .WithMessage("The NIP already exists in the database.");
        }


    }
}
