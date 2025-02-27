using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<Project?> CreateProjectAsync(ProjectRegistarationForm form)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(form);

            var projectEntity = ProjectFactory.Map(form);

            if (projectEntity == null)
                return null;

            var isAdded = await _projectRepository.AddAsync(projectEntity);

            if (!isAdded)
                return null;

            var project = ProjectFactory.Map(projectEntity);
            return project;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<Project?>> GetProjectsAsync()
    {
        var projectEntities = await _projectRepository.GetAllAsync();
        var projects = projectEntities.Select(ProjectFactory.Map);
        return projects;
    }

    public async Task<Project?> GetProjectsAsync(int id)
    {
        var projectEntity = await _projectRepository.GetAsync(p => p.Id == id);
        if (projectEntity == null)
            return null;

        var projects = ProjectFactory.Map(projectEntity);
        return projects;
    }

    public async Task<bool> UpdateProjectAsync(Project project)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(project);

            var projectEntity = ProjectFactory.Map(project);

            if (projectEntity == null)
                return false;

            var result = await _projectRepository.UpdateAsync(projectEntity);
            return result;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeleteProjectAsync(Project project)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(project);

            var projectEntity = ProjectFactory.Map(project);

            if (projectEntity == null)
                return false;

            var result = await _projectRepository.RemoveAsync(projectEntity);
            return result;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }



    // public async Task<Project?> GetProjectsAsync(string projectName)
    // {
    //     var projectEntity = await _projectRepository.GetAsync(p => p.ProjectName == projectName);
    //     if (projectEntity == null)
    //         return null;

    //     var projects = ProjectFactory.Map(projectEntity);
    //     return projects;
    // } 

    // public async Task<Project?> GetProjectByCustomerIdAsync(int customerId)
    // {
    //     var projectEntity = await _projectRepository.GetAsync(p => p.CustomerId == customerId);
    //     if (projectEntity == null)
    //         return null;

    //     var projects = ProjectFactory.Map(projectEntity);
    //     return projects;
    //
}
    