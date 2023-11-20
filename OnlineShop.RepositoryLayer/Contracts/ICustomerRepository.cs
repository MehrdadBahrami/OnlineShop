using OnlineShop.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryLayer.Contracts
{
    internal interface ICustomerService
    {
        Customer GetCustomerById(int customerId);
        Customer GetCustomerByEmail(string email);
        void RegisterCustomer(Customer customer);
        void UpdateCustomerProfile(Customer customer);
        void ChangePassword(int customerId, string newPassword);
    }
}
