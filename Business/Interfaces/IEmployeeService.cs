using Business.Models;

namespace Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee?>> GetEmployeeAsync();
    }
}