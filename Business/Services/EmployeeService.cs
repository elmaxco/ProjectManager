using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public async Task<IEnumerable<Employee?>> GetEmployeeAsync()
    {
        var entities = await _employeeRepository.GetAllAsync();
        return entities.Select(EmployeeFactory.Map);
    }

}


