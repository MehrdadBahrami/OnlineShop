using OnlineShop.DomainLayer.Models;

namespace OnlineShop.ServiceLayer.Contract
{
    public interface ICartService
    {
        Task<Cart> GetCartByCustomerIdAsync(int customerId);
        Task AddItemToCartAsync(int customerId, int productId, int quantity);
        Task RemoveItemFromCartAsync(int customerId, int cartItemId);
        Task<decimal> GetCartTotalAsync(int customerId);
        Task UpdateCartItemQuantityAsync(int cartItemId, int newQuantity);
    }
}
