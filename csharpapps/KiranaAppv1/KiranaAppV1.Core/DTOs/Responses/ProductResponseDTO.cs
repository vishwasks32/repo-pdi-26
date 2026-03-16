using KiranaAppV1.Core.Entities;

namespace KiranaAppV1.Core.DTOs.Responses;

public class ProductResponseDTO
{
    public int Id { get; set;}
    public string Name { get; set;}

    public double Price { get; set;}
    public int Quantity { get; set;}

    public ProductCategory Category {get; set;}
}