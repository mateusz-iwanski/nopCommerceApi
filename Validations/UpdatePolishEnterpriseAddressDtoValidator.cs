using FluentValidation;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;
using System.Reflection.Metadata;
using System.Xml;

namespace nopCommerceApi.Validations
{
    public class UpdatePolishEnterpriseAddressDtoValidator : BaseValidator<UpdatePolishEnterpriseAddressDto>
    {
        private readonly NopCommerceContext _context;

        /// <summary>
        /// Validates the address DTO.
        /// </summary>
        public UpdatePolishEnterpriseAddressDtoValidator(NopCommerceContext context)
        {
            _context = context;

            // Validate nip format
            RuleFor(x => x.Nip)
                .MaximumLength(12)
                .Matches(@"^((PL)?[0-9]{10})$")
                .WithMessage("The NIP format is invalid. Properly format is with/without prefix \"PL\" and 10 digits. Can't be empty, if you don't want to update, just remove from body.");

            // Validate empty properties 

            RuleFor(x => x.Company)
                .Must(company => company == null || !string.IsNullOrWhiteSpace(company))
                .WithMessage("The Company name can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.City)
                .Must(city => city == null || !string.IsNullOrWhiteSpace(city))
                .WithMessage("The City name can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.Address1)
                .Must(address => address == null || !string.IsNullOrWhiteSpace(address))
                .WithMessage("The Address1 name can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.PhoneNumber)
                .Must(phoneNumber => phoneNumber == null || !string.IsNullOrWhiteSpace(phoneNumber))
                .WithMessage("The PhoneNumber name can't be empty. If you don't want to update, just remove from body.");
        }
    }
}

