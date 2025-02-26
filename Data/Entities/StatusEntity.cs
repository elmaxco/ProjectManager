namespace Data.Entities;

public class StatusEntity
{
    public int Id { get; set; }    
    public ICollection<StatusEntity> Status { get; set; } = [];
    public string StatusName { get; set; } = null!;
}
