using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// <c>AddressCreatePolishEnterpriseDto</c> uses for creating enterprise address with the NIP value as a custom attribute for Poland.
    /// </summary>
    /// <remarks>
    /// Default nopCommerce not have this feature.
    /// CustomAttribute will look like this:
    /// 
    /// <Attributes>
    ///     <AddressAttribute ID="1">
    ///         <AddressAttributeValue>
    ///             <Value>NIP NUMBER</Value>
    ///          </AddressAttributeValue>
    ///     </AddressAttribute>
    /// </Attributes>      
    /// 
    /// AddressAttribute ID="1" 
    /// </remarks> 
    public class AddressCreatePolishEnterpriseDto : AddressDto
    {
        /// <summary>
        /// Sets the company
        /// </summary>
        [Required]
        public override string Company { get; set; }

        /// <summary>
        /// Sets the Nip
        /// </summary>
        [Required]
        public string Nip { get; set; }

        /// <summary>
        /// Sets the City
        /// </summary>
        [Required]
        public override string City { get; set; }

        /// <summary>
        /// Sets the address1
        /// </summary>
        [Required]
        public override string Address1 { get; set; }
    }
}
