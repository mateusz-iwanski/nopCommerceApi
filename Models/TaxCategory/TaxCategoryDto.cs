namespace nopCommerceApi.Models.TaxCategory
{
    /// <summary>
    /// Tax Cateogry Data Transfer Object
    /// </summary>
    /// <remarks>
    /// This object should be used only for the get method in controller
    /// </remarks>
    public class TaxCategoryDto
    {
        /// <summary>
        /// Gets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
