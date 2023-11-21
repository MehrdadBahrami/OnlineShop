namespace OnlineShop.DomainLayer.Models
{
    /// <summary>
    /// Represents the total order that a customer can make and place.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the unique identifier of the order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the customer placing the order.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the time when the order was placed.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the order.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the final status of the order.
        /// Possible values: "placed", "canceled", "fail".
        /// </summary>
        public string? OrderStatus { get; set; }
    }
}
