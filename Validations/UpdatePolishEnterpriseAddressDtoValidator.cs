using FluentValidation;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;
using System.Reflection.Metadata;
using System.Xml;

namespace nopCommerceApi.Validations
{
    public class UpdatePolishEnterpriseAddressDtoValidator : AbstractValidator<UpdatePolishEnterpriseAddressDto>
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
                .WithMessage("The NIP format is invalid. Properly format is with/without prefix \"PL\" and 10 digits.");
        }


    }
}

