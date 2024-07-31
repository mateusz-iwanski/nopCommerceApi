namespace nopCommerceApi.Models.Product
{
    public class ProductUpdateBlockGiftCardDto : BaseDto
    {
        /// <summary>
        /// ## IsGiftCard
        /// ### Set a value indicating whether the product is gift card.
        /// #### Check if it is a gift card. After adding gift card products to the shopping cart and completing the purchases, 
        /// #### you can then search and view the list of all the purchased gift cards by selecting Gift Cards from the Sales menu.
        /// *Default = false*
        /// </summary>
        public virtual bool IsGiftCard { get; set; }

        /// <summary>
        /// ## GiftCardTypeId
        /// ### Set the gift card type identifier.
        /// ** Note: Defines the type of gift card **
        /// * virtual (0): A virtual gift card. (Default setting)
        /// * Physical (1): A physical gift card.
        /// </summary>
        public virtual int GiftCardTypeId { get; set; }

        /// <summary>
        /// ## OverriddenGiftCardAmount
        /// ### Set gift card amount that can be used after purchase. If not specified, then product price will be used.
        /// *Default = null*
        /// </summary>
        public virtual decimal? OverriddenGiftCardAmount { get; set; }
    }
}
