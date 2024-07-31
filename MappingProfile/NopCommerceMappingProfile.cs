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

            // update
            CreateMap<ProductUpdateInformationDto, Product>();
            CreateMap<ProductUpdateSeoDto, Product>();
            CreateMap<ProductUpdateRatingDto, Product>();

            // update
            CreateMap<ProductUpdateDto, Product>()
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
                .ForMember(x => x.AllowedQuantities, opt => opt.MapFrom(y => y.AllowedQuantities.Trim()))
                .ForMember(x => x.ProductTypeId, opt => opt.MapFrom((src, dest) => src.ProductTypeId ?? dest.ProductTypeId))
                .ForMember(x => x.ProductTemplateId, opt => opt.MapFrom((src, dest) => src.ProductTemplateId ?? dest.ProductTemplateId))
                .ForMember(x => x.VendorId, opt => opt.MapFrom((src, dest) => src.VendorId ?? dest.VendorId))
                .ForMember(x => x.DisplayOrder, opt => opt.MapFrom((src, dest) => src.DisplayOrder ?? dest.DisplayOrder))
                .ForMember(x => x.ParentGroupedProductId, opt => opt.MapFrom((src, dest) => src.ParentGroupedProductId ?? dest.ParentGroupedProductId))
                .ForMember(x => x.ApprovedRatingSum, opt => opt.MapFrom((src, dest) => src.ApprovedRatingSum ?? dest.ApprovedRatingSum))
                .ForMember(x => x.NotApprovedRatingSum, opt => opt.MapFrom((src, dest) => src.NotApprovedRatingSum ?? dest.NotApprovedRatingSum))
                .ForMember(x => x.StockQuantity, opt => opt.MapFrom((src, dest) => src.StockQuantity ?? dest.StockQuantity))
                .ForMember(x => x.MinStockQuantity, opt => opt.MapFrom((src, dest) => src.MinStockQuantity ?? dest.MinStockQuantity))
                .ForMember(x => x.NotifyAdminForQuantityBelow, opt => opt.MapFrom((src, dest) => src.NotifyAdminForQuantityBelow ?? dest.NotifyAdminForQuantityBelow))
                .ForMember(x => x.OrderMinimumQuantity, opt => opt.MapFrom((src, dest) => src.OrderMinimumQuantity ?? dest.OrderMinimumQuantity))
                .ForMember(x => x.OrderMaximumQuantity, opt => opt.MapFrom((src, dest) => src.OrderMaximumQuantity ?? dest.OrderMaximumQuantity))
                .ForMember(x => x.WarehouseId, opt => opt.MapFrom((src, dest) => src.WarehouseId ?? dest.WarehouseId))
                .ForMember(x => x.ApprovedTotalReviews, opt => opt.MapFrom((src, dest) => src.ApprovedTotalReviews ?? dest.ApprovedTotalReviews))
                .ForMember(x => x.NotApprovedTotalReviews, opt => opt.MapFrom((src, dest) => src.NotApprovedTotalReviews ?? dest.NotApprovedTotalReviews))
                .ForMember(x => x.RecurringCycleLength, opt => opt.MapFrom((src, dest) => src.RecurringCycleLength ?? dest.RecurringCycleLength))
                .ForMember(x => x.RecurringCyclePeriodId, opt => opt.MapFrom((src, dest) => src.RecurringCyclePeriodId ?? dest.RecurringCyclePeriodId))
                .ForMember(x => x.RecurringTotalCycles, opt => opt.MapFrom((src, dest) => src.RecurringTotalCycles ?? dest.RecurringTotalCycles))
                .ForMember(x => x.RentalPriceLength, opt => opt.MapFrom((src, dest) => src.RentalPriceLength ?? dest.RentalPriceLength))
                .ForMember(x => x.RentalPricePeriodId, opt => opt.MapFrom((src, dest) => src.RentalPricePeriodId ?? dest.RentalPricePeriodId))
                .ForMember(x => x.GiftCardTypeId, opt => opt.MapFrom((src, dest) => src.GiftCardTypeId ?? dest.GiftCardTypeId))
                .ForMember(x => x.DownloadId, opt => opt.MapFrom((src, dest) => src.DownloadId ?? dest.DownloadId))
                .ForMember(x => x.MaxNumberOfDownloads, opt => opt.MapFrom((src, dest) => src.MaxNumberOfDownloads ?? dest.MaxNumberOfDownloads))
                .ForMember(x => x.DownloadActivationTypeId, opt => opt.MapFrom((src, dest) => src.DownloadActivationTypeId ?? dest.DownloadActivationTypeId))
                .ForMember(x => x.SampleDownloadId, opt => opt.MapFrom((src, dest) => src.SampleDownloadId ?? dest.SampleDownloadId))
                .ForMember(x => x.DeliveryDateId, opt => opt.MapFrom((src, dest) => src.DeliveryDateId ?? dest.DeliveryDateId))
                .ForMember(x => x.ManageInventoryMethodId, opt => opt.MapFrom((src, dest) => src.ManageInventoryMethodId ?? dest.ManageInventoryMethodId))
                .ForMember(x => x.ProductAvailabilityRangeId, opt => opt.MapFrom((src, dest) => src.ProductAvailabilityRangeId ?? dest.ProductAvailabilityRangeId))
                .ForMember(x => x.LowStockActivityId, opt => opt.MapFrom((src, dest) => src.LowStockActivityId ?? dest.LowStockActivityId))
                .ForMember(x => x.BackorderModeId, opt => opt.MapFrom((src, dest) => src.BackorderModeId ?? dest.BackorderModeId))
                .ForMember(x => x.BasepriceUnitId, opt => opt.MapFrom((src, dest) => src.BasepriceUnitId ?? dest.BasepriceUnitId))
                .ForMember(x => x.BasepriceBaseUnitId, opt => opt.MapFrom((src, dest) => src.BasepriceBaseUnitId ?? dest.BasepriceBaseUnitId))
                .ForMember(x => x.TaxCategoryId, opt => opt.MapFrom((src, dest) => src.TaxCategoryId ?? dest.TaxCategoryId))
                .ForMember(x => x.AutomaticallyAddRequiredProducts, opt => opt.MapFrom((src, dest) => src.AutomaticallyAddRequiredProducts ?? dest.AutomaticallyAddRequiredProducts))

                // bool
                .ForMember(x => x.Published, opt => opt.MapFrom((src, dest) => src.Published ?? dest.Published))
                .ForMember(x => x.Deleted, opt => opt.MapFrom((src, dest) => src.Deleted ?? dest.Deleted))
                .ForMember(x => x.RequireOtherProducts, opt => opt.MapFrom((src, dest) => src.RequireOtherProducts ?? dest.RequireOtherProducts))
                .ForMember(x => x.ShowOnHomepage, opt => opt.MapFrom((src, dest) => src.ShowOnHomepage ?? dest.ShowOnHomepage))
                .ForMember(x => x.VisibleIndividually, opt => opt.MapFrom((src, dest) => src.VisibleIndividually ?? dest.VisibleIndividually))
                .ForMember(x => x.SubjectToAcl, opt => opt.MapFrom((src, dest) => src.SubjectToAcl ?? dest.SubjectToAcl))
                .ForMember(x => x.LimitedToStores, opt => opt.MapFrom((src, dest) => src.LimitedToStores ?? dest.LimitedToStores))
                .ForMember(x => x.MarkAsNew, opt => opt.MapFrom((src, dest) => src.MarkAsNew ?? dest.MarkAsNew))
                .ForMember(x => x.AllowCustomerReviews, opt => opt.MapFrom((src, dest) => src.AllowCustomerReviews ?? dest.AllowCustomerReviews))
                .ForMember(x => x.IsGiftCard, opt => opt.MapFrom((src, dest) => src.IsGiftCard ?? dest.IsGiftCard))
                .ForMember(x => x.IsDownload, opt => opt.MapFrom((src, dest) => src.IsDownload ?? dest.IsDownload))
                .ForMember(x => x.UnlimitedDownloads, opt => opt.MapFrom((src, dest) => src.UnlimitedDownloads ?? dest.UnlimitedDownloads))
                .ForMember(x => x.HasSampleDownload, opt => opt.MapFrom((src, dest) => src.HasSampleDownload ?? dest.HasSampleDownload))
                .ForMember(x => x.HasUserAgreement, opt => opt.MapFrom((src, dest) => src.HasUserAgreement ?? dest.HasUserAgreement))
                .ForMember(x => x.IsRecurring, opt => opt.MapFrom((src, dest) => src.IsRecurring ?? dest.IsRecurring))
                .ForMember(x => x.IsRental, opt => opt.MapFrom((src, dest) => src.IsRental ?? dest.IsRental))
                .ForMember(x => x.IsShipEnabled, opt => opt.MapFrom((src, dest) => src.IsShipEnabled ?? dest.IsShipEnabled))
                .ForMember(x => x.IsFreeShipping, opt => opt.MapFrom((src, dest) => src.IsFreeShipping ?? dest.IsFreeShipping))
                .ForMember(x => x.ShipSeparately, opt => opt.MapFrom((src, dest) => src.ShipSeparately ?? dest.ShipSeparately))
                .ForMember(x => x.UseMultipleWarehouses, opt => opt.MapFrom((src, dest) => src.UseMultipleWarehouses ?? dest.UseMultipleWarehouses))
                .ForMember(x => x.DisplayStockAvailability, opt => opt.MapFrom((src, dest) => src.DisplayStockAvailability ?? dest.DisplayStockAvailability))
                .ForMember(x => x.DisplayStockQuantity, opt => opt.MapFrom((src, dest) => src.DisplayStockQuantity ?? dest.DisplayStockQuantity))
                .ForMember(x => x.AllowBackInStockSubscriptions, opt => opt.MapFrom((src, dest) => src.AllowBackInStockSubscriptions ?? dest.AllowBackInStockSubscriptions))
                .ForMember(x => x.NotReturnable, opt => opt.MapFrom((src, dest) => src.NotReturnable ?? dest.NotReturnable))
                .ForMember(x => x.AllowAddingOnlyExistingAttributeCombinations, opt => opt.MapFrom((src, dest) => src.AllowAddingOnlyExistingAttributeCombinations ?? dest.AllowAddingOnlyExistingAttributeCombinations))
                .ForMember(x => x.DisplayAttributeCombinationImagesOnly, opt => opt.MapFrom((src, dest) => src.DisplayAttributeCombinationImagesOnly ?? dest.DisplayAttributeCombinationImagesOnly))
                .ForMember(x => x.DisableBuyButton, opt => opt.MapFrom((src, dest) => src.DisableBuyButton ?? dest.DisableBuyButton))
                .ForMember(x => x.DisableWishlistButton, opt => opt.MapFrom((src, dest) => src.DisableWishlistButton ?? dest.DisableWishlistButton))
                .ForMember(x => x.AvailableForPreOrder, opt => opt.MapFrom((src, dest) => src.AvailableForPreOrder ?? dest.AvailableForPreOrder))
                .ForMember(x => x.CallForPrice, opt => opt.MapFrom((src, dest) => src.CallForPrice ?? dest.CallForPrice))
                .ForMember(x => x.CustomerEntersPrice, opt => opt.MapFrom((src, dest) => src.CustomerEntersPrice ?? dest.CustomerEntersPrice))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));



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
