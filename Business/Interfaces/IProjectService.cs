using Business.Dtos;
using Business.Models;

namespace Business.Services
{
    public interface IProjectService
    {
        Task<bool> CreateProjectAsync(ProjectRegistarationForm form);
        Task<Project?> GetProjectAsync(int id);
        Task<IEnumerable<Project?>> GetAllProjectsAsync();
        Task<bool> RemoveProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(ProjectUpdate form);
    }
}
