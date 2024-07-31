namespace nopCommerceApi.Models.Product
{
    public class ProductUpdateBlockReviewsDto : BaseDto
    {
        /// <summary>
        /// ## AllowCustomerReviews
        /// ### Set a value indicating whether the product allows customer reviews.
        /// #### By default, the reviews must be approved by the store owner before they appear in the public store. 
        /// #### However, in case a store owner decides that reviews do not have to be approved, this default behavior can be changed. 
        /// #### To opt out of the obligatory product reviews' approval, go to Configuration → Settings → Catalog settings and clear the Product reviews must be approved option.
        /// *Default = false*
        /// </summary>

        public virtual bool AllowCustomerReviews { get; set; }

        /// <summary>
        /// ## ApprovedTotalReviews
        /// ### Set the total rating votes (approved reviews).
        /// #### Look on Configuration → Settings → Catalog settings for more details.
        /// *Default = 0 (not approved)*
        /// </summary>
        public virtual int ApprovedTotalReviews { get; set; }

        /// <summary>
        /// ## NotApprovedTotalReviews
        /// ### Set the total rating votes (not approved reviews).
        /// #### Look on Configuration → Settings → Catalog settings for more details.
        /// *Default = 0 (not approved)*
        /// </summary>
        public virtual int NotApprovedTotalReviews { get; set; }
    }
}
