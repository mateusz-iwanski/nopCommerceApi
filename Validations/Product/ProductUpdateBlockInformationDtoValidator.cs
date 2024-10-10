using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Helpers;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Validations
{
    public class ProductUpdateBlockInformationDtoValidator : BaseValidator<ProductUpdateBlockInformationDto>
    {
        private readonly NopCommerceContext _context;
        private readonly IMySettings _settings;

        public ProductUpdateBlockInformationDtoValidator(NopCommerceContext context, IMySettings settings) : base()
        {
            _context = context;
            _settings = settings;

            

            // Product type(enum) is required
            RuleFor(x => x.ProductTypeId)
               .Must(productTypeId =>
               {
                   if (_settings.ProductTypeAvailableId.Split(",").Select(int.Parse)
                               .Any(x => x == productTypeId))
                       return true;

                   return false;
               })
               .WithMessage("The product type does not exist.");

            // ProductTemaplate has to exist
            RuleFor(x => x.ProductTemplateId)
                .Must(productTemplateId => productTemplateId == null || _context.ProductTemplates.Any(c => c.Id == productTemplateId))
                .WithMessage("The product template does not exist.");

            // Vendor has to exist
            // VendorId can be 0
            RuleFor(x => x.VendorId)
                .Must(vendorId => _context.Vendors.Any(c => c.Id == vendorId) || vendorId == 0)
                .WithMessage("The vendor does not exist.");

            // RequiredProductIds (comma seperate string) has to exist
            RuleFor(x => x.RequiredProductIds)
                .Must(requireProductIds =>
                {
                    // can be null
                    if (requireProductIds.IsNullOrEmpty()) return true;

                    // check and return list of IDs from comma seperate string
                    var ids = DtoHelper.BeAListFromCommaSeparatedString(requireProductIds);
                    if (ids.Count() > 0)
                    {
                        return ids.All(id => _context.Products.Any(p => p.Id == id));
                    }
                    else
                        return false;
                }).WithMessage("The required product IDs aren't in proper format or not exists.");

            // ParentGroupedProductId has to exist
            RuleFor(x => x.ParentGroupedProductId)
                .Must(parentGroupedProductId => _context.Products.Any(c => c.Id == parentGroupedProductId || parentGroupedProductId == 0))
                .WithMessage("The parent grouped product does not exist.");
        }
    }
}
