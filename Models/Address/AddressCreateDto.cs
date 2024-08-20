using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// <c>CreateAddressDto</c> uses for creating address for individual person
    /// </summary>
    public class AddressCreateDto : AddressDto
    {
        private DateTime _createdOnUtc { get; set; }

        [JsonIgnore]
        public override int Id { get; set; }

        public override DateTime CreatedOnUtc
        {
            get => _createdOnUtc;
            set => _createdOnUtc = DateTime.Now;
        }
    }
}
