using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(CustomerRegistrationForm form);
        Task<bool> DeleteCustomerAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllCustomerAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task<bool> UpdateCustomerAsync(CustomerUpdate form);

    }
}
