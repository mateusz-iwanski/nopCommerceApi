using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductVideo;
using nopCommerceApi.Models.Video;

namespace nopCommerceApi.Validations.ProductVideo
{
    public class ProductVideoBaseValidator<T> : BaseValidator<T> where T : ProductVideoDto
    {
        protected readonly NopCommerceContext _context;

        public ProductVideoBaseValidator(NopCommerceContext context)
        {
            _context = context;

            // check product id exists  
            RuleFor(x => x.ProductId)
                .Must((productId) => _context.Products.Find(productId) != null)
                .WithMessage("The product id does not exist.");

            // check video id exists
            RuleFor(x => x.VideoId)
                .Must((videoId) => _context.Videos.Find(videoId) != null)
                .WithMessage("The video id does not exist.");

            // check display order greater or equal 0
            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The display order must be greater or equal to 0.");
        }
    }
}
