using OnlineShop.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryLayer.Contracts
{
    internal interface ICartRepository
    {
        Cart GetCartByCustomerId(int customerId);
        void AddItemToCart(int customerId, int productId, int quantity);
        void RemoveItemFromCart(int customerId, int cartItemId);
        decimal GetCartTotal(int customerId);
        void UpdateCartItemQuantity(int cartItemId, int newQuantity);
    }
}
