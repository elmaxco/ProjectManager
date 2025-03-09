using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, ICustomerRepository customerRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly ICustomerRepository _customerRepository = customerRepository;
    public async Task<bool> CreateProjectAsync(ProjectRegistarationForm form)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(form);

            var entity = ProjectFactory.Map(form);

            if (!await _customerRepository.ExistsAsync(customer => customer.Id == form.CustomerId))
                return false;

            if (entity == null)
                return false;

            entity = await _projectRepository.AddAsync(entity);


            if (entity == null)
                return false;

            return true;


        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<IEnumerable<Project?>> GetAllProjectsAsync()
    {
        var entities = await _projectRepository.GetAllAsync();
        var projects = entities.Select(ProjectFactory.Map);
        return projects;
    }

    public async Task<Project?> GetProjectAsync(int id)
    {
        var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);
        if (projectEntity == null)
            return null;

        var project = ProjectFactory.Map(projectEntity);
        return project;
    }

    public async Task<Project?> UpdateProjectAsync(ProjectUpdate form)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(form);

            var existingEntity = await _projectRepository.GetAsync(x => x.Id == form.Id);

            if (existingEntity == null)
                return null;


            existingEntity.ProjectName = form.ProjectName;
            existingEntity.Description = form.Description;
            existingEntity.StartDate = form.StartDate;
            existingEntity.EndDate = form.EndDate;
            existingEntity.StatusId = form.StatusId;
            existingEntity.ProjectTypeId = form.ProjectTypeId;


            await _projectRepository.UpdateAsync(existingEntity);


            var updatedEntity = await _projectRepository.GetAsync(x => x.Id == form.Id);

            return updatedEntity != null ? ProjectFactory.Map(updatedEntity) : null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }


    public async Task<bool> RemoveProjectAsync(Project project)
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
}



   
    