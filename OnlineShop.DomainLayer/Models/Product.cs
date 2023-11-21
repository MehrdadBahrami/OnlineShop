namespace OnlineShop.DomainLayer.Models
{
    /// <summary>
    /// Represents each product in the product library.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier of each product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of each product.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the description for each product in the library.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the price of each product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in stock.
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the category of each product.
        /// </summary>
        public string? Category { get; set; }
    }
}
