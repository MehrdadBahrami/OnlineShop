using OnlineShop.DomainLayer.Models;

/// <summary>
/// Repository interface for managing customer data.
/// </summary>
public interface ICustomerRepository
{
    /// <summary>
    /// Get a customer by their unique identifier.
    /// </summary>
    /// <param name="customerId">The unique identifier of the customer.</param>
    /// <returns>The customer entity if found; otherwise, null.</returns>
    Customer GetCustomerById(int customerId);

    /// <summary>
    /// Get a customer by their email address.
    /// </summary>
    /// <param name="email">The email address of the customer.</param>
    /// <returns>The customer entity if found; otherwise, null.</returns>
    Customer GetCustomerByEmail(string email);

    /// <summary>
    /// Register a new customer.
    /// </summary>
    /// <param name="customer">The customer entity to register.</param>
    void RegisterCustomer(Customer customer);

    /// <summary>
    /// Update the profile information of an existing customer.
    /// </summary>
    /// <param name="customer">The updated customer entity.</param>
    void UpdateCustomerProfile(Customer customer);

    /// <summary>
    /// Change the password of an existing customer.
    /// </summary>
    /// <param name="customerId">The unique identifier of the customer.</param>
    /// <param name="newPassword">The new password to set for the customer.</param>
    void ChangePassword(int customerId, string newPassword);
}
