using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    public async Task<Customer> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(form);

            var entity = CustomerFactory.Create(form);
            if (entity == null)
                return null!;

            entity = await _customerRepository.AddAsync(entity);
            if (entity == null)
                return null!;

            var customer = CustomerFactory.Map(entity);
            return customer!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
    {
        var entities = await _customerRepository.GetAllAsync();
        var customers = entities.Select(CustomerFactory.Map).Where(c => c != null)!;
        return customers!;
    }

    public async Task<Customer> GetCustomerAsync(int id)
    {
        var entities = await _customerRepository.GetAsync(x => x.Id == id);
        if (entities == null)
            return null!;
        var customers = CustomerFactory.Map(entities);
        return customers!;
    }

    public async Task<bool> UpdateCustomerAsync(CustomerUpdate form)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(form);

            var entity = CustomerFactory.Create(form);
            if (entity == null)
                return false;

            var result = await _customerRepository.UpdateAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
    public async Task<bool> DeleteCustomerAsync(Customer customer)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(customer);

            var entity = await _customerRepository.GetAsync(x => x.Id == customer.Id);

            if (entity == null)
                return false;

            var result = await _customerRepository.RemoveAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}