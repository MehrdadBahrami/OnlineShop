namespace OnlineShop.DomainLayer.Models
{
    /// <summary>
    /// Represents the specifics of a customer who wants to buy from the shopping.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the customer.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the customer.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the customer.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the password hash of the customer.
        /// </summary>
        public string? PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the address of the customer.
        /// </summary>
        public string? Address { get; set; }
    }
}
