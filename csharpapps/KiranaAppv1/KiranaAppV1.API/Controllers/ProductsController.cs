using KiranaAppV1.Core.DTOs.Requests;
using KiranaAppV1.Core.DTOs.Responses;
using KiranaAppV1.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace KiranaAppV1.API.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductService service, ILogger<ProductsController> logger)
    {
        _service = service;
        _logger = logger;

    }

    [Authorize(Roles ="Admin,Manager")]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRequestDTO productRequest)
    {
        _logger.LogDebug("Hit the get single product:{ProductRequest}", productRequest);
        var product = await _service.CreateProduct(productRequest);
        if (product == null) return NotFound();

        return CreatedAtAction(nameof(GetById), new { id = product.Id}, new ApiResponse<ProductResponseDTO>(true, "Product created successfully", product, []));
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetProductDetailsAsync(id);
        if(product == null) return NotFound();

        return Ok(new ApiResponse<ProductResponseDTO>(true, "Product Fetched Successfully", product, []));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _service.GetAll();

        return Ok(new ApiResponse<IEnumerable<ProductResponseDTO>>(true, "Products Fetched Successfully", products, []));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequestDTO productRequest)
    {
        var result = await _service.UpdateProduct(id, productRequest);

        return Ok(new ApiResponse<ProductResponseDTO>(true, "Product updated Successfully", result, []));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _service.DeleteProductAsync(id);

        return Ok(new ApiResponse<ProductResponseDTO?>(true, "Product deleted Successfully", null, []));
    }


    [HttpGet("pages")]
    public async Task<IActionResult> GetAll([FromQuery] ProductParameters parameters)
    {
        var response = await _service.GetPagedResponseAsync(parameters);
        return Ok(response);
    }
}