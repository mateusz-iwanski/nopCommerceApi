using FluentValidation;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductAttributeMapping;

namespace nopCommerceApi.Validations.ProductAttribute
{
    public class ProductAttributeWithMappingCreateDtoValidator : BaseValidator<ProductAttributeWithMappingCreateDto>
    {
        private readonly NopCommerceContext _context;
        private readonly IMySettings _settings;

        public ProductAttributeWithMappingCreateDtoValidator(NopCommerceContext context, IMySettings settings)
        {

            _context = context;
            _settings = settings;

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
