using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected DataContext()
    {
    }

    public DbSet<ConditionEntity> Customer { get; set; }
    public DbSet<EmployeeEntity> Employee { get; set; }
    public DbSet<ProjectEntity> Project { get; set; }
    public DbSet<ProjectTypeEntity> ProjectType { get; set; }
    public DbSet<ConditionEntity> Statuses { get; set; }
}
