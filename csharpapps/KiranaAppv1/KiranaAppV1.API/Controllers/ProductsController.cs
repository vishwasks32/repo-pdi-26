using KiranaAppV1.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KiranaAppV1.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetProductDetailsAsync(id);
        if(product == null) return NotFound();

        return Ok(product);
    }
}