using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// <c>CreateAddressDto</c> uses for creating address for individual person
    /// </summary>
    public class AddressCreateDto : AddressDto
    {
        [JsonIgnore]
        public override int Id { get; set; }

        public override DateTime CreatedOnUtc { get; set; } = DateTime.Now;
    }
}
