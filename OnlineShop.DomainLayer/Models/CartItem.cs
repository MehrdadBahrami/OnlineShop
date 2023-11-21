namespace OnlineShop.DomainLayer.Models
{
    /// <summary>
    /// Represents an item that can be added to the shopping basket.
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Gets or sets the unique identifier of the cart item.
        /// </summary>
        public int CartItemId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the product added to the basket.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the basket.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the total price of the item in the basket.
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}
