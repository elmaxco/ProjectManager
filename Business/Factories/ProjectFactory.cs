using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Diagnostics;


namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity? Map(ProjectRegistarationForm form) => form == null ? null : new ProjectEntity
    {
        ProjectName = form.ProjectName,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        StatusId = form.StatusId,
        CustomerId = form.CustomerId,
       
        ProjectTypeId = form.ProjectTypeId
    };

    public static ProjectEntity Map(ProjectUpdate form) => new()
    {
        Id = form.Id,
        ProjectName = form.ProjectName,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        StatusId = form.StatusId,
        CustomerId = form.CustomerId,        
        ProjectTypeId = form.ProjectTypeId
    };



    public static Project? Map(ProjectEntity entity) => entity == null ? null : new Project

    {
        Id = entity.Id,
        ProjectName = entity.ProjectName,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,       
        Status = StatusFactory.Map(entity.Status),
        Customer = CustomerFactory.Map(entity.Customer),
        ProjectManager = EmployeeFactory.Map(entity.ProjectManager),
        ProjectType = ProjectTypeFactory.Map(entity.ProjectType)

    };


    public static ProjectEntity? Map(Project project)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(project);

            var entity = new ProjectEntity
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                StatusId = project.Status!.Id,
                CustomerId = project.Customer!.Id,               
                ProjectTypeId = project.ProjectType!.Id
            };
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
}

    
  

   

