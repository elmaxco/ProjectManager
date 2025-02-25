using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, ICustomerRepository customerRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<bool> CreateProjectAsync(ProjectRegistarationForm form)
    {
        if (!await _customerRepository.ExistAsync(customer => customer.Id == form.CustomerId))
            return false;

        var projectEntity = ProjectFactory.Create(form);
        if (projectEntity == null)
            return false;

        bool result = await _projectRepository.AddAsync(projectEntity);
        return result;
    }

    public async Task<IEnumerable<Project?>> GetProjectsAsync() 
    {
        var entities = await _projectRepository.GetAllAsync();
        var projects = entities.Select(ProjectFactory.Create);
        return projects;
    }
    public async Task<Project?> GetProjectAsync(Expression <Func<ProjectEntity, bool>>expression) 
    {
        var entity = await _projectRepository.GetAsync(expression);
        var project = ProjectFactory.Create(entity);
        return project ?? null!;
    }
    public async Task<bool> UpdateProjectAsync(Project project)
    {
        var entity = ProjectFactory.Create(project);
        if (entity == null)
            return false;
        bool result = await _projectRepository.UpdateAsync(entity);
        return result;
    }
    public async Task<bool> DeleteProjectAsync(int id)
    {
        var project = await _projectRepository.GetAsync(x => x.Id == id);
        if (project != null)
        { return await _projectRepository.RemoveAsync(project); }
        return false;
        
    }
}
