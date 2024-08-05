namespace nopCommerceApi.Models.ProductCategory
{
    public class ProductCategoryMappingDto : BaseDto
    {

        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int ProductId { get; set; }

        public bool IsFeaturedProduct { get; set; }

        public int DisplayOrder { get; set; }

    }
}
