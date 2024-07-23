using FluentValidation;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;

namespace nopCommerceApi.Validations
{
    public class CreateAddressDtoValidator : BaseValidator<AddressCreateDto>
    {
        private readonly NopCommerceContext _context;

        public CreateAddressDtoValidator(NopCommerceContext context)
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
        }
    }
}
