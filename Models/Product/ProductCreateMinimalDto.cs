using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Product
{
    /// <summary>
    /// ProductCreateMinimalDto uses for creating a new product
    /// </summary>
    /// <remarks>
    /// Only the required properties are included in this DTO
    /// </remarks>
    public class ProductCreateMinimalDto
    {
        /// <summary>
        /// ## Name
        /// ### Set the name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// ## SKU
        /// ### Set the SKU
        /// </summary>
        [Required]
        public string Sku { get; set; }

        /// <summary>
        /// ## Price
        /// ### Set the price
        /// #### The price of the product. You can manage currency by selecting Configuration > Currencies.
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// ## TaxCategoryId
        /// ### Set the tax category identifier
        /// #### Look on TaxCategory schema for more details.
        /// </summary>
        [Required]
        public int TaxCategoryId { get; set; }

        /// <summary>
        /// ## Weight
        /// ### Set the weight
        /// #### To set mesasures go to Configuration → Shipping → Measures 
        /// </summary>
        [Required]
        public decimal Weight { get; set; }

        /// <summary>
        /// ## Length
        /// ### Set the length
        /// #### To set mesasures go to Configuration → Shipping → Measures 
        /// </summary>
        [Required]
        public decimal Length { get; set; }

        /// <summary>
        /// ## Width
        /// ### Set the width
        /// #### To set mesasures go to Configuration → Shipping → Measures 
        /// </summary>
        [Required]
        public decimal Width { get; set; }

        /// <summary>
        /// ## Height
        /// ### Set the height
        /// #### To set mesasures go to Configuration → Shipping → Measures 
        /// </summary>
        [Required]
        public decimal Height { get; set; }

    }
}
