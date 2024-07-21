namespace nopCommerceApi.Models.Product
{
    public class ProductTagDto : BaseDto
    {
        public virtual string Name { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
