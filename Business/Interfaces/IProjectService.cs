using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<Project?> CreateProjectAsync(ProjectRegistarationForm form);
        Task<bool> DeleteProjectAsync(Project project);
        Task<IEnumerable<Project?>> GetProjectsAsync();
        Task<Project?> GetProjectsAsync(int id);
        Task<bool> UpdateProjectAsync(Project project);
    }
}