using AutoMapper;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Models.Customer;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.MappingProfile
{
    public class NopCommerceMappingProfile : Profile
    {
        public NopCommerceMappingProfile()
        {
            #region Currency
            // get
            CreateMap<Currency, CurrencyDto>();

            #endregion

            #region StateProvince
            // get
            CreateMap<StateProvince, StateProvinceDto>();

            #endregion

            #region Language
            // get
            CreateMap<Language, LanguageDto>();

            #endregion

            #region Country
            // get
            CreateMap<Country, CountryDto>();

            #endregion

            #region Customer
            // get
            CreateMap<Customer, CustomerDto>();
            
            // create
            CreateMap<CustomerCreateBaseDto, Customer>()
               .ForMember(x => x.Email, opt => opt.MapFrom(y => y.Email.Trim()))
               .ForMember(x => x.Username, opt => opt.MapFrom(y => y.Username.Trim()))
               .ForMember(x => x.FirstName, opt => opt.MapFrom(y => y.FirstName.Trim()))
               .ForMember(x => x.LastName, opt => opt.MapFrom(y => y.LastName.Trim()))
               .ForMember(x => x.Company, opt => opt.MapFrom(y => y.Company.Trim()))
               .ForMember(x => x.StreetAddress, opt => opt.MapFrom(y => y.StreetAddress.Trim()))
               .ForMember(x => x.StreetAddress2, opt => opt.MapFrom(y => y.StreetAddress2.Trim()))
               .ForMember(x => x.ZipPostalCode, opt => opt.MapFrom(y => y.ZipPostalCode.Trim()))
               .ForMember(x => x.City, opt => opt.MapFrom(y => y.City.Trim()))
               .ForMember(x => x.County, opt => opt.MapFrom(y => y.County.Trim()))
               .ForMember(x => x.Phone, opt => opt.MapFrom(y => y.Phone.Trim()));

            #endregion

            #region CustomerRole
            // get
            CreateMap<CustomerRole, CustomerRoleDto>();

            #endregion

            #region Address

            CreateMap<Address, AddressDetailsDto>()
                .ForMember(x => x.NIP, opt => opt.MapFrom(y => AddressDto.GetValueFromCustomAttribute(y.CustomAttributes)));

            // create
            CreateMap<AddressCreatePolishEnterpriseDto, Address>()
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

            CreateMap<AddressUpdatePolishEnterpriseDto, Address>()
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

            CreateMap<AddressUpdateDto, Address>()
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

            CreateMap<AddressCreateDto, Address>()
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

            #endregion

            #region AddressAttribute

            // get
            CreateMap<AddressAttribute, AddressAttributeDto>();

            #endregion

            #region TaxCategory
            //get
            CreateMap<TaxCategory, TaxCategoryDto>();
            #endregion

            #region Product

            // get
            CreateMap<Product, ProductDto>();

            // create
            CreateMap<ProductCreateDto, Product>()
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Name.Trim()))
                .ForMember(x => x.Sku, opt => opt.MapFrom(y => y.Sku.Trim()))
                .ForMember(x => x.ShortDescription, opt => opt.MapFrom(y => y.ShortDescription.Trim()))
                .ForMember(x => x.FullDescription, opt => opt.MapFrom(y => y.FullDescription.Trim()))
                .ForMember(x => x.ManufacturerPartNumber, opt => opt.MapFrom(y => y.ManufacturerPartNumber.Trim()))
                .ForMember(x => x.Gtin, opt => opt.MapFrom(y => y.Gtin.Trim()))
                .ForMember(x => x.RequiredProductIds, opt => opt.MapFrom(y => y.RequiredProductIds.Trim()))
                .ForMember(x => x.AdminComment, opt => opt.MapFrom(y => y.AdminComment.Trim()))
                .ForMember(x => x.MetaKeywords, opt => opt.MapFrom(y => y.MetaKeywords.Trim()))
                .ForMember(x => x.MetaTitle, opt => opt.MapFrom(y => y.MetaTitle.Trim()))
                .ForMember(x => x.MetaDescription, opt => opt.MapFrom(y => y.MetaDescription.Trim()))
                .ForMember(x => x.UserAgreementText, opt => opt.MapFrom(y => y.UserAgreementText.Trim()))
                .ForMember(x => x.AllowedQuantities, opt => opt.MapFrom(y => y.AllowedQuantities.Trim()));

            CreateMap<ProductCreateMinimalDto, Product>()
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Name.Trim()))
                .ForMember(x => x.Sku, opt => opt.MapFrom(y => y.Sku.Trim()));


            #endregion

            #region ProductTag

            // get
            CreateMap<ProductTag, ProductTagDto>();
            CreateMap<ProductTag, ProductTagDetailsDto>();

            // create
            CreateMap<ProductTagCreateDto, ProductTag>();

            #endregion

            #region ProductTemplate
            // get
            CreateMap<ProductTemplate, ProductTemplateDto>();

            #endregion

            #region ProductAvailabilityRange
            // get
            CreateMap<ProductAvailabilityRange, ProductAvailabilityRangeDto>();

            // add
            CreateMap<ProductAvailabilityRangeCreateDto, ProductAvailabilityRange>();
            #endregion

            #region TrierPrice

            CreateMap<TierPrice, TierPriceDto>();
            CreateMap<TierPrice, TierPriceDetailsDto>();

            #endregion

            



        }
    }
}
