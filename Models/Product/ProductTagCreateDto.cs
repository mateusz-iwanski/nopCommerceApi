namespace nopCommerceApi.Models.Product
{
    /// <summary>
    /// Product tag create Data Transfer Object
    /// </summary>
    public class ProductTagCreateDto : BaseDto
    {
        /// <summary>
        /// Sets the name
        /// </summary>
        public virtual string Name { get; set; }
    }
}
