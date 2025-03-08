namespace Data.Entities;

public class  ProjectTypeEntity
{
    public int Id { get; set; }
    public string TypeName { get; set; } = null!;  
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}


