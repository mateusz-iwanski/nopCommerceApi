using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Country
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
        /// ## Name
        /// ### Gets the name
        /// </summary>
        public virtual string Name { get; set; } = null!;

        /// <summary>
        /// ## TwoLetterIsoCode
        /// ### Gets a value indicating whether billing is allowed to this country
        /// </summary>
        [Required]
        public virtual string TwoLetterIsoCode { get; set; }

        /// <summary>
        /// ## ThreeLetterIsoCode
        /// ### Gets a value indicating whether shipping is allowed to this country
        /// *Defaul = null*
        /// </summary>
        public virtual string? ThreeLetterIsoCode { get; set; }

        /// <summary>
        /// ## AllowsBilling
        /// ### Gets the two letter ISO code
        /// *Default = true*
        /// </summary>
        public virtual bool AllowsBilling { get; set; }

        /// <summary>
        /// ## AllowsShipping
        /// ### Gets the three letter ISO code
        /// *Default = false*
        /// </summary>
        public virtual bool AllowsShipping { get; set; }

        /// <summary>
        /// ## NumericIsoCode
        /// ### Gets the numeric ISO code
        /// </summary>
        public virtual int NumericIsoCode { get; set; }

        /// <summary>
        /// ## SubjectToVat
        /// ### Gets a value indicating whether customers in this country must be charged EU VAT
        /// </summary>
        public virtual bool SubjectToVat { get; set; }

        /// <summary>
        /// ## Published
        /// ### Gets a value indicating whether the entity is published
        /// </summary>
        public virtual bool Published { get; set; }

        /// <summary>
        /// ## DisplayOrder
        /// ### Gets the display order
        /// *Default = 1*
        /// </summary>
        public virtual int DisplayOrder { get; set; }

        /// <summary>
        /// ## LimitedToStores
        /// ### Gets a value indicating whether the entity is limited/restricted to certain stores
        /// *Default = 0*
        /// </summary>
        public virtual bool LimitedToStores { get; set; }
    }
}
