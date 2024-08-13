using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Category;
using nopCommerceApi.Models.ProductAttributeValue;

namespace nopCommerceApi.Validations.ProductAttributeValue
{
    /// <summary>
    /// Validator for ProductAttributeValueDto
    /// </summary>
    public class ProductAttributeValueDtoBaseValidator<T> : BaseValidator<T> where T : ProductAttributeValueDto
    {
        private readonly NopCommerceContext _context;
        private readonly IMySettings _settings;

        public ProductAttributeValueDtoBaseValidator(NopCommerceContext context, IMySettings settings)
        {
            _context = context;
            _settings = settings;

            // check if ProductAttributeMappingId exist in product
            RuleFor(x => x.ProductAttributeMappingId)
                .Must((productAttributeMappingId) => _context.Products.Any(p => p.Id == productAttributeMappingId))
                .WithMessage($"The product ID that you want to map to productAttributeMappingId does not exist");

            // check if AttributeValueTypeId is valid from settings AttributeValueTypeAvailableId
            RuleFor(x => x.AttributeValueTypeId)
                .Must((attributeValueTypeId) =>
                {
                    if (_settings.AttributeValueTypeAvailableId.Split(",").Select(int.Parse)
                                                .Any(x => x == attributeValueTypeId))
                        return true;

                    return false;
                })
                .WithMessage("The attribute value type does not exist.");

            // check if quntity is greater or equal than 1
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            // check if associatedProductId exist as product id
            RuleFor(x => x.AssociatedProductId)
                .Must((associatedProductId) => _context.Products.Any(p => p.Id == associatedProductId))
                .WithMessage("The associated product ID does not exist.");

        }
    }
}