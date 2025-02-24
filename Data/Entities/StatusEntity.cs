namespace Data.Entities;

public class StatusEntity
{
    public int Id { get; set; }
    public string ConditionName { get; set; } = null!;
    public ICollection<StatusEntity> Condition { get; set; } = [];

}
