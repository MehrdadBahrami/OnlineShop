using OnlineShop.DomainLayer.Models;
using OnlineShop.RepositoryLayer.Contracts;
using OnlineShop.ServiceLayer.Contract;

namespace OnlineShop.ServiceLayer.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        async Task ICartService.AddItemToCartAsync(int customerId, int productId, int quantity) =>
        await Task.Run(() => _cartRepository.AddItemToCart(customerId, productId, quantity));


        async Task<Cart> ICartService.GetCartByCustomerIdAsync(int customerId) =>
        await Task.Run(() => _cartRepository.GetCartByCustomerId(customerId));


        async Task<decimal> ICartService.GetCartTotalAsync(int customerId) => 
        await Task.Run(() => _cartRepository.GetCartTotal(customerId));

        async Task ICartService.RemoveItemFromCartAsync(int customerId, int cartItemId) => 
        await Task.Run(() => _cartRepository.RemoveItemFromCart(customerId, cartItemId));

        async Task ICartService.UpdateCartItemQuantityAsync(int cartItemId, int newQuantity) =>
        await Task.Run(() => _cartRepository.UpdateCartItemQuantity(cartItemId, newQuantity));

    }
}
