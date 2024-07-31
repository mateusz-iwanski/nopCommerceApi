using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;
using System.Reflection;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Validations
{
    public class AddressUpdateDtoValidator : BaseValidator<AddressUpdateDto>
    {
        private readonly NopCommerceContext _context;

        public AddressUpdateDtoValidator(NopCommerceContext context)
        {
            _context = context;

            // Check if the country exists
            RuleFor(x => x.CountryId)
                .Must(countryId => countryId == null || _context.Countries.Any(c => c.Id == countryId))
                .WithMessage("ID of Country is incorrect, send correct ID.")
                .When(x => x.CountryId.HasValue);

            RuleFor(x => x.FirstName)
                .Must(firstName => firstName == null || !string.IsNullOrWhiteSpace(firstName))
                .WithMessage("The First Name can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.LastName)
                .Must(lastName => lastName == null || !string.IsNullOrWhiteSpace(lastName))
                .WithMessage("The Last Name can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.PhoneNumber)
                .Must(phoneNumber => phoneNumber == null || !string.IsNullOrWhiteSpace(phoneNumber))
                .WithMessage("The Phone number can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.CountryId)
                .Must(countryId => countryId == null || !string.IsNullOrWhiteSpace(countryId.ToString()))
                .WithMessage("The Country ID number can't be empty. If you don't want to update, just remove from body.");
        }

    }
}