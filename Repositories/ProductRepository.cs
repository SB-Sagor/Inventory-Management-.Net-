using InventoryManagement.Models;
using InventoryManagement.Interfaces;
namespace InventoryManagement.Repositories;

public class ProductRepository : IProductRepository
{
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

    public List<Product> GetAll()//previously it was GetProduct()
    {
        return _products;
    }

    public Product? GetById(int id)//finding id
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }


    public List<Product> Search(string name)
    {
        return _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public Product Add(Product product)
    {
        if (_products.Count == 0) product.Id = 1;
        else product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);
        return product;
    }
    public Product? AddStock(int id, int quantity)
    {
        var product = GetById(id);
        if (product == null) return null;
        product.AddStock(quantity);
        return product;
    }

    public Product? UpdateProduct(int id, decimal price)
    {
        var product = GetById(id);
        if (product == null) return null;
        product.Price = price;
        return product;
    }
    public bool Delete(int id)
    {
        var product = GetById(id);
        if (product == null)
            return false;
        return _products.Remove(product);
    }
}
