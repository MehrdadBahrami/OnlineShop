using OnlineShop.DomainLayer.Models;

namespace OnlineShop.ServiceLayer.Contract
{
    public interface IOrderService
    {
        Task<Order> PlaceOrderAsync(int orderId,int customerId, List<CartItem> cartItems);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<List<Order>> GetOrdersByCustomerAsync(int customerId);
        Task CancelOrderAsync(int orderId);
        Task UpdateOrderStatusAsync(int orderId, string newStatus);
    }
}
