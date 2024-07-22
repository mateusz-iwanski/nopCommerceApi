namespace nopCommerceApi.Models.Product
{
    public class ProductDto : BaseDto
    {
        public int Id { get; set; } 
        public virtual string Name { get; set; }
        public virtual string? MetaKeywords { get; set; }
        public virtual string? MetaTitle { get; set; }

        public virtual string? Sku { get; set; }

        public virtual string? ManufacturerPartNumber { get; set; }

        public virtual string? Gtin { get; set; }

        public virtual string? RequiredProductIds { get; set; }

        public virtual string? AllowedQuantities { get; set; }

        public virtual int ProductTypeId { get; set; }

        public virtual int ParentGroupedProductId { get; set; }

        public virtual bool VisibleIndividually { get; set; }

        public virtual string? ShortDescription { get; set; }

        public virtual string? FullDescription { get; set; }

        public virtual string? AdminComment { get; set; }

        public virtual int ProductTemplateId { get; set; }

        public virtual int VendorId { get; set; }

        public virtual bool ShowOnHomepage { get; set; }

        public virtual string? MetaDescription { get; set; }

        public virtual bool AllowCustomerReviews { get; set; }

        public virtual int ApprovedRatingSum { get; set; }

        public virtual int NotApprovedRatingSum { get; set; }

        public virtual int ApprovedTotalReviews { get; set; }

        public virtual int NotApprovedTotalReviews { get; set; }

        public virtual bool SubjectToAcl { get; set; }

        public virtual bool LimitedToStores { get; set; }

        public virtual bool IsGiftCard { get; set; }

        public virtual int GiftCardTypeId { get; set; }

        public virtual decimal? OverriddenGiftCardAmount { get; set; }

        public virtual bool RequireOtherProducts { get; set; }

        public virtual bool AutomaticallyAddRequiredProducts { get; set; }

        public virtual bool IsDownload { get; set; }

        public virtual int DownloadId { get; set; }

        public virtual bool UnlimitedDownloads { get; set; }

        public virtual int MaxNumberOfDownloads { get; set; }

        public virtual int? DownloadExpirationDays { get; set; }

        public virtual int DownloadActivationTypeId { get; set; }

        public virtual bool HasSampleDownload { get; set; }

        public virtual int SampleDownloadId { get; set; }

        public virtual bool HasUserAgreement { get; set; }

        public virtual string? UserAgreementText { get; set; }

        public virtual bool IsRecurring { get; set; }

        public virtual int RecurringCycleLength { get; set; }

        public virtual int RecurringCyclePeriodId { get; set; }

        public virtual int RecurringTotalCycles { get; set; }

        public virtual bool IsRental { get; set; }

        public virtual int RentalPriceLength { get; set; }

        public virtual int RentalPricePeriodId { get; set; }

        public virtual bool IsShipEnabled { get; set; }

        public virtual bool IsFreeShipping { get; set; }

        public virtual bool ShipSeparately { get; set; }

        public virtual decimal AdditionalShippingCharge { get; set; }

        public virtual int DeliveryDateId { get; set; }

        public virtual bool IsTaxExempt { get; set; }

        public virtual int TaxCategoryId { get; set; }

        public virtual int ManageInventoryMethodId { get; set; }

        public virtual int ProductAvailabilityRangeId { get; set; }

        public virtual bool UseMultipleWarehouses { get; set; }

        public virtual int WarehouseId { get; set; }

        public virtual int StockQuantity { get; set; }

        public virtual bool DisplayStockAvailability { get; set; }

        public virtual bool DisplayStockQuantity { get; set; }

        public virtual int MinStockQuantity { get; set; }

        public virtual int LowStockActivityId { get; set; }

        public virtual int NotifyAdminForQuantityBelow { get; set; }

        public virtual int BackorderModeId { get; set; }

        public virtual bool AllowBackInStockSubscriptions { get; set; }

        public virtual int OrderMinimumQuantity { get; set; }

        public virtual int OrderMaximumQuantity { get; set; }

        public virtual bool AllowAddingOnlyExistingAttributeCombinations { get; set; }

        public virtual bool DisplayAttributeCombinationImagesOnly { get; set; }

        public virtual bool NotReturnable { get; set; }

        public virtual bool DisableBuyButton { get; set; }

        public virtual bool DisableWishlistButton { get; set; }

        public virtual bool AvailableForPreOrder { get; set; }

        public virtual DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }

        public virtual bool CallForPrice { get; set; }

        public virtual decimal Price { get; set; }

        public virtual decimal OldPrice { get; set; }

        public virtual decimal ProductCost { get; set; }

        public virtual bool CustomerEntersPrice { get; set; }

        public virtual decimal MinimumCustomerEnteredPrice { get; set; }

        public virtual decimal MaximumCustomerEnteredPrice { get; set; }

        public virtual bool BasepriceEnabled { get; set; }

        public virtual decimal BasepriceAmount { get; set; }

        public virtual int BasepriceUnitId { get; set; }

        public virtual decimal BasepriceBaseAmount { get; set; }

        public virtual int BasepriceBaseUnitId { get; set; }

        public virtual bool MarkAsNew { get; set; }

        public virtual DateTime? MarkAsNewStartDateTimeUtc { get; set; }

        public virtual DateTime? MarkAsNewEndDateTimeUtc { get; set; }

        public virtual bool HasTierPrices { get; set; }

        public virtual bool HasDiscountsApplied { get; set; }

        public virtual decimal Weight { get; set; }

        public virtual decimal Length { get; set; }

        public virtual decimal Width { get; set; }

        public virtual decimal Height { get; set; }

        public virtual DateTime? AvailableStartDateTimeUtc { get; set; }

        public virtual DateTime? AvailableEndDateTimeUtc { get; set; }

        public virtual int DisplayOrder { get; set; }

        public virtual bool Published { get; set; }

        public virtual bool Deleted { get; set; }

        public virtual DateTime CreatedOnUtc { get; set; }

        public virtual DateTime UpdatedOnUtc { get; set; }

    }
}
