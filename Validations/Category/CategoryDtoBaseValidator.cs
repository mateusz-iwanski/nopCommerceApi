using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using nopCommerceApi.Models.Category;

namespace nopCommerceApi.Validations.Category
{
    public class CategoryDtoBaseValidator<T> : BaseValidator<T> where T : CategoryDto
    {
        private readonly NopCommerceContext _context;

        public CategoryDtoBaseValidator(NopCommerceContext context) : base()
        {
            _context = context;

            // check if ParentCategory exists
            RuleFor(x => x.ParentCategoryId)
                .Must(parentCategoryId => _context.Categories.Any(c => c.Id == parentCategoryId))
                .WithMessage("Parent category does not exist");

            // check if picture exists
            RuleFor(x => x.PictureId)
                .Must(pictureId => _context.Pictures.Any(c => c.Id == pictureId))
                .WithMessage("Picture does not exist");

            // check PageSizeOptions proper format
            RuleFor(x => x.PageSizeOptions)
                .Must(pageSizeOptions =>
                {
                    if (pageSizeOptions == null) return true;

                    var pageSizeOptionsList = pageSizeOptions.Split(",");
                    return pageSizeOptionsList.All(x => int.TryParse(x, out _));
                })
                .WithMessage("PageSizeOptions are not in proper format");

            // check CategoryTemplate exists
            RuleFor(x => x.CategoryTemplateId)
                .Must(categoryTemplateId => _context.CategoryTemplates.Any(c => c.Id == categoryTemplateId))
                .WithMessage("Category template does not exist");
        }
    }
}
