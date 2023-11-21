using OnlineShop.DomainLayer.Models;
using OnlineShop.RepositoryLayer.Contracts;

namespace OnlineShop.RepositoryLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();
        void IOrderRepository.CancelOrder(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);

            if (order != null)
            {
                order.OrderStatus = "Cancelled";
            }
        }

        Order IOrderRepository.GetOrderById(int orderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == orderId) ??
                new Order()
                {
                    CustomerId = 0,
                    OrderDate = DateTime.Now,
                    OrderId = 0,
                    OrderStatus = "Fail",
                    TotalAmount = 0
                };
        }

        List<Order> IOrderRepository.GetOrdersByCustomer(int customerId)
        {
            return _orders.Where(o => o.CustomerId == customerId).ToList();
        }

        Order IOrderRepository.PlaceOrder(int orderId,int customerId, List<CartItem> cartItems)
        {
            // Assume the cart items are used to create the order
            var order = new Order
            {
                OrderId=orderId,
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                TotalAmount = cartItems.Sum(item => item.TotalPrice),
                OrderStatus = "Placed"
            };

            _orders.Add(order);

            return order;
        }

        void IOrderRepository.UpdateOrderStatus(int orderId, string newStatus)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);

            if (order != null)
            {
                order.OrderStatus = newStatus;
            }
        }
    }
}
