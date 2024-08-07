using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttribute;
using nopCommerceApi.Models.UrlRecord;
using System.Reflection;

namespace nopCommerceApi.Validations.UrlRecord
{
    public class UrlRecordBaseDtoValidator<T> : BaseValidator<T> where T : UrlRecordDto
    {
        protected readonly NopCommerceContext _context;

        public UrlRecordBaseDtoValidator(NopCommerceContext context)
        {

            _context = context;

            // check slug is in proper format
            RuleFor(x => x.Slug)
                .Matches(@"^[a-zA-Z0-9-_]+$")
                .WithMessage("The slug is not in proper format.");

            // check that entity with EntityName exists
            RuleFor(x => x.EntityName)
                .Must(entityName =>
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var type = assembly.GetType($"nopCommerceApi.Entities.Usable.{entityName}");
                    return type != null;
                })
                .WithMessage("The entity name is not valid.");

            // check that entity with EntityName and EntityId exists
            RuleFor(x => new { x.EntityName, x.EntityId })
                .Must(obj =>
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var type = assembly.GetType($"nopCommerceApi.Entities.Usable.{obj.EntityName}");

                    // check that entity name exists
                    if (type != null)
                    {
                        // check ids from type
                        var entity = _context.Find(type, obj.EntityId);
                        return entity != null;
                    }
                    else 
                        return false;
                })
                .WithMessage("The entity id is not exists in entity name.");
                
            // checl language id is valid
            RuleFor(x => x.LanguageId)
                .Must(languageId => _context.Languages.Any(l => l.Id == languageId))
                .WithMessage("The language id is not valid.");

        }
    }
}
