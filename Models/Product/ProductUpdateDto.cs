using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Product
{
    public class ProductUpdateDto : ProductDto
    {
        [JsonIgnore]
        public override int? Id { get; set; }

        /// <summary>
        /// ## CreatedOnUtc
        /// ### Set the date and time of product creation.
        /// *Default = DateTime.Now*
        /// </summary>
        [JsonIgnore]
        public override DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ## UpdatedOnUtc
        /// ### Set the date and time of product update.
        /// *Default = DateTime.Now*
        /// </summary>
        [JsonIgnore]
        public virtual DateTime UpdatedOnUtc { get; set; } = DateTime.Now;
    }
}
