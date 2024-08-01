using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Category;

namespace nopCommerceApi.Validations.Category
{
    public class CreateCategoryDtoValidator : CategoryDtoBaseValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator(NopCommerceContext context) : base(context)
        {
        }
    }
}
