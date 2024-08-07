using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductCategory;
using nopCommerceApi.Models.UrlRecord;
using nopCommerceApi.Validations.ProductCategory;

namespace nopCommerceApi.Validations.UrlRecord
{
    public class UrlRecordCreateDtoValidator : UrlRecordBaseDtoValidator<UrlRecordCreateDto>
    {
        public UrlRecordCreateDtoValidator(NopCommerceContext context) : base(context)
        {
            // check if entity with EntityName and EntityId and LanguageId exists
            RuleFor(x => new { x.EntityName, x.EntityId, x.LanguageId })
                .Must(obj => !_context.UrlRecords.Any(u => u.EntityName == obj.EntityName && u.EntityId == obj.EntityId && u.LanguageId == obj.LanguageId)
                ).WithMessage("The entity with entity name, entity id and language id already exists.");
            
        }
    }
}
