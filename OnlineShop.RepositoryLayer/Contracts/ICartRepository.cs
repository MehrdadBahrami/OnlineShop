using OnlineShop.DomainLayer.Models;

namespace OnlineShop.RepositoryLayer.Contracts
{
    /// <summary>
    /// Repository interface for managing cart data.
    /// </summary>
    public interface ICartRepository
    {
        /// <summary>
        /// Retrieve the cart for a specific customer.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <returns>The cart entity representing the customer's shopping basket.</returns>
        Cart GetCartByCustomerId(int customerId);

        /// <summary>
        /// Add a product to the customer's shopping basket with a specified quantity.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <param name="productId">The unique identifier of the product to add to the cart.</param>
        /// <param name="quantity">The quantity of the product to add to the cart.</param>
        void AddItemToCart(int customerId, int productId, int quantity);

        /// <summary>
        /// Remove an item from the customer's shopping basket.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <param name="cartItemId">The unique identifier of the cart item to remove.</param>
        void RemoveItemFromCart(int customerId, int cartItemId);

        /// <summary>
        /// Get the total value of the items in the customer's shopping basket.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <returns>The total value of the items in the cart.</returns>
        decimal GetCartTotal(int customerId);

        /// <summary>
        /// Update the quantity of a specific product in the customer's shopping basket.
        /// </summary>
        /// <param name="cartItemId">The unique identifier of the cart item to update.</param>
        /// <param name="newQuantity">The new quantity of the product in the cart.</param>
        void UpdateCartItemQuantity(int cartItemId, int newQuantity);
    }
}
