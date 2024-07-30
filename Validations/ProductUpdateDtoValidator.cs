using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Helpers;
using nopCommerceApi.Models.Product;
using nopCommerceApi.Services.Product;
using System.Linq;

namespace nopCommerceApi.Validations
{
    public class ProductUpdateDtoValidator : BaseValidator<ProductUpdateDto>
    {
        private readonly NopCommerceContext _context;
        private readonly IMySettings _settings;

        private bool ProductExists(int? id, Func<Product, bool> delegatE)
        {
            if (id == null) return false;
            var productsList = _context.Products.Where(p => p.Id != id).ToList();
            return productsList.Any(delegatE);
        }

        public ProductUpdateDtoValidator(NopCommerceContext context, IMySettings settings) : base()
        {
            _context = context;
            _settings = settings;

            #region Product Info

            // Name required
            RuleFor(x => x.Name)
                .Must(name => name == null || !string.IsNullOrWhiteSpace(name))
                .WithMessage("The name can't be empty. If you don't want to update, just remove from body.");

            // Name unique
            RuleFor(x => x.Name)
                .Must((product, name) => name == null || !ProductExists(
                    product.Id,
                    (x => x.Name == name))
                ).WithMessage("The product name already exists in the database. Must be unique.");

            // SKU required
            RuleFor(x => x.Sku)
                .Must(sku => sku == null || !string.IsNullOrWhiteSpace(sku))
                .WithMessage("The SKU can't be empty. If you don't want to update, just remove from body.");

            // SKU unique
            RuleFor(x => x.Sku)
                .Must((product, sku) => sku == null || !ProductExists(
                    product.Id,
                    (x => x.Sku == sku))
                ).WithMessage("The product SKU already exists in the database. Must be unique.");

            // Price required
            RuleFor(x => x.Price)
                .Must(price => price == null || !string.IsNullOrWhiteSpace(price.ToString()) || price == 0m)
                .WithMessage("The price can't be empty. If you don't want to update, just remove from body.");

            // TaxCategory required
            RuleFor(x => x.TaxCategoryId)
                .Must(taxCategoryId => taxCategoryId == null || !string.IsNullOrWhiteSpace(taxCategoryId.ToString()))
                .WithMessage("The tax category ID can't be empty. If you don't want to update, just remove from body.");

            // Weight required
            RuleFor(x => x.Weight)
                .Must(weight => weight == null || !string.IsNullOrWhiteSpace(weight.ToString()))
                .WithMessage("The weight can't be empty. If you don't want to update, just remove from body.");

            // Length required
            RuleFor(x => x.Length)
                .Must(length => length == null || !string.IsNullOrWhiteSpace(length.ToString()))
                .WithMessage("The length can't be empty. If you don't want to update, just remove from body.");

            // Width required
            RuleFor(x => x.Width)
                .Must(width => width == null || !string.IsNullOrWhiteSpace(width.ToString()))
                .WithMessage("The width can't be empty. If you don't want to update, just remove from body.");

            // Height required
            RuleFor(x => x.Height)
                .Must(height => height == null || !string.IsNullOrWhiteSpace(height.ToString()))
                .WithMessage("The height can't be empty. If you don't want to update, just remove from body.");

            // Product type (enum) is required
            RuleFor(x => x.ProductTypeId)
               .Must(productTypeId =>
               {
                   if (productTypeId == null) return true;

                   if (_settings.ProductTypeAvailableId.Split(",").Select(int.Parse)
                               .Any(x => x == productTypeId))
                       return true;

                   return false;
               })
               .WithMessage("The product type does not exist or is empty. If you don't want to update, just remove from body.");

            // ProductTemaplate has to exist
            RuleFor(x => x.ProductTemplateId)
                .Must(productTemplateId => productTemplateId == null || _context.ProductTemplates.Any(c => c.Id == productTemplateId))
                .WithMessage("The product template does not exist.");

            // Vendor has to exist
            RuleFor(x => x.VendorId)
                .Must(vendorId => vendorId == null || _context.Vendors.Any(c => c.Id == vendorId) || vendorId == 0)
                .WithMessage("The vendor does not exist.");

            #region RequireOtherProducts

            // If RequiredProductIds is not null than RequireOtherProducts has to be true
            RuleFor(x => x)
                .Must(product => product.RequireOtherProducts.GetValueOrDefault() || string.IsNullOrWhiteSpace(product.RequiredProductIds))
                .WithMessage("The RequireOtherProducts is set on false but RequiredProductIds is not empty. In this case you have to RequireOtherProducts set to true.");

            // RequiredProductIds (comma seperate string) has to exist
            RuleFor(x => x.RequiredProductIds)
                .Must(requireProductIds =>
                {
                    // can be null
                    if (requireProductIds == null) return true;

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

            //ParentGroupedProductId



            RuleFor(x => x.GiftCardTypeId)
                .Must(giftCardTypeId =>
                {
                    if (giftCardTypeId == null) return true;

                    if (_settings.GiftCardTypeAvailableId.Split(",").Select(x => int.Parse(x))
                         .Contains(giftCardTypeId.Value))
                        return true;
                    return false;
                })
                .WithMessage("The gift card does not exist.");





            #endregion
            /*
            // ShortDescription
            RuleFor(x => x.ShortDescription)
                .Must(shortDescription => shortDescription == null || !string.IsNullOrWhiteSpace(shortDescription))
                .WithMessage("The short description can't be empty. If you don't want to update, just remove from body.");


            // FullDescription
            RuleFor(x => x.FullDescription)
                .Must(fullDescription => fullDescription == null || !string.IsNullOrWhiteSpace(fullDescription))
                .WithMessage("The full description can't be empty. If you don't want to update, just remove from body.");

            // ManufacturerPartNumber
            RuleFor(x => x.ManufacturerPartNumber)
                .Must(manufacturerPartNumber => manufacturerPartNumber == null || !string.IsNullOrWhiteSpace(manufacturerPartNumber))
                .WithMessage("The manufacturer part number can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.Gtin)
                .Must(gtin => gtin == null || !string.IsNullOrWhiteSpace(gtin))
                .WithMessage("The GTIN can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.RequiredProductIds)
                .Must(requiredProductIds => requiredProductIds == null || !string.IsNullOrWhiteSpace(requiredProductIds))
                .WithMessage("The required product IDs can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.AdminComment)
                .Must(adminComment => adminComment == null || !string.IsNullOrWhiteSpace(adminComment))
                .WithMessage("The admin comment can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.MetaKeywords)
                .Must(metaKeywords => metaKeywords == null || !string.IsNullOrWhiteSpace(metaKeywords))
                .WithMessage("The meta keywords can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.MetaTitle)
                .Must(metaTitle => metaTitle == null || !string.IsNullOrWhiteSpace(metaTitle))
                .WithMessage("The meta title can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.MetaDescription)
                .Must(metaDescription => metaDescription == null || !string.IsNullOrWhiteSpace(metaDescription))
                .WithMessage("The meta description can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.AllowedQuantities)
                .Must(allowedQuantities => allowedQuantities == null || !string.IsNullOrWhiteSpace(allowedQuantities))
                .WithMessage("The allowed quantities can't be empty. If you don't want to update, just remove from body.");

            RuleFor(x => x.UserAgreementText)
                .Must(userAgreementText => userAgreementText == null || !string.IsNullOrWhiteSpace(userAgreementText))
                .WithMessage("The user agreement text can't be empty. If you don't want to update, just remove from body.");*/

        }

    }
}
