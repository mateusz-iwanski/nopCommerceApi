namespace nopCommerceApi.Models.Product
{
    public class ProductUpdateRecurringDto : BaseDto
    {
        /// <summary>
        /// ## IsRecurring
        /// ### Set a value indicating whether the product is recurring.
        /// #### Check if it is a recurring product. For any product, you can define a recurring cycle to enable the system .
        /// #### to automatically create orders that repeat when a customer purchases such products.
        /// *Default = false*
        /// </summary>
        public virtual bool IsRecurring { get; set; }

        /// <summary>
        /// ## RecurringCycleLength
        /// ### Set the cycle length.
        /// #### Specify the cycle length. It is a time period recurring order can be repeated.
        /// *Default = 100*
        /// </summary>
        public virtual int RecurringCycleLength { get; set; }

        /// <summary>
        /// ## RecurringCyclePeriodId
        /// ### Set the cycle period.
        /// #### Specify the cycle period. It defines units time period can be measured in.
        /// ** Defines the cycle period for a recurring product **
        /// * Days (0): The cycle is in days. (default setting)
        /// * Weeks (10): The cycle is in weeks.
        /// * Months (20): The cycle is in months.
        /// * Years (30): The cycle is in years.
        /// </summary>
        public virtual int RecurringCyclePeriodId { get; set; }

        /// <summary>
        /// ## RecurringTotalCycles
        /// ### Set the total cycles.
        /// #### Total cycles are number of times customer will receive the recurring product.
        /// *Default = 10*
        /// </summary>
        public virtual int RecurringTotalCycles { get; set; }
    }
}
