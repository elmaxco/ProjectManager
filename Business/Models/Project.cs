using Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public Status? Status { get; set; }
    public Customer Customer { get; set; } = null!;
    public int CustomerId { get; set; }

 
    public Employee? ProjectManager { get; set; }  // Navigation Property
    
    public ProjectType? ProjectType { get; set; }
}


