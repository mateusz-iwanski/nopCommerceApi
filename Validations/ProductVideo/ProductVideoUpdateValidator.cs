using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductVideo;

namespace nopCommerceApi.Validations.ProductVideo
{
    public class ProductVideoUpdateValidator : ProductVideoBaseValidator<ProductVideoUpdateDto>
    {
        public ProductVideoUpdateValidator(NopCommerceContext context) : base(context)
        {
            // check if exists ProductId and VideoId, exclude updated object
            RuleFor(x => new { x.ProductId, x.VideoId, x.Id })
                .Must((dto) => !_context.ProductVideos.Any(p => dto.ProductId == p.ProductId && dto.VideoId == p.Id && p.Id != dto.Id))
                .WithMessage("The product video already exists.");
        }
    }
}
