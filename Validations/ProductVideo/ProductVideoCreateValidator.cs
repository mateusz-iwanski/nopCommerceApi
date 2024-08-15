using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.ProductVideo;

namespace nopCommerceApi.Validations.ProductVideo
{
    public class ProductVideoCreateValidator : ProductVideoBaseValidator<ProductVideoCreateDto>
    {
        public ProductVideoCreateValidator(NopCommerceContext context) : base(context)
        {
            // check if exists ProductId and VideoId
            RuleFor(x => new { x.ProductId, x.VideoId })
                .Must((dto) => !_context.ProductVideos.Any(p => dto.ProductId == p.ProductId && dto.VideoId == p.VideoId ))
                .WithMessage("The product with the video is already associated.");
        }
    }   
}
