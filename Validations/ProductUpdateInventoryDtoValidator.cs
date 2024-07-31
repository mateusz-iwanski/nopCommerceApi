using FluentValidation;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Helpers;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Validations
{
    public class ProductUpdateInventoryDtoValidator : BaseValidator<ProductUpdateInventoryDto>
    {
        private readonly IMySettings _settings;
        private readonly NopCommerceContext _context;

        public ProductUpdateInventoryDtoValidator(NopCommerceContext context, IMySettings settings) : base()
        {
            _settings = settings;
            _context = context;

            // ManagementInventory (enum) is required
            // compare with appsettings.ini ManageInventoryMethodAvailableId
            RuleFor(x => x.ManageInventoryMethodId)
                .Must(manageInventoryMethodId =>
                {
                    if (_settings.ManageInventoryMethodAvailableId.Split(",").Select(int.Parse)
                        .Contains(manageInventoryMethodId))
                        return true;
                    return false;
                })
                .WithMessage("The manage inventory method does not exist.");

            // check if ProductAvailabilityRangeId exists
            RuleFor(x => x.ProductAvailabilityRangeId)
                .Must((productAvailabilityRangeId) =>
                {
                    if (productAvailabilityRangeId != 0)
                        return _context.ProductAvailabilityRanges.Any(c => c.Id == productAvailabilityRangeId);
                    return true;
                })
                .WithMessage("The product availability range does not exist.");

            // check if WarehouseId
            RuleFor(x => x.WarehouseId)
                .Must((warehouseId) =>
                {
                    if (warehouseId != 0)
                        return _context.Warehouses.Any(c => c.Id == warehouseId);
                    return true;
                })
                .WithMessage("The warehouse does not exist.");

            // LowStockActivity (enum) is required
            // compare with appsettings.ini LowStockActivityAvailableId
            RuleFor(x => x.LowStockActivityId)
                .Must(lowStockActivityId =>
                {
                    if (_settings.LowStockActivityAvailableId.Split(",").Select(int.Parse)
                        .Contains(lowStockActivityId))
                        return true;
                    return false;
                })
                .WithMessage("The low stock activity does not exist.");

            // BackorderMode (enum) is required
            // compare with appsettings.ini BackorderModeAvailableId
            RuleFor(x => x.BackorderModeId)
                .Must(backorderModeId =>
                {
                    if (_settings.BackorderModeAvailableId.Split(",").Select(int.Parse)
                                                         .Contains(backorderModeId))
                        return true;
                    return false;
                })
                .WithMessage("The backorder mode does not exist.");

            // check the correct format of allowed quantities,
            // can be a string of characters with numbers separated by a comma
            RuleFor(x => x.AllowedQuantities)
                .Must(allowedQuantities =>
                {
                    try
                    {
                        var ids = DtoHelper.BeAListFromCommaSeparatedString(allowedQuantities);
                    }
                    catch (BadRequestException exception)
                    {
                        return false;
                    }
                    
                    return true;

                }).WithMessage("The required allowed quantities aren't in proper format");

        }
    }
}
