namespace Data.Entities;

public class TaskEntity
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public int AssignedToEmployeeId { get; set; }
    public DateTime DueDate { get; set; }
}