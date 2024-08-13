using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Category;

namespace nopCommerceApi.Validations.Category
{
    public class CategoryCreateDtoValidator : CategoryBaseDtoValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator(NopCommerceContext context) : base(context)
        {
            // check name is unique
            RuleFor(x => x.Name)
                .Must(name => !_context.Categories.Any(c => c.Name == name))
                .WithMessage("The category name already exists in the database. Must be unique.");
        }
    }
}
