using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Models.Customer;

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


            CreateMap<CreatePolishEnterpriseAddressDto, Address>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(y => y.FirstName.Trim()))
                .ForMember(x => x.LastName, opt => opt.MapFrom(y => y.LastName.Trim()))
                .ForMember(x => x.Email, opt => opt.MapFrom(y => y.Email.Trim()))
                .ForMember(x => x.Company, opt => opt.MapFrom(y => y.Company.Trim()))
                .ForMember(x => x.County, opt => opt.MapFrom(y => y.County.Trim()))
                .ForMember(x => x.City, opt => opt.MapFrom(y => y.City.Trim()))
                .ForMember(x => x.Address1, opt => opt.MapFrom(y => y.Address1.Trim()))
                .ForMember(x => x.Address2, opt => opt.MapFrom(y => y.Address2.Trim()))
                .ForMember(x => x.ZipPostalCode, opt => opt.MapFrom(y => y.ZipPostalCode.Trim()))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(y => y.PhoneNumber.Trim()));

            CreateMap<UpdatePolishEnterpriseAddressDto, Address>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(y => y.FirstName.Trim()))
                .ForMember(x => x.LastName, opt => opt.MapFrom(y => y.LastName.Trim()))
                .ForMember(x => x.Email, opt => opt.MapFrom(y => y.Email.Trim()))
                .ForMember(x => x.Company, opt => opt.MapFrom(y => y.Company.Trim()))
                .ForMember(x => x.County, opt => opt.MapFrom(y => y.County.Trim()))
                .ForMember(x => x.City, opt => opt.MapFrom(y => y.City.Trim()))
                .ForMember(x => x.Address1, opt => opt.MapFrom(y => y.Address1.Trim()))
                .ForMember(x => x.Address2, opt => opt.MapFrom(y => y.Address2.Trim()))
                .ForMember(x => x.ZipPostalCode, opt => opt.MapFrom(y => y.ZipPostalCode.Trim()))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(y => y.PhoneNumber.Trim()));

            CreateMap<CreatePolishUserAddressDto, Address>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(y => y.FirstName.Trim()))
                .ForMember(x => x.LastName, opt => opt.MapFrom(y => y.LastName.Trim()))
                .ForMember(x => x.Email, opt => opt.MapFrom(y => y.Email.Trim()))
                .ForMember(x => x.Company, opt => opt.MapFrom(y => y.Company.Trim()))
                .ForMember(x => x.County, opt => opt.MapFrom(y => y.County.Trim()))
                .ForMember(x => x.City, opt => opt.MapFrom(y => y.City.Trim()))
                .ForMember(x => x.Address1, opt => opt.MapFrom(y => y.Address1.Trim()))
                .ForMember(x => x.Address2, opt => opt.MapFrom(y => y.Address2.Trim()))
                .ForMember(x => x.ZipPostalCode, opt => opt.MapFrom(y => y.ZipPostalCode.Trim()))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(y => y.PhoneNumber.Trim()));

            CreateMap<UpdateAddressDto, Address>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(y => y.FirstName.Trim()))
                .ForMember(x => x.LastName, opt => opt.MapFrom(y => y.LastName.Trim()))
                .ForMember(x => x.Email, opt => opt.MapFrom(y => y.Email.Trim()))
                .ForMember(x => x.Company, opt => opt.MapFrom(y => y.Company.Trim()))
                .ForMember(x => x.County, opt => opt.MapFrom(y => y.County.Trim()))
                .ForMember(x => x.City, opt => opt.MapFrom(y => y.City.Trim()))
                .ForMember(x => x.Address1, opt => opt.MapFrom(y => y.Address1.Trim()))
                .ForMember(x => x.Address2, opt => opt.MapFrom(y => y.Address2.Trim()))
                .ForMember(x => x.ZipPostalCode, opt => opt.MapFrom(y => y.ZipPostalCode.Trim()))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(y => y.PhoneNumber.Trim()));

            CreateMap<CreateAddressDto, Address>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(y => y.FirstName.Trim()))
                .ForMember(x => x.LastName, opt => opt.MapFrom(y => y.LastName.Trim()))
                .ForMember(x => x.Email, opt => opt.MapFrom(y => y.Email.Trim()))
                .ForMember(x => x.Company, opt => opt.MapFrom(y => y.Company.Trim()))
                .ForMember(x => x.County, opt => opt.MapFrom(y => y.County.Trim()))
                .ForMember(x => x.City, opt => opt.MapFrom(y => y.City.Trim()))
                .ForMember(x => x.Address1, opt => opt.MapFrom(y => y.Address1.Trim()))
                .ForMember(x => x.Address2, opt => opt.MapFrom(y => y.Address2.Trim()))
                .ForMember(x => x.ZipPostalCode, opt => opt.MapFrom(y => y.ZipPostalCode.Trim()))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(y => y.PhoneNumber.Trim()));

        }
    }
}
