using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class ProjectTypeRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddProjectType()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        var projectTypeRepository = new ProjectTypeRepository(context);

        //Act
        var result = await projectTypeRepository.AddAsync(TestData.ProjectTypeEntities[0]);

        //Assert      
        var addedProjectType = await context.ProjectType.FindAsync(TestData.ProjectTypeEntities[0].Id);
        Assert.NotNull(addedProjectType);
        Assert.Equal(TestData.ProjectTypeEntities[0].Id, addedProjectType.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllStatuses()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.ProjectTypeEntities);
        await context.SaveChangesAsync();

        var projectTypeRepository = new ProjectTypeRepository(context);

        //Act
        var result = await projectTypeRepository.GetAllAsync();

        //Assert
        Assert.Equal(TestData.ProjectTypeEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnStatus()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.ProjectTypeEntities);
        await context.SaveChangesAsync();

       var projectTypeRepository = new ProjectTypeRepository(context);

        //Act
        var result = await projectTypeRepository.GetAsync(x => x.TypeName == TestData.ProjectTypeEntities[0].TypeName);
        //Assert
        Assert.Equal(TestData.ProjectTypeEntities[0].TypeName, result!.TypeName);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnTrue()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.ProjectTypeEntities);
        await context.SaveChangesAsync();

        var projectTypeRepository = new ProjectTypeRepository(context);
        var statusEntity = TestData.ProjectTypeEntities[0];


        //Act
        statusEntity.TypeName = "Ny Utbildning";
        var result = await projectTypeRepository.UpdateAsync(statusEntity);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.ProjectTypeEntities);
        await context.SaveChangesAsync();

        var projectTypeRepository = new ProjectTypeRepository(context);
        var statusEntity = TestData.ProjectTypeEntities[0];


        //Act

        var result = await projectTypeRepository.RemoveAsync(statusEntity);

        //Assert
        Assert.True(result);
    }
}
