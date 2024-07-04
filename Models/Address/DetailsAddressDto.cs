namespace nopCommerceApi.Models.Address
{
    public class DetailsAddressDto : CountryDto
    {
        public int Id { get; set; }
        public string? NIP { get; set; }
        public int? StateProvinceId { get; set; }
        public int? CountryId { get; set; }
        public CountryDto? Country { get; set; }
        public StateProvinceDto? StateProvince { get; set; }
    }
}
