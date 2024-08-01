using nopCommerceApi.Entities;
using nopCommerceApi.Models.Category;

namespace nopCommerceApi.Validations.Category
{
    public class UpdateCategoryDtoValidator : CategoryDtoBaseValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator(NopCommerceContext context) : base(context)
        {
        }
    }
}
