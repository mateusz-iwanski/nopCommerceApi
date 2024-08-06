using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Manufacturer;

namespace nopCommerceApi.Validations.Manufacturer
{
    public class ManufacturerBaseValidator<T> : BaseValidator<T> where T : ManufacturerDto
    {
        protected readonly IMySettings _settings;
        protected readonly NopCommerceContext _context;

        public ManufacturerBaseValidator(NopCommerceContext context, IMySettings settings)
        {
            _context = context;
            _settings = settings;

            // check picture id exists
            RuleFor(x => x.PictureId)
                .Must(pictureId => _context.Pictures.Any(p => p.Id == pictureId) || pictureId == 0)
                .WithMessage("The picture does not exist.");
            
            // chack manufacturer template id exists
            RuleFor(x => x.ManufacturerTemplateId)
                .Must(manufacturerTemplateId => _context.ManufacturerTemplates.Find(manufacturerTemplateId) != null)
                .WithMessage("The manufacturer template does not exist.");
        }
    }
}
