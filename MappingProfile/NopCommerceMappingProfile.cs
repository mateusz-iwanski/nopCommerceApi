using AutoMapper;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Models;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Models.Category;
using nopCommerceApi.Models.Customer;
using nopCommerceApi.Models.Manufacturer;
using nopCommerceApi.Models.Picture;
using nopCommerceApi.Models.Product;
using nopCommerceApi.Models.ProductAttribute;
using nopCommerceApi.Models.ProductCategory;
using nopCommerceApi.Models.ProductManufacturer;
using nopCommerceApi.Models.UrlRecord;

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

            // get
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

            // update
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
            CreateMap<ProductCreateMinimalDto, Product>()
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Name.Trim()))
                .ForMember(x => x.Sku, opt => opt.MapFrom(y => y.Sku.Trim()));

            // update
            CreateMap<ProductUpdateBlockInformationDto, Product>();
            CreateMap<ProductUpdateBlockSeoDto, Product>();
            CreateMap<ProductUpdateBlockRatingDto, Product>();
            CreateMap<ProductUpdateBlockReviewsDto, Product>();
            CreateMap<ProductUpdateBlockGiftCardDto, Product>();
            CreateMap<ProductUpdateBlockDownloadDto, Product>();
            CreateMap<ProductUpdateBlockRecurringDto, Product>();
            CreateMap<ProductUpdateBlockRentalPriceDto, Product>();
            CreateMap<ProductUpdateBlockShippingDto, Product>();
            CreateMap<ProductUpdateBlockInventoryDto, Product>();
            CreateMap<ProductUpdateBlockAttributeDto, Product>();
            CreateMap<ProductUpdateBlockPriceDto, Product>();

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

            #region Category

            // get
            CreateMap<Category, CategoryDto>();

            // create
            CreateMap<CreateCategoryDto, Category>();

            //update
            CreateMap<UpdateCategoryDto, Category>();

            #endregion

            #region ProductCategoryMapping

            //get
            CreateMap<ProductCategoryMapping, ProductCategoryMappingDto>();

            //set
            CreateMap<ProductCategoryMappingCreateDto, ProductCategoryMapping>();

            #endregion

            #region ProductAttributeValue

            // get
            CreateMap<ProductAttributeValue, ProductAttributeValueDto>();

            // set 
            CreateMap<ProductAttributeValueDtoCreate, ProductAttributeValue>();

            // update
            CreateMap<ProductAttributeValueUpdateDto, ProductAttributeValue>();

            #endregion

            #region ProductAttribute

            // get
            CreateMap<ProductAttribute, ProductAttributeDto>();

            // set 
            CreateMap<ProductAttributeCreateDto, ProductAttribute>();

            // update
            CreateMap<ProductAttributeUpdateDto, ProductAttribute>();

            #endregion

            #region ProductProductAttributeMapping

            //get
            CreateMap<ProductProductAttributeMapping, ProductProductAttributeMappingDto>();

            //set
            CreateMap<ProductProductAttributeMappingCreateDto, ProductProductAttributeMapping>();

            //update
            CreateMap<ProductProductAttributeMappingUpdateDto, ProductProductAttributeMapping>();

            #endregion

            #region Manufacturer

            // get
            CreateMap<Manufacturer, ManufacturerDto>();

            // set 
            CreateMap<ManufacturerCreateDto, Manufacturer>();

            // update
            CreateMap<ManufacturerUpdateDto, Manufacturer>();

            #endregion

            #region ProductManufacturerMapping

            // get
            CreateMap<ProductManufacturerMapping, ProductManufacturerMappingDto>();

            // set 
            CreateMap<ProductManufacturerMappingCreateDto, ProductManufacturerMapping>();

            #endregion

            #region UrlRecord

            // get
            CreateMap<UrlRecord, UrlRecordDto>();

            // set 
            CreateMap<UrlRecordCreateDto, UrlRecord>();

            // update
            CreateMap<UrlRecordUpdateDto, UrlRecord>();


            #endregion

            #region Picture

            // get
            CreateMap<Picture, PictureDto>();

            // set 
            CreateMap<PictureCreateDto, Picture>();

            // update
            CreateMap<PictureUpdateDto, Picture>();

            #endregion

        }
    }
}
