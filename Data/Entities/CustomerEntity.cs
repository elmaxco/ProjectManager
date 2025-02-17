namespace Data.Entities;

internal class CustomerEntity
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? ContactPerson { get; set; } 

}
