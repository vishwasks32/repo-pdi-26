
using KiranaAppV1.Core.Entities;
using KiranaAppV1.Infrastructure.Data;
using KiranaAppV1.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class ProductRepositoryTests
{
    private KiranaAppDbContext GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<KiranaAppDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

        var databaseContext = new KiranaAppDbContext(options);
        databaseContext.Database.EnsureCreated();
        return databaseContext;
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnProduct_WhenItExistsInDb()
    {
        // Arrange
        var context = GetDatabaseContext();
        var repository = new ProductRepository(context);

        var testProduct = new Product { Id= 1, Name = "Laptop", Price = 100, Quantity = 100};

        context.Products.Add(testProduct);
        await context.SaveChangesAsync();

        //Act 
        var result = await repository.GetByIdAsync(1);

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Laptop", result.Name);
    }
}