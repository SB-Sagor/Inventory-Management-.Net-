using InventoryManagement.DTOs;
using InventoryManagement.Models;
namespace InventoryManagement.Services;

public class ProductService
{//private static use kora lagbe na AddSingleton<ProductService>() service instance a use hobe

    private readonly List<Product> _products =
       [
           new Product
        {
            Id = 1,
            Name = "laptop",
            Price = 7500m,
            Stock = 10,
        },
        new Product
        {
            Id = 2,
            Name = "Mouse",
            Price = 1200m,
            Stock = 50,
        },
        new Product
        {
            Id = 3,
            Name = "Keyboard",
            Price = 2500m,
            Stock = 25,
        },
    ];

    public List<Product> GetProducts()
    {
        return _products;
    }

    public Product CreateProduct(CreateProductRequest request)
    {
        var product = new Product()
        {
            Id = _products.Count + 1,
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        };
        _products.Add(product);
        return product;
    }



    public Product? AddStock(int id, StockRequest request)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return null;
        }
        product.AddStock(request.Quantity);
        return product;
    }

    public List<Product> SearchProduct(string name)
    {


        var products = _products
        .Where(p => p.Name
        .Contains(name, StringComparison.OrdinalIgnoreCase))
        .ToList();
        return products;
    }

    public Product? GetProductById(int id)
    {
        var products = _products.FirstOrDefault(p => p.Id == id);
        if (products == null)
        {
            return null;
        }
        return products;
    }
    public Product? UpdateProduct(int id, UpdateProduct request)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return null;
        }
        product.Price = request.Price;
        return product;

    }

    public Product? DeleteProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return null;
        }
        _products.Remove(product);
        return product;
    }
}


