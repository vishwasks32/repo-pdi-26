using kiranaapp.Models;
using kiranaapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace kiranaapp.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : ControllerBase
{
    public ProductController()
    {
        
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        ProductService.Add(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id}, product);
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(ProductService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var product = ProductService.Get(id);

        if(product == null)
            return NotFound();

        return Ok(product);
    }

}