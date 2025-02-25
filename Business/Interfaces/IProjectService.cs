using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<bool> CreateProjectAsync(ProjectRegistarationForm form);
        Task<IEnumerable<Project?>> GetProjectsAsync();
        Task<Project?> GetProjectByIdAsync(int id);
        Task<bool> UpdateProjectAsync(int id, ProjectRegistarationForm form);
        Task<bool> DeleteProjectAsync(int id);
    }
}