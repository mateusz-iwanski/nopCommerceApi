namespace nopCommerceApi.Models.Tax
{
    /// <summary>
    /// Tax Cateogry Data Transfer Object
    /// </summary>
    /// <remarks>
    /// This object should be used only for the get method in controller
    /// </remarks>
    public class TaxRateDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## StoreId
        /// ### Gets or sets the store identifier
        /// #### Default value: 0
        /// </summary>
        public virtual int StoreId { get; set; }

        /// <summary>
        /// ## TaxCategoryId
        /// ### Gets or sets the tax category identifier
        /// </summary>
        public virtual int TaxCategoryId { get; set; }

        /// <summary>
        /// ## CountryId
        /// ### Gets or sets the country identifier
        /// #### Default value: 0
        /// </summary>
        public virtual int CountryId { get; set; }

        /// <summary>
        /// ## StateProvinceId
        /// ### Gets or sets the state/province identifier
        /// </summary>
        public virtual int StateProvinceId { get; set; }

        /// <summary>
        /// ## Zip
        /// ### Gets or sets the zip
        /// #### Default value: null
        /// </summary>
        public virtual string? Zip { get; set; }

        /// <summary>
        /// ## Percentage
        /// ### Gets or sets the percentage
        /// #### Default value: 0
        /// </summary>
        public virtual decimal Percentage { get; set; }
    }
}
