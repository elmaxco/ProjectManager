using Business.Models;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<bool> CreateProjectAsync(ProjectRegistarationForm form);
        Task<IEnumerable<Project?>> GetProjectsAsync();
    }
}