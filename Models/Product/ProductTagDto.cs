namespace nopCommerceApi.Models.Product
{
    /// <summary>
    /// Product tag Data Transfer Object
    /// </summary>
    /// <remarks>
    /// Should be used only for the get method in controller
    /// </remarks>
    public class ProductTagDto : BaseDto
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
