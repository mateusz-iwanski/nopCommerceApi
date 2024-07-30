namespace nopCommerceApi.Models.Product
{
    public class ProductUpdateSeoDto : BaseDto
    {
        /// <summary>
        /// ## MetaKeywords 
        /// ### Set the meta keywords.
        /// </summary>
        public virtual string? MetaKeywords { get; set; }

        /// <summary>
        /// ## MetaTitle
        /// ### Set the meta description.
        /// </summary>
        public virtual string? MetaTitle { get; set; }

        /// <summary>
        /// ## MetaDescription
        /// ### Meta description to be added to product page header.
        /// </summary>
        public virtual string? MetaDescription { get; set; }
    }
}
