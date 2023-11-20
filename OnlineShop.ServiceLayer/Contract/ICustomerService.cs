using OnlineShop.DomainLayer.Models;

namespace OnlineShop.ServiceLayer.Contract
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<Customer> GetCustomerByEmailAsync(string email);
        Task RegisterCustomerAsync(Customer customerModel);
        Task UpdateCustomerProfileAsync(Customer customerModel);
        Task ChangePasswordAsync(int customerId, string newPassword);
    }
}
