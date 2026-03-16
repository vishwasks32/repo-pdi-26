
using KiranaAppV1.Core.Entities;
using KiranaAppV1.Infrastructure.Data;
using KiranaAppV1.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public class ProductRepositoryTests: IDisposable
{
    protected readonly KiranaAppDbContext Context;
    private readonly System.Data.Common.DbConnection _connection;

    protected ProductRepositoryTests()
    {
        // 1. Create a connection to an in-memory SQLite database
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        // 2. Configure DbContext to use this connection
        var options = new DbContextOptionsBuilder<KiranaAppDbContext>()
            .UseSqlite(_connection)
            .Options;

        Context = new KiranaAppDbContext(options);
        
        // 3. Ensure the schema is created
        Context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        _connection.Close(); // This deletes the in-memory database
        Context.Dispose();
    }

    // [Fact]
    // public async Task GetByIdAsync_ShouldReturnProduct_WhenItExistsInDb()
    // {
    //     // Arrange
    //     var repository = new ProductRepository(Context);

    //     var testProduct = new Product { Id= 1, Name = "Laptop", Price = 100, Quantity = 100};

    //     Context.Products.Add(testProduct);
    //     await Context.SaveChangesAsync();

    //     //Act 
    //     var result = await repository.GetByIdAsync(1);

    //     //Assert
    //     Assert.NotNull(result);
    //     Assert.Equal("Laptop", result.Name);
    // }
}