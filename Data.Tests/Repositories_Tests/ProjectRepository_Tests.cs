using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class ProjectRepository_Tests
{

    private DataContext GetDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new DataContext(options);
        context.Database.EnsureCreated();
        return context;
    }

    private async Task SeedData(DataContext context)
    {
        context.Customer.AddRange(TestData.CustomerEntities);
        context.Employee.AddRange(TestData.EmployeeEntities);
        context.ProjectType.AddRange(TestData.ProjectTypeEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        await context.SaveChangesAsync();
    }

    private async Task SeedDataWithProjects(DataContext context)
    {
        context.Customer.AddRange(TestData.CustomerEntities);
        context.Employee.AddRange(TestData.EmployeeEntities);
        context.ProjectType.AddRange(TestData.ProjectTypeEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        context.Project.AddRange(TestData.ProjectEntities);
        await context.SaveChangesAsync();
    }

    [Fact]
    public async Task AddAsync_Should_AddAndReturnProject()
    {
        // Arrange
        var context = GetDataContext();
        await SeedData(context);
        IProjectRepository repository = new ProjectRepository(context);
        var projectEntity = TestData.ProjectEntities[0];

        // Act
        var result = await repository.AddAsync(projectEntity);

        // Assert
        Assert.NotEqual(0, projectEntity.Id);
    }

    [Fact]
    public async Task GetTaskAsync_ShouldReturnProject()
    {
        // Arrange
        var context = GetDataContext();
        await SeedDataWithProjects(context);
        IProjectRepository repository = new ProjectRepository(context);

        
        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.ProjectEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnProject()
    {
        // Arrange
        var context = GetDataContext();
        await SeedDataWithProjects(context);
        IProjectRepository repository = new ProjectRepository(context);

        // Act
        var result = await repository.GetAsync(x => x.Id == 1);

        // Assert
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task UpdateAsync_Should_UpdateProject()
    {
        // Arrange
        var context = GetDataContext();
        await SeedDataWithProjects(context);
        IProjectRepository repository = new ProjectRepository(context);
        var project = await repository.GetAsync(x => x.Id == 1);

        // Act
        project!.ProjectName = "Updated Project Name";
        var result = await repository.UpdateAsync(project);
        var updatedProject = await repository.GetAsync(x => x.Id == 1);

        // Assert
        Assert.True(result);
        Assert.Equal("Updated Project Name", updatedProject!.ProjectName);
    }

    [Fact]
    public async Task RemoveAsync_Should_DeleteProject()
    {
        // Arrange
        var context = GetDataContext();
        await SeedDataWithProjects(context);
        IProjectRepository repository = new ProjectRepository(context);
        var project = await repository.GetAsync(x => x.Id == 1);

        // Act
        var result = await repository.RemoveAsync(project!);
        var deletedProject = await repository.GetAsync(x => x.Id == 1);

        // Assert
        Assert.True(result);
        Assert.Null(deletedProject);
    }


}
