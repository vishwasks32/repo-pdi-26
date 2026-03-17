namespace KiranaAppV1.Core.Entities;

public class Product
{
    public int Id { get; set;}
    public required string Name { get; set;}

    public double Price { get; set;}
    public int Quantity { get; set;}

    public ProductCategory Category { get; set;}
}