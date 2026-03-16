using KiranaAppV1.Core.DTOs.Requests;
using KiranaAppV1.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KiranaAppV1.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    private readonly ILogger _logger;

    public ProductsController(IProductService service, ILogger logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRequestDTO productRequest)
    {
        _logger.LogDebug("The Create Product called with {productRequest}", productRequest);
        Console.WriteLine("Hit the Create Product");
        var product = await _service.CreateProduct(productRequest);
        if (product == null) return NotFound();

        return CreatedAtAction(nameof(GetById), new { id = product.Id}, product);
        
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetProductDetailsAsync(id);
        if(product == null) return NotFound();

        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _service.GetAll();

        return Ok(products);
    }

    [HttpPut("/{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequestDTO productRequest)
    {
        var result = await _service.UpdateProduct(id, productRequest);

        return Ok(result);
    }

    [HttpDelete("/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _service.DeleteProductAsync(id);

        return Ok("Product Deleted Successfully");
    }
}