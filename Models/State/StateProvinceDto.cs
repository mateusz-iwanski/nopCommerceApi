using nopCommerceApi.Models.Country;

namespace nopCommerceApi.Models.State
{
    /// <summary>
    /// StateProvince Data Transfer Object
    /// </summary>
    /// <remarks>
    /// This object should be used only for the get method in controller
    /// </remarks>
    public class StateProvinceDto : BaseDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the abbreviation
        /// </summary>
        public string? Abbreviation { get; set; }

        /// <summary>
        /// Gets the country identifier
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the entity is published
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets country object
        /// </summary>
        public CountryDto Country { get; set; }
    }
}
