using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using KiranaAppV1.API.Controllers;
using KiranaAppV1.Core.Interfaces;
using KiranaAppV1.Core.DTOs.Responses;

public class ProductsControllerTests
{
    private readonly Mock<IProductService> _mockService;
    private readonly ProductsControllerTests _controller;

    public ProductsControllerTests()
    {
        _mockService = new Mock<IProductService>();
        _controller = new ProductsController(_mockService.Object);
    }

    [Fact]
    public async Task GetById_ReturnsOk_WhenProductExists()
    {
        var productId = 1;
        var fakeProduct = new ProductResponseDTO{ Id = productId, Name = "Test Item"};
        _mockService.Setup(s=> s.GetProductDetailsAsync(productId))
                            .ReturnsAsync(fakeProduct);

        var Result = await _controller.GetById(productId);

        // Assert
        var okresult = Assert.IsType<OkObjectResult>(result);
        var returnedProduct = Assert.IsType<ProductResponseDTO>(OkResult.Value);

        Assert.Equal(productId, returnedProduct.Id);
    }
}