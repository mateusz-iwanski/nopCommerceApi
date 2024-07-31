namespace nopCommerceApi.Models.Product
{
    public class ProductUpdateInventoryDto : BaseDto
    {
        /// <summary>
        /// ## ManageInventoryMethodId
        /// ### Set a value indicating how to manage inventory
        /// ** ManageInventoryMethod: Enumerates methods of inventory management **
        /// * DontManageStock (0): Do not track inventory for the product. (default setting)
        /// * ManageStock (1): Track inventory for the product.
        /// * ManageStockByAttributes (2): Track inventory for the product by product attributes.
        /// </summary>
        public virtual int ManageInventoryMethodId { get; set; }

        /// <summary>
        /// ## StockQuantity
        /// ### Set the stock quantity
        /// #### The current stock quantity of this product.
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1)
        /// *Default = 1000*
        /// </summary>
        public virtual int StockQuantity { get; set; }


        /// <summary>
        /// ## ProductAvailabilityRangeId
        /// ### Set a product availability range identifier.
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// #### Choose the product availability range that indicates when the product is expected to be 
        /// #### available when out of stock (e.g. Available in 10-14 days). 
        /// #### You can manage availability ranges by selecting Configuration > Shipping > Dates and ranges.
        /// #### Check ProductAvailabilityRange for more details.
        /// *Default = 0*
        /// </summary>
        public virtual int ProductAvailabilityRangeId { get; set; }

        /// <summary>
        /// ## UseMultipleWarehouses
        /// ### Set a value indicating whether multiple warehouses are used for this product
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) 
        /// #### Check if you want to support shipping and inventory management from multiple warehouses.
        /// *Default = false*
        /// </summary>
        public virtual bool UseMultipleWarehouses { get; set; }

        /// <summary>
        /// ## WarehouseId
        /// ### Set a warehouse identifier
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// *Default = 0*
        /// </summary>
        public virtual int WarehouseId { get; set; }

        /// <summary>
        /// ## DisplayStockAvailability
        /// ### Set a value indicating whether to display stock availability
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// #### Check to display stock availability. When enabled, customers will see stock availability.
        /// *Default = false*
        /// </summary>
        public virtual bool DisplayStockAvailability { get; set; }

        /// <summary>
        /// ## DisplayStockQuantity
        /// ### Set a value indicating whether to display stock quantity
        /// #### Enabled if DisplayStockAvailability is true.
        /// #### Check to display stock quantity. When enabled, customers will see stock quantity.
        /// *Default = False*
        /// </summary>
        public virtual bool DisplayStockQuantity { get; set; }

        /// <summary>
        /// ## MinStockQuantity
        /// ### Set the minimum stock quantity
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)        
        /// #### If you track inventory, you can perform a number of different actions when the current stock 
        /// #### quantity falls below (reaches) your minimum stock quantity.
        /// *Default = 0*
        /// </summary>
        public virtual int MinStockQuantity { get; set; }

        /// <summary>
        /// ## LowStockActivityId
        /// ### Set the low stock activity identifier
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// #### Action to be taken when your current stock quantity falls below (reaches) the 'Minimum stock quantity'. 
        /// #### Activation of the action will occur only after an order is placed. If the value is 'Nothing', 
        /// #### the product detail page will display a low-stock message in public store.
        /// ** LowStockActivity: Enumerates actions to be taken when product stock is low **
        /// * Nothing (0): Do not take any action. (default setting)
        /// * DisableBuyButton (1): Disable the buy button for the product.
        /// * Unpublish (2): Unpublish the product, making it unavailable for purchase.
        /// </summary>
        public virtual int LowStockActivityId { get; set; }

        /// <summary>
        /// ## NotifyAdminForQuantityBelow
        /// ### Set the quantity when admin should be notified
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) 
        /// #### When the current stock quantity falls below (reaches) this quantity, a store owner will receive a notification.
        /// *Default = 1*
        /// </summary>
        public virtual int NotifyAdminForQuantityBelow { get; set; }

        /// <summary>
        /// ## BackorderModeId
        /// ### Set a value backorder mode identifier
        /// ** BackorderModeId (enum): Identifies the backorder mode for the product **
        /// * NoBackorders (0): No backorders are allowed. (default setting)
        /// * AllowQtyBelow0 (1): Allow quantity below 0.
        /// * AllowQtyBelow0AndNotifyCustomer (2): Allow quantity below 0 and notify customer.
        /// </summary>
        public virtual int BackorderModeId { get; set; }

        /// <summary>
        /// ## AllowBackInStockSubscriptions
        /// ### Set a value indicating whether to back in stock subscriptions are allowed
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1)
        /// #### Allow customers to subscribe to a notification list for a product that has gone out of stock.
        /// *Default = false*
        /// </summary>
        public virtual bool AllowBackInStockSubscriptions { get; set; }

        /// <summary>
        /// ## OrderMinimumQuantity
        /// ### Set the order minimum quantity
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// #### Set the minimum quantity allowed in a customer's shopping cart e.g. set to 3 to only allow customers to purchase 3 or more of this product.
        /// *Default = 1*
        /// </summary>

        public virtual int OrderMinimumQuantity { get; set; }

        /// <summary>
        /// ## OrderMaximumQuantity
        /// ### Set the order maximum quantity
        /// #### Enabled only if ManageInventoryMethodId is set to ManageStock (1) or ManageStockByAttributes (2)
        /// #### Set the maximum quantity allowed in a customer's shopping cart e.g. set to 5 to only allow customers to purchase 5 of this product.
        /// *Default = 1000*
        /// </summary>
        public virtual int OrderMaximumQuantity { get; set; }

        /// <summary>
        /// ## NotReturnable
        /// ### Set a value indicating whether this product is returnable (a customer is allowed to submit return request with this product)
        /// ####Check if this product is not returnable. In this case a customer won't be allowed to submit return request.
        /// *Default = false*
        /// </summary>
        public virtual bool NotReturnable { get; set; }

        /// <summary>
        /// ## AllowedQuantities
        /// ### Set the comma separated list of allowed quantities. null or empty if any quantity is allowed.
        /// Instead of a quantity textbox that allows them to enter any quantity, they will receive a dropdown list of the values you enter here.        
        /// For example - if you type "10,20,30" then the customer will only be able to select one of those quantities.
        /// Default it's set to null.
        /// </summary>
        public virtual string? AllowedQuantities { get; set; }
    }
}
