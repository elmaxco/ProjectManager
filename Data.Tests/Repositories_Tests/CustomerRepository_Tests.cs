using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tests.Repositories_Tests;

public class CustomerRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddCustomer()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        var customerRepository = new CustomerRepository(context);

        //Act
        var result = await customerRepository.AddAsync(TestData.CustomerEntities[0]);

        //Assert      
        var addedCustomer = await context.Customer.FindAsync(TestData.CustomerEntities[0].Id);
        Assert.NotNull(addedCustomer);
        Assert.Equal(TestData.CustomerEntities[0].Id, addedCustomer.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllStatuses()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.CustomerEntities);
        await context.SaveChangesAsync();

        var customerRepository = new CustomerRepository(context);

        //Act
        var result = await customerRepository.GetAllAsync();

        //Assert
        Assert.Equal(TestData.CustomerEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnStatus()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.CustomerEntities);
        await context.SaveChangesAsync();

        var customerRepository = new CustomerRepository(context);

        //Act
        var result = await customerRepository.GetAsync(x => x.CustomerName == TestData.CustomerEntities[0].CustomerName);
        //Assert
        Assert.Equal(TestData.CustomerEntities[0].CustomerName, result!.CustomerName);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnTrue()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.CustomerEntities);
        await context.SaveChangesAsync();

        var customerRepository = new CustomerRepository(context);
        var statusEntity = TestData.CustomerEntities[0];


        //Act
        statusEntity.CustomerName = "Ny anställd";
        var result = await customerRepository.UpdateAsync(statusEntity);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        //Arrange
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.CustomerEntities);
        await context.SaveChangesAsync();

        var customerRepository = new CustomerRepository(context);
        var statusEntity = TestData.CustomerEntities[0];


        //Act

        var result = await customerRepository.RemoveAsync(statusEntity);

        //Assert
        Assert.True(result);
    }
}
