using Data.Contexts;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class StatusRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddStatus() 
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        var statusRepository = new StatusRepository(context);

        //Act
        var result = await statusRepository.AddAsync(TestData.StatusEntities[0]);

        //Assert      
        var addedStatus = await context.Statuses.FindAsync(TestData.StatusEntities[0].Id);
        Assert.NotNull(addedStatus);
        Assert.Equal(TestData.StatusEntities[0].Id, addedStatus.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllStatuses()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.StatusEntities);
        await context.SaveChangesAsync();

        var statusRepository = new StatusRepository(context);

        //Act
        var result = await statusRepository.GetAllAsync();
        //Assert
        Assert.Equal(TestData.StatusEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnStatus()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.StatusEntities);
        await context.SaveChangesAsync();

        var statusRepository = new StatusRepository(context);

        //Act
        var result = await statusRepository.GetAsync(x => x.StatusName == "Pågår");
        //Assert
        Assert.Equal("Pågår", result!.StatusName);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnTrue()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.StatusEntities);
        await context.SaveChangesAsync();

        var statusRepository = new StatusRepository(context);
        var statusEntity = TestData.StatusEntities[0];      


        //Act
        statusEntity.StatusName = "Avslutad";
        var result = await statusRepository.UpdateAsync(statusEntity);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.StatusEntities);
        await context.SaveChangesAsync();

        var statusRepository = new StatusRepository(context);
        var statusEntity = TestData.StatusEntities[0];


        //Act
        
        var result = await statusRepository.RemoveAsync(statusEntity);

        //Assert
        Assert.True(result);
    }
}


