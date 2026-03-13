using Moq;
using Xunit;
using KiranaAppV1.Infrastructure.Services;
using KiranaAppV1.Core.Interfaces;
using KiranaAppV1.Core.Entities;
using AutoMapper;
using KiranaAppV1.Infrastructure.Mappings;
using Microsoft.Extensions.Logging;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly ProductService _service;

    private readonly IMapper _mapper;

    private readonly Mock<LoggerFactory> _mockLogger;

    public ProductServiceTests()
    {
        _mockRepo = new Mock<IProductRepository>();
        
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>(), (ILoggerFactory)_mockLogger);
        _mapper = config.CreateMapper();

        _service = new ProductService(_mockRepo.Object, _mapper);


    }

    [Fact]
    public async Task GetProductDetailsAsync_ShouldReturnMappedDTO_WhenProductExists()
    {
        var productId = 10;
        var fakeProduct = new Product { Id = productId, Name = "Laptop", Price = 50.00 ,Quantity = 100};

        _mockRepo.Setup(r => r.GetByIdAsync(productId))
                    .ReturnsAsync(fakeProduct);

        //Act
        var result = await _service.GetProductDetailsAsync(productId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Laptop", result.Name);
        _mockRepo.Verify(r=>r.GetByIdAsync(productId), Times.Once);
    }
}