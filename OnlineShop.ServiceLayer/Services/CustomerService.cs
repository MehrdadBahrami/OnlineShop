using OnlineShop.DomainLayer.Models;
using OnlineShop.RepositoryLayer.Contracts;
using OnlineShop.ServiceLayer.Contract;

namespace OnlineShop.ServiceLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        async Task ICustomerService.ChangePasswordAsync(int customerId, string newPassword) =>
        await Task.Run(() => _customerRepository.ChangePassword(customerId, newPassword));

        async Task<Customer> ICustomerService.GetCustomerByEmailAsync(string email)=>
        await Task.Run(() => _customerRepository.GetCustomerByEmail(email));
        

        async Task<Customer> ICustomerService.GetCustomerByIdAsync(int customerId) =>
        await Task.Run(() => _customerRepository.GetCustomerById(customerId));


        async Task ICustomerService.RegisterCustomerAsync(Customer customer) =>
        await Task.Run(() => _customerRepository.RegisterCustomer(customer));


        async Task ICustomerService.UpdateCustomerProfileAsync(Customer customer) =>
        await Task.Run(() => _customerRepository.UpdateCustomerProfile(customer));

    }
}
