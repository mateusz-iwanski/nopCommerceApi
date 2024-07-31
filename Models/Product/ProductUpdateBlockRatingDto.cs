namespace nopCommerceApi.Models.Product
{
    public class ProductUpdateBlockRatingDto : BaseDto
    {
        /// <summary>
        /// ## ApprovedRatingSum
        /// ### Set the rating sum (approved reviews).
        /// #### Look on Configuration → Settings → Catalog settings for more details.
        /// #### When required is set in new review type, customers have to choose an appropriate rating value before they can continue.
        /// *Default = 0 (not approved)*
        /// </summary>
        public virtual int ApprovedRatingSum { get; set; }

        /// <summary>
        /// ## NotApprovedRatingSum
        /// ### Set the rating sum (not approved reviews).
        /// #### Look on Configuration → Settings → Catalog settings for more details.
        /// *Default = 0 (not approved)*
        /// </summary>
        public virtual int NotApprovedRatingSum { get; set; }
    }
}
