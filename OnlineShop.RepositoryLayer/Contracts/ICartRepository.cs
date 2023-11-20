using OnlineShop.DomainLayer.Models;

namespace OnlineShop.RepositoryLayer.Contracts
{
    public interface ICartRepository
    {
        Cart GetCartByCustomerId(int customerId);
        void AddItemToCart(int customerId, int productId, int quantity);
        void RemoveItemFromCart(int customerId, int cartItemId);
        decimal GetCartTotal(int customerId);
        void UpdateCartItemQuantity(int cartItemId, int newQuantity);
    }
}
