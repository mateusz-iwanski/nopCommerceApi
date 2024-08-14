using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductAttributeValue
{
    public class ProductAttributeValueUpdateDto : ProductAttributeValueDto
    {
        /// <summary>
        /// ## ProductAttributeMappingId
        /// ### Gets or sets the product attribute mapping identifier
        /// #### Gets or sets product id which is associate with this attribute value
        /// #### It's id of product
        /// </summary>
        [JsonIgnore]
        public virtual int ProductAttributeMappingId { get; set; }
    }
}
