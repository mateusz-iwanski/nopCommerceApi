using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Manufacturer;

namespace nopCommerceApi.Validations.Manufacturer
{
    public class ManufacturerCreateDtoValidator : ManufacturerBaseDtoValidator<ManufacturerCreateDto>
    {
        public ManufacturerCreateDtoValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
            // check name is unique
            RuleFor(x => x.Name)
                .Must(name => !_context.Manufacturers.Any(c => c.Name == name))
                .WithMessage("The manufacturer name already exists in the database. Must be unique.");

        }
    }
}
