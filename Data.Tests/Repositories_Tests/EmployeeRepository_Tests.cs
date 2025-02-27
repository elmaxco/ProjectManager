using Data.Repositories;
using Data.Tests.SeedData;

public class EmployeeRepository_Tests
{
 
        [Fact]
        public async Task AddAsync_ShouldAddEmployee()
        {
            //Arrange
            var context = DataContextSeeder.GetDataContext();
            var employeeRepository = new EmployeeRepository(context);

            //Act
            var result = await employeeRepository.AddAsync(TestData.EmployeeEntities[0]);

            //Assert      
            var addedEmployee = await context.Employee.FindAsync(TestData.EmployeeEntities[0].Id);
            Assert.NotNull(addedEmployee);
            Assert.Equal(TestData.EmployeeEntities[0].Id, addedEmployee.Id);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllStatuses()
        {
            //Arrange
            var context = DataContextSeeder.GetDataContext();
            await context.AddRangeAsync(TestData.EmployeeEntities);
            await context.SaveChangesAsync();

            var employeeRepository = new EmployeeRepository(context);

            //Act
            var result = await employeeRepository.GetAllAsync();

            //Assert
            Assert.Equal(TestData.EmployeeEntities.Length, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnStatus()
        {
            //Arrange
            var context = DataContextSeeder.GetDataContext();
            await context.AddRangeAsync(TestData.EmployeeEntities);
            await context.SaveChangesAsync();

            var employeeRepository = new EmployeeRepository(context);

            //Act
            var result = await employeeRepository.GetAsync(x => x.Employee == TestData.EmployeeEntities[0].Employee);
            //Assert
            Assert.Equal(TestData.EmployeeEntities[0].Employee, result!.Employee);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnTrue()
        {
            //Arrange
            var context = DataContextSeeder.GetDataContext();
            await context.AddRangeAsync(TestData.EmployeeEntities);
            await context.SaveChangesAsync();

            var employeeRepository = new EmployeeRepository(context);
            var statusEntity = TestData.EmployeeEntities[0];


            //Act
            statusEntity.Employee = "Ny anställd";
            var result = await employeeRepository.UpdateAsync(statusEntity);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnTrue()
        {
            //Arrange
            var context = DataContextSeeder.GetDataContext();
            await context.AddRangeAsync(TestData.EmployeeEntities);
            await context.SaveChangesAsync();

            var employeeRepository = new EmployeeRepository(context);
            var statusEntity = TestData.EmployeeEntities[0];


            //Act

            var result = await employeeRepository.RemoveAsync(statusEntity);

            //Assert
            Assert.True(result);
        }
    }
