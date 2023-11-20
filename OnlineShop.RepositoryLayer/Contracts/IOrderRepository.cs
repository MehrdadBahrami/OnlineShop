using OnlineShop.DomainLayer.Models;

namespace OnlineShop.RepositoryLayer.Contracts
{
    public interface IOrderRepository
    {
        Order PlaceOrder(int customerId, List<CartItem> cartItems);
        Order GetOrderById(int orderId);
        List<Order> GetOrdersByCustomer(int customerId);
        void CancelOrder(int orderId);
        void UpdateOrderStatus(int orderId, string newStatus);
    }
}
