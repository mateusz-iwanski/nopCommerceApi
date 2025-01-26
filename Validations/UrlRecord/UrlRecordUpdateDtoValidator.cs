using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.UrlRecord;

namespace nopCommerceApi.Validations.UrlRecord
{
    public class UrlRecordUpdateDtoValidator : UrlRecordBaseDtoValidator<UrlRecordUpdateDto>
    {
        public UrlRecordUpdateDtoValidator(NopCommerceContext context) : base(context)
        {
            // check that id exists
            RuleFor(x => x.Id)
                .Must(id => _context.UrlRecords.Any(u => u.Id == id))
                .WithMessage("The url record id is not exists.");
            
            // check if entity with EntityName and EntityId and LanguageId exists, exclude updated object
            RuleFor(x => new { x.EntityName, x.EntityId, x.LanguageId, x.Id })
                .Must(obj => 
                    !_context.UrlRecords.Any(u => 
                        u.EntityName == obj.EntityName && 
                        u.EntityId == obj.EntityId && 
                        u.LanguageId == obj.LanguageId && 
                        u.Id != obj.Id
                        )
                ).WithMessage("The entity with entity name, entity id and language id already exists.");
        }
    }
}
