using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// Address update Data Transfer Object for Polish Enterprise updating
    /// </summary>
    public class AddressUpdatePolishEnterpriseDto : AddressDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Update Nip
        /// </summary>
        [Required]
        public string Nip { get; set; }
    }
}