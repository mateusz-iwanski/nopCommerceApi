namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// Country Data Transfer Object
    /// </summary>
    /// <remarks>
    /// This object should be used only for the get method in controller
    /// </remarks>
    public class CountryDto : BaseDto
    {
        public virtual int Id { get; set; }
        /// <summary>
        /// Gets the name
        /// </summary>
        public virtual string Name { get; set; } = null!;

        /// <summary>
        /// Gets a value indicating whether billing is allowed to this country
        /// </summary>
        public virtual string? TwoLetterIsoCode { get; set; }

        /// <summary>
        /// Gets a value indicating whether shipping is allowed to this country
        /// </summary>
        public virtual string? ThreeLetterIsoCode { get; set; }

        /// <summary>
        /// Gets the two letter ISO code
        /// </summary>
        public virtual bool AllowsBilling { get; set; }

        /// <summary>
        /// Gets the three letter ISO code
        /// </summary>
        public virtual bool AllowsShipping { get; set; }

        /// <summary>
        /// Gets the numeric ISO code
        /// </summary>
        public virtual int NumericIsoCode { get; set; }

        /// <summary>
        /// Gets a value indicating whether customers in this country must be charged EU VAT
        /// </summary>
        public virtual bool SubjectToVat { get; set; }

        /// <summary>
        /// Gets a value indicating whether the entity is published
        /// </summary>
        public virtual bool Published { get; set; }

        /// <summary>
        /// Gets the display order
        /// </summary>
        public virtual int DisplayOrder { get; set; }

        /// <summary>
        /// Gets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        public virtual bool LimitedToStores { get; set; }
    }
}
