namespace nopCommerceApi.Models.Product
{
    public class ProductUpdateRentalDto : BaseDto
    {
        /// <summary>
        /// ## IsRental
        /// ### Set a value indicating whether the product is rental
        /// #### Check if this is a rental product (price is set for some period). Please note that inventory management is not fully 
        /// #### supported for rental products yet. It's recommended to set 'Manage inventory method' to 'Don't track inventory' now.
        /// *Default = false*
        /// </summary>
        public virtual bool IsRental { get; set; }

        /// <summary>
        /// ## RentalPriceLength
        /// ### Set the rental length for some period (price for this period)
        /// #### Price is specified for this period.
        /// *Default = 1*
        /// </summary>
        public virtual int RentalPriceLength { get; set; }

        /// <summary>
        /// ## RentalPricePeriodId
        /// ### Set the rental period (price for this period)
        /// ** Defines the cycle period for a rental period **
        /// * Days (0): The cycle is in days. (default setting)
        /// * Weeks (10): The cycle is in weeks.
        /// * Months (20): The cycle is in months.
        /// * Years (30): The cycle is in years.
        /// </summary>
        public virtual int RentalPricePeriodId { get; set; }
    }
}
