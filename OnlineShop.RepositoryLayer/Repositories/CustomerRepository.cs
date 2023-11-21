using OnlineShop.DomainLayer.Models;
using OnlineShop.RepositoryLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers ;

        public CustomerRepository()
        {
            // Initialize the list (simulating a database)
            _customers =
        [
            new Customer(){Address="Nothing",CustomerId=1,Email="m.bahrami.h@gmail.com",FirstName="Mehrdad",LastName="Bahrami",PasswordHash="123"}
            // Add more sample data as needed
        ];
        }

        void ICustomerRepository.ChangePassword(int customerId, string newPassword)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerId == customerId);

            if (customer != null)
            {
                // Update the password for the customer
                customer.PasswordHash = newPassword;
            }
        }

        Customer ICustomerRepository.GetCustomerByEmail(string email)
        {
            return _customers.FirstOrDefault(c => c.Email == email) ??
                             new Customer()
                             {
                                 Address = "",
                                 CustomerId = 0,
                                 Email = "Fail",
                                 FirstName = "Fail",
                                 LastName = "Fail",
                                 PasswordHash = "Fail"
                             }; ;
        }

        Customer ICustomerRepository.GetCustomerById(int customerId)
        {
            return _customers.FirstOrDefault(c => c.CustomerId == customerId) ??
                new Customer()
                {
                    Address = "",
                    CustomerId = 0,
                    Email = "Fail",
                    FirstName = "Fail",
                    LastName = "Fail",
                    PasswordHash = "Fail"
                };
        }

        void ICustomerRepository.RegisterCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        void ICustomerRepository.UpdateCustomerProfile(Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);

            if (existingCustomer != null)
            {
                // Update existing customer profile
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                // Update other properties as needed
            }
        }
    }
}
