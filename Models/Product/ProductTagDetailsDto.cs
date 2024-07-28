namespace nopCommerceApi.Models.Product
{
    /// <summary>
    /// Product tag details Data Transfer Object
    /// </summary>
    /// <remarks>
    /// Should be used only for the get method in controller
    /// </remarks>
    public class ProductTagDetailsDto : ProductTagDto
    {
        /// <summary>
        /// List of products with this tag
        /// </summary>
        public List<ProductDto> Products { get; set; }
    }
}
