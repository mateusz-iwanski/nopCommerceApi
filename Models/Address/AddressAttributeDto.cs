namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// Additional attribute for address
    /// </summary>
    public class AddressAttributeDto
    {        
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsRequired { get; set; }

        /// <value>
        /// Property <c>AddressAttributeTypeId</c> represents control type.
        /// 
        /// It's a id of enum AttributeControlType
        /// File path : nopCommerce\src\Libraries\Nop.Core\Domain\Catalog\AttributeControlType.cs
        /// 
        /// DropdownList = 1,
        /// RadioList = 2,
        /// Checkboxes = 3,
        /// TextBox = 4,
        /// MultilineTextbox = 10,
        /// Datepicker = 20,
        /// FileUpload = 30,
        /// ColorSquares = 40,
        /// ImageSquares = 45,
        /// ReadonlyCheckboxes = 50
        /// 
        /// </value>        
        public int AttributeControlTypeId { get; set; }

        public int DisplayOrder { get; set; }
    }
}
