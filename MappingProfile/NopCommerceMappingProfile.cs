using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using nopCommerceApi.Models.Address;

namespace nopCommerceApi.MappingProfile
{
    public class NopCommerceMappingProfile : Profile
    {
        public NopCommerceMappingProfile()
        {
            CreateMap<CustomerRole, CustomerRoleDto>();
            CreateMap<TierPrice, TierPriceDto>();
            CreateMap<Currency, CurrencyDto>();
            CreateMap<StateProvince, StateProvinceDto>();
            CreateMap<Language, LanguageDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Address, DetailsAddressDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<AddressAttribute, AddressAttributeDto>();

            CreateMap<CreatePolishEnterpriseAddressDto, Address>();
            CreateMap<UpdatePolishEnterpriseAddressDto, Address>();

        }
    }
}
