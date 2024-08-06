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
        }
    }
}
