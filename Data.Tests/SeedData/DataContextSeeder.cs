using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.SeedData;

public class DataContextSeeder
{
    public static DataContext GetDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new DataContext(options);
        context.Database.EnsureCreated();

        return context;
    }

    public static async Task SeedAsync(DataContext context)
    {
        context.Customer.AddRange(TestData.CustomerEntities);

        context.Employee.AddRange(TestData.EmployeeEntities);

        context.ProjectType.AddRange(TestData.ProjectTypeEntities);

        context.Statuses.AddRange(TestData.StatusEntities);        

        await context.SaveChangesAsync();
    }

    public static async Task SeedWithProjectAsync(DataContext context)
    {
        context.Customer.AddRange(TestData.CustomerEntities);

        context.Employee.AddRange(TestData.EmployeeEntities);

        context.ProjectType.AddRange(TestData.ProjectTypeEntities);

        context.Statuses.AddRange(TestData.StatusEntities);

        context.Project.AddRange(TestData.ProjectEntities);

        await context.SaveChangesAsync();
    }
}
