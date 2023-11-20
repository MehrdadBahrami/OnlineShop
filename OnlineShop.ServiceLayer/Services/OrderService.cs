using OnlineShop.DomainLayer.Models;
using OnlineShop.RepositoryLayer.Contracts;
using OnlineShop.ServiceLayer.Contract;

namespace OnlineShop.ServiceLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        async Task IOrderService.CancelOrderAsync(int orderId) => 
        await Task.Run(() => _orderRepository.CancelOrder(orderId));

        async Task<Order> IOrderService.GetOrderByIdAsync(int orderId) =>
        await Task.Run(() => _orderRepository.GetOrderById(orderId));


        async Task<List<Order>> IOrderService.GetOrdersByCustomerAsync(int customerId)=>
        await Task.Run(() => _orderRepository.GetOrdersByCustomer(customerId));


        async Task<Order> IOrderService.PlaceOrderAsync(int customerId, List<CartItem> cartItems) => 
        await Task.Run(() => _orderRepository.PlaceOrder(customerId, cartItems));

        async Task IOrderService.UpdateOrderStatusAsync(int orderId, string newStatus) => 
        await Task.Run(() => _orderRepository.UpdateOrderStatus(orderId, newStatus));
    }
}
