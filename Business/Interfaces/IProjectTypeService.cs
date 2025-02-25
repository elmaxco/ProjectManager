using Business.Models;

namespace Business.Interfaces
{
    public interface IProjectTypeService
    {
        Task<IEnumerable<ProjectType?>> GetProjectTypeAsync();
    }
}