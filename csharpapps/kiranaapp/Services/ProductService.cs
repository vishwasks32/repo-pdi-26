
using kiranaapp.Models;
using Microsoft.AspNetCore.SignalR;

namespace kiranaapp.Services;

public static class ProductService
{
    static List<Product> Products {get;}
    static int nextId = 3;
    
    static ProductService()
    {
        Products = new List<Product>
        {
            new Product { Id = 1, Name = "Rice", IsEnabled = true},
            new Product { Id = 2, Name = "Wheat", IsEnabled = true}
        };

    }

    public static void Add(Product product)
    {
        product.Id = nextId++;
        Products.Add(product);
    }

    public static List<Product> GetAll() => Products;

    public static Product Get(int id) => Products.FirstOrDefault(p=> p.Id == id);


}