using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.ProductAttribute
{
    /// <summary>
    /// Product attribute value DTO
    /// </summary>
    /// <remarks>
    /// Element of product attribute
    /// Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/product-attributes.html
    /// </remarks>
    public class ProductAttributeValueDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the product attribute value identifier
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// ## Name
        /// ### Gets or sets the product attribute name
        /// #### The attribute value name e.g. 'Blue' for Color attributes.
        /// </summary>
        [Required]
        public virtual string Name { get; set; }

        /// <summary>
        /// ## ColorSquaresRgb
        /// ### Gets or sets the color RGB value (used with "Color squares" attribute type)
        /// *Default = null*
        /// </summary>
        public virtual string? ColorSquaresRgb { get; set; }

        /// <summary>
        /// ## ProductAttributeMappingId
        /// ### Gets or sets the product attribute mapping identifier
        /// #### Gets or sets product id which is associate with this attribute value
        /// #### It's id of product
        /// </summary>
        [Required]
        public virtual int ProductAttributeMappingId { get; set; }

        /// <summary>
        /// ## AttributeValueTypeId
        /// ### Gets or sets the attribute value type identifier
        /// #### The attribute value type identifier is enum type (simple - 0 , associated to product - 10)
        /// </summary>
        [Required]
        public virtual int AttributeValueTypeId { get; set; }

        /// <summary>
        /// ## AssociatedProductId
        /// ### Gets or sets the associated product identifier (used only with AttributeValueType.AssociatedToProduct)
        /// #### Note: Attribute value can be simple (not associate to product) and associated to product (AttributeValueTypeId)
        /// *Default = 0
        /// </summary>
        public virtual int AssociatedProductId { get; set; }

        /// <summary>
        /// ## ImageSquaresPictureId
        /// ### Gets or sets the picture ID for image square (used with "Image squares" attribute type)
        /// *Default = 0*
        /// </summary>
        public virtual int ImageSquaresPictureId { get; set; }

        /// <summary>
        /// ## PriceAdjustment
        /// ### Gets or sets the price adjustment (used only with AttributeValueType.Simple)
        /// #### The price adjustment applied when choosing this attribute value. 
        /// #### For example '10' to add 10 dollars. Or 10% if 'Use percentage' is ticked.
        /// *Default = 0*
        /// </summary>
        public virtual decimal PriceAdjustment { get; set; }

        /// <summary>
        /// ## PriceAdjustmentUsePercentage
        /// ### Gets or sets a value indicating whether "price adjustment" is specified as percentage (used only with AttributeValueType.Simple)
        /// #### Determines whether to apply a percentage to the product. If not enabled, a fixed value is used.
        /// *Default = false*
        /// </summary>
        public virtual bool PriceAdjustmentUsePercentage { get; set; }

        /// <summary>
        /// ## WeightAdjustment
        /// ### Gets or sets the weight adjustment (used only with AttributeValueType.Simple)
        /// ### The weight adjustment applied when choosing this attribute value.
        /// *Default = 0m*
        /// </summary>
        public virtual decimal WeightAdjustment { get; set; }

        /// <summary>
        /// ## Cost
        /// ### Gets or sets the attribute value cost (used only with AttributeValueType.Simple)
        /// #### The attribute value cost is the cost of all the different components which make up this value. 
        /// #### This may be either the purchase price if the components are bought from outside suppliers, 
        /// #### or the combined cost of materials and manufacturing processes if the component is made in-house.
        /// *Default = 0m*
        /// </summary>
        public virtual decimal Cost { get; set; }

        /// <summary>
        /// ## CustomerEntersQty
        /// ### Gets or sets a value indicating whether the customer can enter the quantity of associated product (used only with AttributeValueType.AssociatedToProduct)
        /// #### Allow customers enter the quantity of associated product.
        /// *Default = false*
        /// </summary>
        public virtual bool CustomerEntersQty { get; set; }

        /// <summary>
        /// ## Quantity
        /// ### Gets or sets the quantity of associated product (used only with AttributeValueType.AssociatedToProduct)
        /// #### Specify quantity of the associated product which will be added. Minimum allowed value is 1.
        /// *Default = 1*
        /// </summary>
        public virtual int Quantity { get; set; }

        /// <summary>
        /// ## IsPreSelected
        /// ### Gets or sets a value indicating whether the value is pre-selected
        /// #### Determines whether this attribute value is pre-selected for the customer.
        /// *Default = false*
        /// </summary>
        public virtual bool IsPreSelected { get; set; }

        /// <summary>
        /// ## DisplayOrder
        /// ### Gets or sets the display order
        /// #### The display order of the attribute value. 1 represents the first item in attribute value list.
        /// </summary>
        public virtual int DisplayOrder { get; set; }
    }
}
