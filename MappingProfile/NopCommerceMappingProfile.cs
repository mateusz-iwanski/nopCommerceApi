using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.MappingProfile
{
    public class NopCommerceMappingProfile : Profile
    {
        public NopCommerceMappingProfile()
        {
            CreateMap<Currency, CurrencyDto>();
            CreateMap<StateProvince, StateProvinceDto>();
            CreateMap<Language, LanguageDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}
