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
    public class ProductUpdateInformationDtoValidator : BaseValidator<ProductUpdateInformationDto>
    {
        private readonly NopCommerceContext _context;
        private readonly IMySettings _settings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductUpdateInformationDtoValidator(NopCommerceContext context, IMySettings settings, IHttpContextAccessor httpContextAccessor) : base()
        {
            _context = context;
            _settings = settings;
            _httpContextAccessor = httpContextAccessor;


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
            RuleFor(x => x.VendorId)
                .Must(vendorId => _context.Vendors.Any(c => c.Id == vendorId) || vendorId == 0)
                .WithMessage("The vendor does not exist.");

            #region RequireOtherProducts

            // If RequiredProductIds is not null than RequireOtherProducts has to be true
            RuleFor(x => x)
                .Must(product => product.RequireOtherProducts || string.IsNullOrWhiteSpace(product.RequiredProductIds))
                .WithMessage("The RequireOtherProducts is set on false but RequiredProductIds is not empty. In this case you have to RequireOtherProducts set to true.");

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

            #endregion

            // ParentGroupedProductId has to exist
            RuleFor(x => x.ParentGroupedProductId)
                .Must(parentGroupedProductId => _context.Products.Any(c => c.Id == parentGroupedProductId))
                .WithMessage("The parent grouped product does not exist.");
        }
    }
}
