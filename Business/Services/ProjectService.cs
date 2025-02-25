using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository)
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

    public async Task<Project?> GetProjectsAsync(int id) 
    {
        var projectEntity = await _projectRepository.GetAsync(p => p.Id == id);
        if (projectEntity == null)
            return null;

        var projects = ProjectFactory.Map(projectEntity);
        return projects;
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
    // }
}