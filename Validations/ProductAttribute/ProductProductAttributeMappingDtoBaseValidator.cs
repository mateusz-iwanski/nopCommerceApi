using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttribute;

namespace nopCommerceApi.Validations.ProductAttribute
{
    public class ProductProductAttributeMappingDtoBaseValidator<T> : BaseValidator<T> where T : ProductProductAttributeMappingDto
    {
        private readonly NopCommerceContext _context;
        private readonly IMySettings _settings;

        public ProductProductAttributeMappingDtoBaseValidator(NopCommerceContext context, IMySettings settings)
        {
            _context = context;
            _settings = settings;

            // chaeck if product attribute exists
            RuleFor(x => x.ProductAttributeId)
                .Must(productAttributeId => _context.ProductAttributes.Any(c => c.Id == productAttributeId))
                .WithMessage("The product attribute does not exist.");

            // chaeck if product exists
            RuleFor(x => x.ProductId)
                .Must(productId => _context.Products.Any(c => c.Id == productId))
                .WithMessage("The product does not exist.");

            // chaeck if attribute control type exists, check from settings
            RuleFor(x => x.AttributeControlTypeId)
                .Must(attributeControlTypeId =>
                {
                    if (_settings.AttributeControlTypeAvailableId.Split(",").Select(int.Parse)
                                                   .Any(x => x == attributeControlTypeId))
                        return true;

                    return false;
                })
                .WithMessage("The attribute control type does not exist.");


        }
    }
}