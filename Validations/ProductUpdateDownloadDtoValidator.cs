using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Validations
{
    public class ProductUpdateDownloadDtoValidator : BaseValidator<ProductUpdateDownloadDto>
    {
        private readonly NopCommerceContext _context;
        private readonly IMySettings _settings;

        public ProductUpdateDownloadDtoValidator(NopCommerceContext context, IMySettings settings) : base()
        {
            _context = context;
            _settings = settings;

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

            // check if Download with SampleDownloadId exists
            RuleFor(x => x.SampleDownloadId)
                .Must((SampleDownloadId) =>
                {
                    if (SampleDownloadId != 0)
                        return _context.Downloads.Any(c => c.Id == SampleDownloadId);
                    return true;
                })
                .WithMessage("The smaple download does not exist.");

            // check if Download with DownloadId exists
            RuleFor(x => x.DownloadId)
                .Must((downloadId) =>
                {
                    if (downloadId != 0)
                        return _context.Downloads.Any(c => c.Id == downloadId);
                    return true;
                })
                .WithMessage("The download does not exist.");
        }
    }
}   
