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
        }
    }
}
