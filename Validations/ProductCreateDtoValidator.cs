using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Models.Product;
using System.Linq;

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    private readonly NopCommerceContext _context;
    private readonly IMySettings _settings;

    public ProductCreateDtoValidator(NopCommerceContext context, IMySettings settings)
    {
        _context = context;
        _settings = settings;

        // Name required
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        // Name unique
        RuleFor(x => x.Name)
            .Must(name =>
            {
                var products = _context.Products.ToList();
                var uniqueName = products.Any(c => c.Name == name);

                return uniqueName == false ? true : false;
            })
            .WithMessage("The product name already exists in the database. Must be unique.");

        // SKU required
        RuleFor(x => x.Sku)
            .NotEmpty().WithMessage("SKU is required.");

        // SKU unique
        RuleFor(x => x.Sku)
            .Must(sku =>
            {
                var products = _context.Products.ToList();
                var uniqueName = products.Any(c => c.Sku == sku);

                return uniqueName == false ? true : false;
            })
            .WithMessage("The product SKU already exists in the database. Must be unique.");

        // Price required
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required.");

        // TaxCategory required
        RuleFor(x => x.TaxCategoryId)
            .NotEmpty().WithMessage("Tax Category ID is required.");

        // TaxCategory has to exist
        RuleFor(x => x.TaxCategoryId)
            .Must((taxCategoryId) =>
            {
                return _context.TaxCategories.Any(c => c.Id == taxCategoryId);
            })
            .WithMessage("The tax category does not exist.");

        // Weight is required
        RuleFor(x => x.Weight)
            .NotEmpty().WithMessage("Weight is required.");

        // Length is required
        RuleFor(x => x.Length)
            .NotEmpty().WithMessage("Length is required.");

        // Width is required
        RuleFor(x => x.Width)
            .NotEmpty().WithMessage("Width is required.");

        // Height is required
        RuleFor(x => x.Height)
            .NotEmpty().WithMessage("Height is required.");

        // Product type (enum) is required
        // compare with appsettings.ini ProductTypeAvailableId
        RuleFor(x => x.ProductTypeId)
            .Must(productTypeId =>
            { 
               if (_settings.ProductTypeAvailableId.Split(",").Select(int.Parse)
                    .Contains(productTypeId))
                   return true;
               return false;
            })
            .WithMessage("The product type does not exist.");

        // Gift card type (enum) is required
        // compare with appsettings.ini GiftCardTypeAvailableId
        RuleFor(x => x.GiftCardTypeId)
            .Must(giftCardTypeId =>
            {
                if (_settings.GiftCardTypeAvailableId.Split(",").Select(int.Parse)
                     .Contains(giftCardTypeId))
                    return true;
                return false;
            })
            .WithMessage("The gift card does not exist.");
        
        // DownloadActivationType (enum) is required
        // compare with appsettings.ini DownloadActivationTypeAvailableId
        RuleFor(x => x.DownloadActivationTypeId)
            .Must(downloadActivationTypeId =>
            {
                if (_settings.DownloadActivationTypeAvailableId.Split(",").Select(int.Parse)
                                    .Contains(downloadActivationTypeId))
                    return true;
                return false;
            })
            .WithMessage("The download activation type does not exist.");

        // RecurringProductCyclePeriod (enum) is required
        // compare with appsettings.ini RecurringProductCyclePeriodAvailableId
        RuleFor(x => x.RecurringCyclePeriodId)
            .Must(recurringProductCyclePeriodId =>
            {
                if (_settings.RecurringProductCyclePeriodAvailableId == recurringProductCyclePeriodId)
                    return true;
                return false;
            })
            .WithMessage("The recurring product cycle period does not exist.");

        // RentalPricePeriod (enum) is required
        // compare with appsettings.ini RentalPricePeriodAvailableId
        RuleFor(x => x.RentalPricePeriodId)
            .Must(rentalPricePeriodId =>
            {
                if (_settings.RentalPricePeriodAvailableId == rentalPricePeriodId)
                    return true;
                return false;
            })
            .WithMessage("The rental price period does not exist.");

        // check that ProductTemplates exists with id
        RuleFor(x => x.ProductTemplateId)
            .Must((productTemplateId) =>
            {
                return _context.ProductTemplates.Any(c => c.Id == productTemplateId);
            })
            .WithMessage("The product template does not exist.");

        // check that Vendor exists with id
        RuleFor(x => x.VendorId)
            .Must((vendorId) =>
            {
                if (vendorId != 0)
                    return _context.Vendors.Any(c => c.Id == vendorId);
                return true;
            })
            .WithMessage("The vendor does not exist.");

        // check that Product with RequiredProductIds exists
        // RequiredProductIds is a comma separated list of product ids
        RuleFor(x => x.RequiredProductIds)
            .Must((requiredProductIds) =>
            {
                if (!string.IsNullOrEmpty(requiredProductIds))
                {
                    var productIds = requiredProductIds.Split(",").Select(int.Parse);

                    foreach (var productId in productIds)
                    {
                        if (!context.Products.Any(p => p.Id == productId))
                            return false;
                    }
                }

                return true;
            })
            .WithMessage("Invalid required product IDs.");

        // check if Download with DownloadId exists
        RuleFor(x => x.DownloadId)
            .Must((downloadId) =>
            {
                if (downloadId != 0)
                    return _context.Downloads.Any(c => c.Id == downloadId);
                return true;
            })
            .WithMessage("The download does not exist.");

        //check id DeliveryDateId exists
        RuleFor(x => x.DeliveryDateId)
            .Must((deliveryDateId) =>
            {
                if (deliveryDateId != 0)
                    return _context.DeliveryDates.Any(c => c.Id == deliveryDateId);
                return true;
            })
            .WithMessage("The delivery date does not exist.");
    }
}
