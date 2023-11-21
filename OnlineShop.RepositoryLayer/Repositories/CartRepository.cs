using OnlineShop.DomainLayer.Models;
using OnlineShop.RepositoryLayer.Contracts;

namespace OnlineShop.RepositoryLayer.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly List<Cart> _carts = new();
        void ICartRepository.AddItemToCart(int customerId, int productId, int quantity)
        {
            var cart = _carts.FirstOrDefault(c => c.CustomerId == customerId);

                

            if (cart is null)
            {
                // Create a new cart if one doesn't exist for the customer
                cart = new Cart { CustomerId = customerId };
                _carts.Add(cart);
            }

            var cartItem = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);

            if (cartItem != null)
            {
                // Update existing cart item quantity
                cartItem.Quantity += quantity;
            }
            else
            {
                // Add a new cart item
                cart.CartItems.Add(new CartItem { ProductId = productId, Quantity = quantity });
            }
        }

        Cart ICartRepository.GetCartByCustomerId(int customerId)
        {
            return _carts.FirstOrDefault(c => c.CustomerId == customerId) ??
                new Cart()
                {
                    CartId = 0,
                    CustomerId = 0,
                    CartItems = new List<CartItem>()

                };
        }

        decimal ICartRepository.GetCartTotal(int customerId)
        {
            var cart = _carts.FirstOrDefault(c => c.CustomerId == customerId);
            
            if (cart != null)
                 // Calculate the total based on cart items
                return cart.CartItems.Sum(item => item.TotalPrice);
            

            return 0; // Return 0 if the cart doesn't exist or is empty
        }

        void ICartRepository.RemoveItemFromCart(int customerId, int cartItemId)
        {
            var cart = _carts.FirstOrDefault(c => c.CustomerId == customerId);

            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(item => item.CartItemId == cartItemId);

                if (cartItem != null)
                {
                    // Remove the cart item
                    cart.CartItems.Remove(cartItem);
                }
            }
        }

        void ICartRepository.UpdateCartItemQuantity(int cartItemId, int newQuantity)
        {
            var cartItem = _carts.SelectMany(c => c.CartItems).FirstOrDefault(item => item.CartItemId == cartItemId);

            if (cartItem != null)
            {
                cartItem.Quantity = newQuantity;
            }
        }
    }
}
