using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Category;

namespace nopCommerceApi.Validations.Category
{
    public class CategoryUpdateDtoValidator : CategoryBaseDtoValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator(NopCommerceContext context) : base(context)
        {
            
            // check id exists
            RuleFor(x => x.Id)
                .Must(id => _context.Categories.Any(c => c.Id == id))
                .WithMessage("Category does not exist");

            // check name is unique, exclude updated object
            RuleFor(x => x.Name)
                .Must((dto, name) => !_context.Categories.Any(c => c.Name == name && c.Id != dto.Id))
                .WithMessage("The category name already exists in the database. Must be unique.");
        }
    }
}
