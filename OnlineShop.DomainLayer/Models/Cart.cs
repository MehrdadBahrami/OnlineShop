using System.Collections.Generic;

namespace OnlineShop.DomainLayer.Models
{
    /// <summary>
    /// Represents the shopping basket.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Gets or sets the unique identifier of the shopping basket.
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the customer who owns the basket.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the list of items in the shopping basket.
        /// </summary>
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
