namespace nopCommerceApi.Models
{
    public class StateProvinceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Abbreviation { get; set; }
        public int CountryId { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }

        public CountryDto Country { get; set; }
    }
}
