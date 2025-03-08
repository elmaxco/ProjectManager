using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectEntity
{
    
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public int CustomerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public CustomerEntity Customer { get; set; } = null!;
    public StatusEntity Status { get; set; } = null!;
    public int StatusId { get; set; }    
    
    
    public int? ProjectTypeId { get; set; }
    public ProjectTypeEntity ProjectType { get; set; } = null!;

    
    public EmployeeEntity? ProjectManager { get; set; } 
    
}



