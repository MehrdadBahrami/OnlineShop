using OnlineShop.DomainLayer.Models;

namespace OnlineShop.RepositoryLayer.Contracts
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int customerId);
        Customer GetCustomerByEmail(string email);
        void RegisterCustomer(Customer customer);
        void UpdateCustomerProfile(Customer customer);
        void ChangePassword(int customerId, string newPassword);
    }
}
