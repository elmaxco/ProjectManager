namespace Data.Entities;

public class EmployeeEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Employee { get; set; } = null!;   
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}


