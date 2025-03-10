﻿namespace Business.Dtos;

public class ProjectUpdate
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public int StatusId { get; set; }    
    public int ProjectTypeId { get; set; }
    public int CustomerId { get; set; }

}
