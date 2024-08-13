using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// Address update Data Transfer Object for Polish Enterprise updating
    /// </summary>
    public class AddressUpdatePolishEnterpriseDto : AddressDto
    {
        public int Id { get; set; }

        /// <summary>
        /// ## Nip
        /// ### Update Nip
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