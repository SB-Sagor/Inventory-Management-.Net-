using InventoryManagement.Models;
using InventoryManagement.Interfaces;
using InventoryManagement.Data;
using System.Diagnostics.Tracing;
using Microsoft.EntityFrameworkCore;
namespace InventoryManagement.Repositories;

public class ProductRepository : IProductRepository
{
    // private readonly List<Product> _products =
    //        [
    //            new Product
    //     {
    //         Id = 1,
    //         Name = "laptop",
    //         Price = 7500m,
    //         Stock = 10,
    //     },
    //     new Product
    //     {
    //         Id = 2,
    //         Name = "Mouse",
    //         Price = 1200m,
    //         Stock = 50,
    //     },
    //     new Product
    //     {
    //         Id = 3,
    //         Name = "Keyboard",
    //         Price = 2500m,
    //         Stock = 25,
    //     },
    // ];

    private readonly InventoryDbContext _context;
    public ProductRepository(InventoryDbContext context)
    {
        _context = context;
    }
    public List<Product> GetAll()//previously it was GetProduct()
    {
        // return _products;
        return _context.Products.ToList();//_context database context and Products DbSet InventoryDbContext
    }

    public Product? GetById(int id)//finding id
    {
        // return _products.FirstOrDefault(p => p.Id == id);
        return _context.Products.FirstOrDefault(p => p.Id == id);

    }


    public List<Product> Search(string name)
    {
        // return _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        return _context.Products.Where(p => EF.Functions.ILike(p.Name, $"%{name}%")).ToList();
        //ILike postgres er case insensitive search
        //$"%{name}%") name er jekhono part er shathe match korbe
        //ToList()query executive kore 
    }
    public async Task<Product> Add(Product product)
    {
        // if (_products.Count == 0) product.Id = 1;//manually id generation
        // else product.Id = _products.Max(p => p.Id) + 1;
        // _products.Add(product);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();//must lagbe database a data save kore rakhar jonno 
        return product;
    }
    public async Task<Product?> AddStock(int id, int quantity)
    {
        var product = GetById(id);
        if (product == null) return null;
        product.AddStock(quantity);
        // _context.Products.AddStock(quantity);//Product amader c# model and Products entity database collection access korar property
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateProduct(int id, decimal price)
    {
        var product = GetById(id);
        if (product == null) return null;
        product.Price = price;
        await _context.SaveChangesAsync();
        return product;
    }
    public async Task<bool> Delete(int id)
    {
        var product = GetById(id);
        if (product == null)
            return false;
        // return _products.Remove(product);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;

    }
}
