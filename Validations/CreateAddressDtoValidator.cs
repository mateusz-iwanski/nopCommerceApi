using FluentValidation;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;

namespace nopCommerceApi.Validations
{
    public class CreateAddressDtoValidator : BaseValidator<CreateAddressDto>
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

            // Validate if the email already exists in the database, has to be unique
            // this will be only for Customer
            //RuleFor(x => x.Email)
            //    .Must(email =>
            //    {
            //        var addresses = _context.Addresses.ToList();
            //        var filteredAddresses = addresses.Where(addr => addr.Email == email).ToList();

            //        return filteredAddresses.Count == 0 ? true : false;
            //    })
            //    .WithMessage("The Email already exists in the database.");
        }
    }
}
