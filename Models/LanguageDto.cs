namespace nopCommerceApi.Models
{
    /// <summary>
    /// Language Data Transfer Object
    /// </summary>
    /// <remarks>
    /// This object should be used only for the get method in controller
    /// </remarks>
    public class LanguageDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets the name
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets the language culture
        /// </summary>
        public string LanguageCulture { get; set; } = null!;

        /// <summary>
        /// Gets the unique SEO code
        /// </summary>
        public string? UniqueSeoCode { get; set; }

        /// <summary>
        /// Gets the flag image file name
        /// </summary>
        public string? FlagImageFileName { get; set; }

        /// <summary>
        /// Gets a value indicating whether the language supports "Right-to-left"
        /// </summary>
        public bool Rtl { get; set; }

        /// <summary>
        /// Gets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// Gets the identifier of the default currency for this language; 0 is set when we use the default currency display order
        /// </summary>
        public int DefaultCurrencyId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the language is published
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
