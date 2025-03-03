using Business.Dtos;
using Business.Models;

namespace Business.Services
{
    public interface IProjectService
    {
        Task<bool> CreateProjectAsync(ProjectRegistarationForm form);
        Task<Project?> GetProjectAsync(int id);
        Task<IEnumerable<Project?>> GetProjectsAsync();
        Task<bool> RemoveProjectAsync(Project project);
        Task<bool> UpdateProjectAsync(ProjectUpdate form);
    }
}
