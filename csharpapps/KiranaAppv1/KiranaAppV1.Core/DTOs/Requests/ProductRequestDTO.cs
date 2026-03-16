using KiranaAppV1.Core.Entities;

namespace KiranaAppV1.Core.DTOs.Requests;

public class ProductRequestDTO
{
    public string Name { get; set;}
    public double Price { get; set;}
    public int Quantity { get; set;}
    public ProductCategory Category { get; set;}
}