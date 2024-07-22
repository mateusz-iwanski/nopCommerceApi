namespace nopCommerceApi.Models.Product
{
    public class ProductTagDetailsDto : ProductTagDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
