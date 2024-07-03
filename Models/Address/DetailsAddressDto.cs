namespace nopCommerceApi.Models.Address
{
    public class DetailsAddressDto : CountryDto
    {
        public CountryDto? Country { get; set; }
        public StateProvinceDto? StateProvince { get; set; }
    }
}
