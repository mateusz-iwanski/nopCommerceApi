using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public override int Id { get; set; }

        /// <summary>
        /// ## Company
        /// ### Sets the company
        /// </summary>
        [Required]
        public override string Company { get; set; }

        /// <summary>
        /// ## Nip
        /// ### Sets the Nip
        /// </summary>
        [Required]
        public string Nip { get; set; }
        
        /// <summary>
        /// It's always Poland
        /// </summary>
        [JsonIgnore]
        public override int? CountryId { get; set; }
    }
}
