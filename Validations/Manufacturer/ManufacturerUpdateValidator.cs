using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Manufacturer;

namespace nopCommerceApi.Validations.Manufacturer
{
    public class ManufacturerUpdateValidator : ManufacturerBaseValidator<ManufacturerUpdateDto>
    {
        public ManufacturerUpdateValidator(NopCommerceContext context, IMySettings settings) : base(context, settings)
        {
            // check manufacturer exists
            RuleFor(x => x.Id)
                .Must(id => context.Manufacturers.Find(id) != null)
                .WithMessage("Manufacturer does not exist");

            // check manufacturer name is unique, exclude updated manufacturer
            RuleFor(x => x.Name)
                .Must((dto, name) => context.Manufacturers.Any(m => m.Name == name && m.Id != dto.Id) == false)
                .WithMessage("Manufacturer name already exists in the database. Must be unique.");
        }
    }
}
